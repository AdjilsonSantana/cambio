using Cambio_24.Domain.Constants;
using Cambio_24.Framework.Interfaces;
using Cambio_24.Models.UserModels;
using Cambio_24.WebApi.Sesson;
using Cambio_24.WebApi.Sesson.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Cambio_24.WebApi.Controllers.User
{
    [Authorize]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserFramework _user;
        private readonly ISessionHandler _sessionHandler;

        public UserController(IUserFramework user,
            ISessionHandler sessionHandler)
        {
            _user = user;
            _sessionHandler = sessionHandler;
        }

        [HttpGet("api/v1/user")]
        public UserResponse Get()
        {
            if (!ModelState.IsValid)
            {
                return null;
            }

            try
            {
                if (!this.User.Identity.IsAuthenticated)
                    return new UserResponse() { Success = false, Message = "Utilizador não autorizado" };
                //var userId = Convert.ToInt32(_sessionHandler.GetSessionKey(SessionOptions.UserId));
                return _user.Get();
            }
            catch (Exception)
            {

                return new UserResponse() { Success = false, Message = "Ocorreu um erro. Tente novemente mais tarde!" };
            }
        }

        [HttpGet]
        [Route("api/v1/user/{id}", Name = "GetWithId")]
        public UserResponse Get(long id)
        {
            if (!ModelState.IsValid)
            {
                return null;
            }

            try
            {
                if (!this.User.Identity.IsAuthenticated)
                    return new UserResponse() { Success = false, Message = "Utilizador não autorizado" };
                //var userId = Convert.ToInt32(_sessionHandler.GetSessionKey(SessionOptions.UserId));
                return _user.Get(id);
            }
            catch (Exception)
            {

                return new UserResponse() { Success = false, Message = "Ocorreu um erro. Tente novemente mais tarde!" };
            }
        }

        [HttpGet("api/v1/user/GetByEmailOrUsername")]
        public UserResponse GetByEmailOrUsername(string emailOrUsename)
        {
            if (!ModelState.IsValid)
            {
                return null;
            }

            try
            {
                if (!this.User.Identity.IsAuthenticated)
                    return new UserResponse() { Success = false, Message = "Utilizador não autorizado" };
                //var userId = Convert.ToInt32(_sessionHandler.GetSessionKey(SessionOptions.UserId));

                return _user.GetByEmailOrUsername(emailOrUsename);
            }
            catch (Exception)
            {

                return new UserResponse() { Success = false, Message = "Ocorreu um erro. Tente novemente mais tarde!" };
            }
        }

        [HttpPost("api/v1/user")]
        public UserResponse Post([FromBody] UserRequest user)
        {
            if (!ModelState.IsValid)
            {
                return null;
            }

            try
            {
                if (!this.User.Identity.IsAuthenticated)
                    return new UserResponse() { Success = false, Message = "Utilizador não autorizado" };
                //var userId = Convert.ToInt32(_sessionHandler.GetSessionKey(SessionOptions.UserId));
                //var admin = _user.Get(userId);
                if (this.User.IsInRole(RoleConstants.Admin))
                {
                    return _user.Insert(user, RoleConstants.Admin);
                }
                return _user.Insert(user, "");
            }
            catch (Exception)
            {

                return new UserResponse() { Success = false, Message = "Ocorreu um erro. Tente novemente mais tarde!" };
            }
        }


        [HttpPut("api/v1/user")]
        public UserResponse Put([FromBody] UserRequest user)
        {
            if (!ModelState.IsValid)
            {
                return null;
            }

            try
            {
                if (!this.User.Identity.IsAuthenticated)
                    return new UserResponse() { Success = false, Message = "Utilizador não autorizado" };
                //var userId = Convert.ToInt32(_sessionHandler.GetSessionKey(SessionOptions.UserId));
                return _user.Update(user);
            }
            catch (Exception)
            {

                return new UserResponse() { Success = false, Message = "Ocorreu um erro. Tente novemente mais tarde!" };
            }
        }


        [HttpDelete("api/v1/user/{id}")]
        public UserResponse Delete(long id)
        {
            UserResponse response = new UserResponse() { Success = false, Message = "Utilizador não autorizado" };
            if (!ModelState.IsValid)
            {
                return null;
            }

            try
            {
                if (!this.User.Identity.IsAuthenticated)
                    return response;

                if (this.User.IsInRole(RoleConstants.Admin))
                    return _user.Delete(id);

                return response;


            }
            catch (Exception)
            {
                response.Message = "Ocorreu um erro. Tente novemente mais tarde!";
                return response;
            }
        }
    }
}
