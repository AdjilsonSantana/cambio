using Cambio_24.Domain.Interfaces.Business.Authentication;
using Cambio_24.Framework.Interfaces;
using Cambio_24.Models.AuthenticationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cambio_24.Framework.Authentication
{
   public class AuthenticationFramework: IAuthenticationFramework
    {
        private readonly IAuthenticationLogic _authenticationLogic;

        public AuthenticationFramework(IAuthenticationLogic authenticationLogic)
        {
            _authenticationLogic = authenticationLogic;
        }

        public AuthenticationResponse SignIn(AuthenticationRequest request)
        {
            return _authenticationLogic.SignIn(request);
        }

        public AuthenticationModel GetTokenContent(string token)
        {
            return _authenticationLogic.GetTokenContent(token);
        }
    }
}
