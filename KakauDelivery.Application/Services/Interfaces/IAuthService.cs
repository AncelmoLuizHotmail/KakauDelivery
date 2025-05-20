using KakauDelivery.Application.Interop;

namespace KakauDelivery.Application.Services.Interfaces
{
    public interface IAuthService
    {
        Task<ResultViewModel<string>> Authenticate(string email, string senha);
    }
}
