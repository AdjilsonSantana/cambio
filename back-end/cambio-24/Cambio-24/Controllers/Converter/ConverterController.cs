using Cambio_24.Domain.Helper.Interface;
using Cambio_24.WebApi.Sesson;
using Cambio_24.WebApi.Sesson.Interface;
using Combio_24.Model.Converter;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Cambio_24.Controllers.Converter
{
    [Authorize]
    [ApiController]
    public class ConverterController : ControllerBase
    {
        private readonly IConverterCalc _converterCalc;
        private readonly ISessionHandler _sessionHandler;
        public ConverterController(IConverterCalc converterCalc,
            ISessionHandler sessionHandler)
        {
            _sessionHandler = sessionHandler;
            _converterCalc = converterCalc;
        }

        [HttpPost("api/v1/conversion")]
        public ConverterResult Post([FromBody] ConverterInput input)
        {
            if (!ModelState.IsValid)
            {
                return null;
            }

            if (!this.User.Identity.IsAuthenticated)
            {
                return new ConverterResult() { Success = false, Message = "Utilizador não autorizado!" };
            }

            try
            {
                //var user = this.User.Identity.IsAuthenticated;
                //var userId = Convert.ToInt32(_sessionHandler.GetSessionKey(SessionOptions.UserId));
                return _converterCalc.Conversion(input);
            }
            catch (Exception ex)
            {

                return new ConverterResult() { Success = false, Message = "Ocorreu um erro. Tente novamente!" };
            }
        }
    }
}
