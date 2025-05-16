using KakauDelivery.Application.Applications.Interfaces;
using KakauDelivery.Application.Interop;
using KakauDelivery.Application.Interop.Cliente;
using KakauDelivery.Application.Interop.Usuario;
using KakauDelivery.Application.Interop.Usuario.Mapper;
using KakauDelivery.Application.Services.Interfaces;
using KakauDelivery.Domain.Enums;
using KakauDelivery.Domain.Repositories.RepositoryReadOnly;

namespace KakauDelivery.Application.Applications.Usuario
{
    public class UsuarioApp : IUsuarioApp
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IClienteApp _clenteApp;
        private readonly IUsuarioRepositoryReadOnly _usuarioRepositoryReadOnly;
        private readonly IPasswordHasher _passwordHasher;

        public UsuarioApp(IUsuarioService usuarioService,
            IClienteApp clienteApp,
            IUsuarioRepositoryReadOnly usuarioRepositoryReadOnly,
            IPasswordHasher passwordHasher)
        {
            _usuarioService = usuarioService;
            _clenteApp = clienteApp;
            _usuarioRepositoryReadOnly = usuarioRepositoryReadOnly;
            _passwordHasher = passwordHasher;
        }
        public async Task<ResultViewModel<UsuarioViewModel>> RegistrarUsuario(UsuarioInputModel inputModel)
        {
            var usuarioExistente = await _usuarioRepositoryReadOnly.GetUsuarioByEmail(inputModel.Email);

            if (usuarioExistente.Any())
                return ResultViewModel<UsuarioViewModel>.Error("Usuário já cadastrado com esse e-mail.");

            ClienteInputModel cliente = null;
            if (inputModel.Perfil == PerfilUsuarioEnum.Comprador)
            {
                if (inputModel.Cliente == null)
                    return ResultViewModel<UsuarioViewModel>.Error("Dados do cliente são obrigatórios para compradores");

                cliente = new ClienteInputModel
                {
                    Nome = inputModel.Cliente.Nome,
                    Telefone = inputModel.Cliente.Telefone,
                    Email = inputModel.Cliente.Email
                };

                await _clenteApp.Create(cliente);
            }

            var usuarioIM = new UsuarioInputModel
            {
                Email = inputModel.Email,
                Perfil = inputModel.Perfil,
                Cliente = cliente
            };

            usuarioIM.SetPassword(inputModel.Senha, _passwordHasher);
            var usuario = usuarioIM.InputModelForEntity();

            await _usuarioService.Create(usuario);

            return ResultViewModel<UsuarioViewModel>.Success(usuario.EntityForViewModel());
        }
    }
}
