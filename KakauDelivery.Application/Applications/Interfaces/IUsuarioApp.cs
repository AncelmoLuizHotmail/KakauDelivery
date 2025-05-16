using KakauDelivery.Application.Interop;
using KakauDelivery.Application.Interop.Usuario;

namespace KakauDelivery.Application.Applications.Interfaces
{
    public interface IUsuarioApp
    {
        Task<ResultViewModel<UsuarioViewModel>> RegistrarUsuario(UsuarioInputModel inputModel);
    }
}
