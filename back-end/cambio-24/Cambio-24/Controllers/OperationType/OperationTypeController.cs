using Cambio_24.Framework.Interfaces;
using Cambio_24.WebApi.Sesson;
using Cambio_24.WebApi.Sesson.Interface;
using Combio_24.Model.OperationTypeModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Cambio_24.Controllers.OperationType
{
    [Authorize]
    [ApiController]
    public class OperationTypeController : ControllerBase
    {
        private readonly IOperationTypeFramework _operationTypeFramework;
        private readonly ISessionHandler _sessionHandler;
        public OperationTypeController(IOperationTypeFramework operationTypeFramework,
            ISessionHandler sessionHandler)
        {
            _operationTypeFramework = operationTypeFramework;
            _sessionHandler = sessionHandler;
        }

        [HttpGet("api/v1/operationType")]
        public OperationTypeResponse Get()
        {
            if (!ModelState.IsValid)
            {
                return null;
            }

            try
            {
                if (!this.User.Identity.IsAuthenticated)
                    return new OperationTypeResponse() { Success = false, Message = "Utilizador não autorizado" };
               // var userId = Convert.ToInt32(_sessionHandler.GetSessionKey(SessionOptions.UserId));
                return _operationTypeFramework.Get();
            }
            catch (Exception)
            {

                return new OperationTypeResponse() { Success = false, Message = "Ocorreu um erro. Tente novemente mais tarde!" };
            }
        }

        [HttpGet]
        [Route("api/v1/operationType/{id}", Name = "GetWithOpTypeId")]
        public OperationTypeResponse Get(long id)
        {
            if (!ModelState.IsValid)
            {
                return null;
            }

            try
            {
                if (!this.User.Identity.IsAuthenticated)
                    return new OperationTypeResponse() { Success = false, Message = "Utilizador não autorizado" };
                //var userId = Convert.ToInt32(_sessionHandler.GetSessionKey(SessionOptions.UserId));
                return _operationTypeFramework.Get(id);
            }
            catch (Exception)
            {

                return new OperationTypeResponse() { Success = false, Message = "Ocorreu um erro. Tente novemente mais tarde!" };
            }
        }


        [HttpPost("api/v1/operationType")]
        public OperationTypeResponse Post([FromBody] OperationTypeRequest operationType)
        {
            if (!ModelState.IsValid)
            {
                return null;
            }

            try
            {
                if (!this.User.Identity.IsAuthenticated)
                    return new OperationTypeResponse() { Success = false, Message = "Utilizador não autorizado" };
                //var userId = Convert.ToInt32(_sessionHandler.GetSessionKey(SessionOptions.UserId));
                return _operationTypeFramework.Insert(operationType);
            }
            catch (Exception)
            {

                return new OperationTypeResponse() { Success = false, Message = "Ocorreu um erro. Tente novemente mais tarde!" };
            }
        }


        [HttpPut("api/v1/operationType")]
        public OperationTypeResponse Put([FromBody] OperationTypeRequest operationType)
        {
            if (!ModelState.IsValid)
            {
                return null;
            }

            try
            {
                if (!this.User.Identity.IsAuthenticated)
                    return new OperationTypeResponse() { Success = false, Message = "Utilizador não autorizado" };
                //var userId = Convert.ToInt32(_sessionHandler.GetSessionKey(SessionOptions.UserId));
                return _operationTypeFramework.Update(operationType);
            }
            catch (Exception)
            {

                return new OperationTypeResponse() { Success = false, Message = "Ocorreu um erro. Tente novemente mais tarde!" };
            }
        }


        [HttpDelete("api/v1/operationType/{id}")]
        public OperationTypeResponse Delete(long id)
        {
            if (!ModelState.IsValid)
            {
                return null;
            }

            try
            {
                if (!this.User.Identity.IsAuthenticated)
                    return new OperationTypeResponse() { Success = false, Message = "Utilizador não autorizado" };
                //var userId = Convert.ToInt32(_sessionHandler.GetSessionKey(SessionOptions.UserId));
                return _operationTypeFramework.Delete(id);
            }
            catch (Exception)
            {

                return new OperationTypeResponse() { Success = false, Message = "Ocorreu um erro. Tente novemente mais tarde!" };
            }
        }
    }
}
