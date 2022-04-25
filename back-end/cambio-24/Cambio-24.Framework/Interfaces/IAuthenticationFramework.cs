using Cambio_24.Models.AuthenticationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cambio_24.Framework.Interfaces
{
    public interface IAuthenticationFramework
    {
        AuthenticationResponse SignIn(AuthenticationRequest request);
        AuthenticationModel GetTokenContent(string token);
    }
}
