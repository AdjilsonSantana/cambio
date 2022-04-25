using Cambio_24.Framework.Interfaces;
using Cambio_24.WebApi.Sesson;
using Cambio_24.WebApi.Sesson.Interface;
using Combio_24.Model.RatesModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Cambio_24.Controllers.Rate
{
    [Authorize]
    [ApiController]
    public class RateController : ControllerBase
    {
        private readonly IRateFramework _rateFramework;
        private readonly ISessionHandler _sessionHandler;
        public RateController(IRateFramework rateFramework,
            ISessionHandler sessionHandler)
        {
            _rateFramework = rateFramework;
            _sessionHandler = sessionHandler;
        }

        [HttpGet("api/v1/rate")]
        public RateResponse Get()
        {
            if (!ModelState.IsValid)
            {
                return null;
            }

            try
            {
                if (this.User.Identity.IsAuthenticated)
                {
                    return _rateFramework.Get();
                } 
                else
                {
                    return new RateResponse() { Success = false, Message = "Utilizador não autorizado!" };
                }
                //var userId = Convert.ToInt32(_sessionHandler.GetSessionKey(SessionOptions.UserId));
               
            }
            catch (Exception)
            {

                return new RateResponse() { Success = false, Message = "Ocorreu um erro. Tente novamente mais tarde." };
            }
        }

        [HttpGet]
        [Route("api/v1/rate/{id}", Name = "GetWithRateId")]
        public RateResponse Get(long id)
        {
            if (!ModelState.IsValid)
            {
                return null;
            }

            try
            {
                //var userId = Convert.ToInt32(_sessionHandler.GetSessionKey(SessionOptions.UserId));
               

                if (this.User.Identity.IsAuthenticated)
                {
                    return _rateFramework.Get(id);
                }
                else
                {
                    return new RateResponse() { Success = false, Message = "Utilizador não autorizado!" };
                }
            }
            catch (Exception)
            {

                return new RateResponse() { Success = false, Message = "Ocorreu um erro. Tente novamente mais tarde." };
            }
        }


        [HttpGet("api/v1/ratecode/{rateCode}", Name = "GetWithRateCode")]
        public RateResponse GetByCode(string code)
        {
            if (!ModelState.IsValid)
            {
                return null;
            }

            try
            {
                //var userId = Convert.ToInt32(_sessionHandler.GetSessionKey(SessionOptions.UserId));

                if (this.User.Identity.IsAuthenticated)
                {
                    return _rateFramework.GetByCode(code);
                }
                else
                {
                    return new RateResponse() { Success = false, Message = "Utilizador não autorizado!" };
                }
                
            }
            catch (Exception)
            {

                return new RateResponse() { Success = false, Message = "Ocorreu um erro. Tente novamente mais tarde." };
            }
        }


        [HttpPost("api/v1/rate")]
        public RateResponse Post([FromBody] RateRequest rate)
        {
            if (!ModelState.IsValid)
            {
                return null;
            }

            try
            {
                //var userId = Convert.ToInt32(_sessionHandler.GetSessionKey(SessionOptions.UserId));
                

                if (this.User.Identity.IsAuthenticated)
                {
                    return _rateFramework.Insert(rate);
                }
                else
                {
                    return new RateResponse() { Success = false, Message = "Utilizador não autorizado!" };
                }
            }
            catch (Exception)
            {

                return new RateResponse() { Success = false, Message = "Ocorreu um erro. Tente novamente mais tarde." };
            }
        }


        [HttpPut("api/v1/rate")]
        public RateResponse Put([FromBody] RateRequest rate)
        {
            if (!ModelState.IsValid)
            {
                return null;
            }

            try
            {

                if (this.User.Identity.IsAuthenticated)
                {
                    return _rateFramework.Update(rate);
                }
                else
                {
                    return new RateResponse() { Success = false, Message = "Utilizador não autorizado!" };
                }
               //var userId = Convert.ToInt32(_sessionHandler.GetSessionKey(SessionOptions.UserId));
                
            }
            catch (Exception)
            {

                return new RateResponse() { Success = false, Message = "Ocorreu um erro. Tente novamente mais tarde." };
            }
        }

        [Authorize(Roles ="Admin")]
        [HttpPut("api/v1/updateBalance")]
        public RateResponse Put([FromBody] List<RateModel> rates)
        {
            if (!ModelState.IsValid)
            {
                return null;
            }

            try
            {

                if (this.User.Identity.IsAuthenticated)
                {
                    return _rateFramework.UpdateBalance(rates);
                }
                else
                {
                    return new RateResponse() { Success = false, Message = "Utilizador não autorizado!" };
                }
               
                
            }
            catch (Exception)
            {

                return new RateResponse() { Success = false, Message = "Ocorreu um erro. Tente novamente mais tarde." };
            }
        }


        [HttpDelete("api/v1/rate/{id}")]
        public RateResponse Delete(long id)
        {
            if (!ModelState.IsValid)
            {
                return null;
            }


            try
            {
                //var userId = Convert.ToInt32(_sessionHandler.GetSessionKey(SessionOptions.UserId));

                if (this.User.Identity.IsAuthenticated)
                {
                    return _rateFramework.Delete(id);
                }
                else
                {
                    return new RateResponse() { Success = false, Message = "Utilizador não autorizado!" };
                }
                
            }
            catch (Exception)
            {
                return new RateResponse() { Success = false, Message = "Ocorreu um erro. Tente novamente mais tarde." };
            }
        }

    }
}
