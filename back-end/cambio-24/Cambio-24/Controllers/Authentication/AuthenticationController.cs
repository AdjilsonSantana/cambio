using Cambio_24.Framework.Interfaces;
using Cambio_24.Models.AuthenticationModels;
using Cambio_24.WebApi.Sesson;
using Cambio_24.WebApi.Sesson.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Cambio_24.WebApi.Controllers.Authentication
{

    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly ILogger<AuthenticationController> _logger;
        private readonly IAuthenticationFramework _authentication;
        private readonly ISessionHandler _sessionHandler;
        private readonly IEmployeeFramework _employeeFramework;

        public AuthenticationController(ILogger<AuthenticationController> logger, 
            ISessionHandler sessionHandler,
            IAuthenticationFramework authentication,
            IEmployeeFramework employeeFramework)
        {
            _logger = logger;
            _authentication = authentication;
            _sessionHandler = sessionHandler;
            _employeeFramework = employeeFramework;
        }

        [HttpPost]
        [Route("api/v1/auth")]
        [AllowAnonymous]
        public AuthenticationResponse Login(AuthenticationRequest request)
        {
            var result = _authentication.SignIn(request);

            if (result.Success)
            {
                string username = !string.IsNullOrEmpty(request.Username) ? request.Username : request.Email; 
                var employee = _employeeFramework.GetByUser(username);
                result.EmployeeId = employee != null && employee.Employee != null ? employee.Employee.Id : 0;
                _sessionHandler.SetSessionKey(SessionOptions.UserId, result.User.Id.ToString());
            }
                

            return result;
        }
    }
}
