using KakauDelivery.Application.Interop.Cliente.Mapper;

namespace KakauDelivery.Application.Interop.Usuario.Mapper
{
    public static class UsuarioMap
    {
        public static Domain.Entities.Usuario InputModelForEntity(this UsuarioInputModel inputModel)
        {
            var cliente = inputModel.Cliente?.InputModelForEntity();
            return new Domain.Entities.Usuario(inputModel.Email, inputModel.Senha, inputModel.Perfil, cliente);
        }

        public static UsuarioViewModel EntityForViewModel(this Domain.Entities.Usuario entity)
        {
            return new UsuarioViewModel()
            {
                Id = entity.Id,
                Email = entity.Email,
                Perfil = entity.Perfil.ToString(),
                IdCliente = entity.Cliente?.Id,
                Cliente = entity.Cliente?.EntityForViewModel()
            };
        }
    }
}
