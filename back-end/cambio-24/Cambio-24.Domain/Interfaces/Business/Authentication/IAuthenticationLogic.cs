using Cambio_24.Models.AuthenticationModels;

namespace Cambio_24.Domain.Interfaces.Business.Authentication
{
    public interface IAuthenticationLogic
    {
        AuthenticationResponse SignIn(AuthenticationRequest request);
        AuthenticationModel GetTokenContent(string token);
    }
}
