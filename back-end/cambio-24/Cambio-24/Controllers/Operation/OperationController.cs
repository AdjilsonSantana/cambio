using Cambio_24.Framework.Interfaces;
using Cambio_24.WebApi.Sesson;
using Cambio_24.WebApi.Sesson.Interface;
using Combio_24.Model.OperationModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Cambio_24.Controllers.Operation
{
    [Authorize]
    [ApiController]
    public class OperationController : ControllerBase
    {
        private readonly IOperationFramework _operationFramework;
        private readonly ISessionHandler _sessionHandler;
        public OperationController(IOperationFramework operationFramework,
            ISessionHandler sessionHandler)
        {
            _operationFramework = operationFramework;
            _sessionHandler = sessionHandler;
        }

        [HttpGet("api/v1/operation")]
        public OperationResponse Get()
        {
            if (!ModelState.IsValid)
            {
                return null;
            }

            try
            {
                if (!this.User.Identity.IsAuthenticated)
                    return new OperationResponse() { Success = false, Message = "Utilizador não autorizado" };

                //var userId = Convert.ToInt32(_sessionHandler.GetSessionKey(SessionOptions.UserId));
                return _operationFramework.Get();
            }
            catch (Exception)
            {

                return new OperationResponse() { Success = false, Message = "Ocorreu um erro. Tente novemente mais tarde!" };
            }
        }

        [HttpGet]
        [Route("api/v1/operation/{id}", Name = "GetWithOpId")]
        public OperationResponse Get(long id)
        {
            if (!ModelState.IsValid)
            {
                return null;
            }

            try
            {
                if (!this.User.Identity.IsAuthenticated)
                    return new OperationResponse() { Success = false, Message = "Utilizador não autorizado" };
                // var userId = Convert.ToInt32(_sessionHandler.GetSessionKey(SessionOptions.UserId));
                return _operationFramework.Get(id);
            }
            catch (Exception)
            {

                return new OperationResponse() { Success = false, Message = "Ocorreu um erro. Tente novemente mais tarde!" };
            }
        }


        [HttpPost("api/v1/operation")]
        public OperationResponse Post([FromBody] OperationRequest operation)
        {
            if (!ModelState.IsValid)
            {
                return null;
            }

            try
            {
                if (!this.User.Identity.IsAuthenticated)
                    return new OperationResponse() { Success = false, Message = "Utilizador não autorizado" };
                //var userId = Convert.ToInt32(_sessionHandler.GetSessionKey(SessionOptions.UserId));
                return _operationFramework.Insert(operation);
            }
            catch (Exception)
            {

                return new OperationResponse() { Success = false, Message = "Ocorreu um erro. Tente novemente mais tarde!" };
            }
        }

        [Authorize(Roles = "Admin,Owner")]
        [HttpPut("api/v1/operation")]
        public OperationResponse Put([FromBody] OperationRequest operation)
        {
            if (!ModelState.IsValid)
            {
                return null;
            }

            try
            {
                if (!this.User.Identity.IsAuthenticated)
                    return new OperationResponse() { Success = false, Message = "Utilizador não autorizado" };
                //var userId = Convert.ToInt32(_sessionHandler.GetSessionKey(SessionOptions.UserId));
                return _operationFramework.Update(operation);
            }
            catch (Exception)
            {

                return new OperationResponse() { Success = false, Message = "Ocorreu um erro. Tente novemente mais tarde!" };
            }
        }

        [Authorize(Roles ="Admin,Owner")]
        [HttpDelete("api/v1/operation/{id}")]
        public OperationResponse Delete(long id)
        {
            if (!ModelState.IsValid)
            {
                return null;
            }

            try
            {
                if (!this.User.Identity.IsAuthenticated)
                    return new OperationResponse() { Success = false, Message = "Utilizador não autorizado" };
                //var userId = Convert.ToInt32(_sessionHandler.GetSessionKey(SessionOptions.UserId));
                return _operationFramework.Delete(id);
            }
            catch (Exception)
            {
                return new OperationResponse() { Success = false, Message = "Ocorreu um erro. Tente novemente mais tarde!" };
            }
        }
    }
}
