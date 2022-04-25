using Cambio_24.Framework.Interfaces;
using Cambio_24.WebApi.Sesson.Interface;
using Combio_24.Model.ClientModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Cambio_24.Controllers.Client
{
    [Authorize]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClientFramework _clientFramework;
        private readonly ISessionHandler _sessionHandler;
        private readonly IUserFramework _userFramework;
        public ClientsController(IClientFramework clientFramework,
            ISessionHandler sessionHandler,
            IUserFramework userFramework)
        {
            _clientFramework = clientFramework;
            _sessionHandler = sessionHandler;
            _userFramework = userFramework;
        }


        [HttpGet("api/v1/client")]
        public ClientResponse Get()
        {
            if (!ModelState.IsValid)
            {
                return null;
            }

            try
            {
                if (this.User.Identity.IsAuthenticated)
                {
                    return _clientFramework.Get();
                }
                else
                {
                    return new ClientResponse() { Success = false, Message = "Utilizador não autorizado!" };
                }

            }
            catch (Exception ex)
            {

                return new ClientResponse() { Success = false, Message = "Ocorreu um erro. Tente novamente." };
            }
        }

        [HttpGet]
        [Route("api/v1/client/{id}", Name = "GetWithClientId")]
        public ClientResponse Get(long id)
        {
            if (!ModelState.IsValid)
            {
                return null;
            }

            try
            {

                if (this.User.Identity.IsAuthenticated)
                {
                    return _clientFramework.Get(id);
                }
                else
                {
                    return new ClientResponse() { Success = false, Message = "Utilizador não autorizado!" };
                }
            }
            catch (Exception)
            {

                return new ClientResponse() { Success = false, Message = "Ocorreu um erro. Tente novamente." };
            }
        }


        [HttpGet("api/v1/client/getByDocNumberOrNif", Name = "GetWithCliDocOrNif")]
        public ClientResponse GetByDocNumberOrNif(string docOrnif)
        {
            if (!ModelState.IsValid)
            {
                return null;
            }

            try
            {
                if (this.User.Identity.IsAuthenticated)
                {
                    return _clientFramework.GetByDocNumberOrNif(docOrnif);
                }
                else
                {
                    return new ClientResponse() { Success = false, Message = "Utilizador não autorizado!" };
                }

            }
            catch (Exception)
            {

                return new ClientResponse() { Success = false, Message = "Ocorreu um erro. Tente novamente." };
            }
        }

        [HttpPost("api/v1/client")]
        public ClientResponse Post([FromBody] ClientRequest client)
        {
            if (!ModelState.IsValid)
            {
                return null;
            }

            try
            {
                if (this.User.Identity.IsAuthenticated)
                {
                    return _clientFramework.Insert(client);
                }
                else
                {
                    return new ClientResponse() { Success = false, Message = "Utilizador não autorizado!" };
                }

            }
            catch (Exception)
            {

                return new ClientResponse() { Success = false, Message = "Ocorreu um erro. Tente novamente." };
            }
        }


        [HttpPut("api/v1/client")]
        public ClientResponse Put([FromBody] ClientRequest client)
        {
            if (!ModelState.IsValid)
            {
                return null;
            }

            try
            {
                if (this.User.Identity.IsAuthenticated)
                {
                    return _clientFramework.Update(client);
                }
                else
                {
                    return new ClientResponse() { Success = false, Message = "Utilizador não autorizado!" };
                }
                //var userId = Convert.ToInt32(_sessionHandler.GetSessionKey(SessionOptions.UserId));

            }
            catch (Exception)
            {

                return new ClientResponse() { Success = false, Message = "Ocorreu um erro. Tente novamente." };
            }
        }


        [HttpDelete("api/v1/client/{id}")]
        public ClientResponse Delete(long id)
        {
            if (!ModelState.IsValid)
            {
                return null;
            }

            try
            {
                if (this.User.Identity.IsAuthenticated)
                {
                    return _clientFramework.Delete(id);
                }
                else
                {
                    return new ClientResponse() { Success = false, Message = "Utilizador não autorizado!" };
                }
                //var userId = Convert.ToInt32(_sessionHandler.GetSessionKey(SessionOptions.UserId));

            }
            catch (Exception)
            {

                return new ClientResponse() { Success = false, Message = "Ocorreu um erro. Tente novamente." };
            }
        }
    }
}
