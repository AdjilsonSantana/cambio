using Cambio_24.Domain.Constants;
using Cambio_24.Framework.Interfaces;
using Cambio_24.WebApi.Sesson;
using Cambio_24.WebApi.Sesson.Interface;
using Combio_24.Model.EmployeeModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Cambio_24.Controllers.Employee
{
    [Authorize]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeFramework _employeeFramework;
        private readonly ISessionHandler _sessionHandler;
        private readonly IUserFramework _userFramework;
        public EmployeesController(
            IEmployeeFramework employeeFramework,
            ISessionHandler sessionHandler,
            IUserFramework userFramework)
        {
            _employeeFramework = employeeFramework;
            _sessionHandler = sessionHandler;
            _userFramework = userFramework;
        }

        [HttpGet("api/v1/employee")]
        public EmployeeResponse Get()
        {
            if (!ModelState.IsValid)
            {
                return null;
            }

            try
            {
                if (!this.User.Identity.IsAuthenticated)
                    return new EmployeeResponse() { Success = false, Message = "Utilizador não autorizado." };
                //var userId = Convert.ToInt32(_sessionHandler.GetSessionKey(SessionOptions.UserId));
                return _employeeFramework.Get();
            }
            catch (Exception)
            {

                return new EmployeeResponse() { Success = false, Message = "Ocorreu um erro. Tente novamente mais tarde." };
            }
        }

        [HttpGet]
        [Route("api/v1/employee/{id}", Name = "GetWithEmployeeId")]
        public EmployeeResponse Get(long id)
        {
            if (!ModelState.IsValid)
            {
                return null;
            }

            try
            {
                if (!this.User.Identity.IsAuthenticated)
                    return new EmployeeResponse() { Success = false, Message = "Utilizador não autorizado." };
                //var userId = Convert.ToInt32(_sessionHandler.GetSessionKey(SessionOptions.UserId));
                return _employeeFramework.Get(id);
            }
            catch (Exception)
            {

                return new EmployeeResponse() { Success = false, Message = "Ocorreu um erro. Tente novamente mais tarde." };
            }
        }


        [HttpGet("api/v1/employee/getByUser", Name = "GetWithUser")]
        public EmployeeResponse GetByUser()
        {
            if (!ModelState.IsValid)
            {
                return null;
            }

            try
            {
                if (!this.User.Identity.IsAuthenticated)
                    return new EmployeeResponse() { Success = false, Message = "Utilizador não autorizado" };
                //var userId = Convert.ToInt32(_sessionHandler.GetSessionKey(SessionOptions.UserId));
                return _employeeFramework.GetByUser(this.User.Identity.Name);
            }
            catch (Exception)
            {

                return new EmployeeResponse() { Success = false, Message = "Ocorreu um erro. Tente novamente mais tarde." };
            }
        }


        [HttpGet("api/v1/employee/getByDocNumberOrNif", Name = "GetWithDocOrNif")]
        public EmployeeResponse GetByDocNumberOrNif(string docOrnif)
        {
            if (!ModelState.IsValid)
            {
                return null;
            }

            try
            {
                if (!this.User.Identity.IsAuthenticated)
                    return new EmployeeResponse() { Success = false, Message = "Utilizador não autorizado" };

                return _employeeFramework.GetByDocNumberOrNif(docOrnif);
            }
            catch (Exception)
            {

                return new EmployeeResponse() { Success = false, Message = "Ocorreu um erro. Tente novamente mais tarde." };
            }
        }

        [HttpPost("api/v1/employee")]
        public EmployeeResponse Post([FromBody] EmployeeRequest employee)
        {
            EmployeeResponse response = new EmployeeResponse() { Success = false, Message = "Utilizador não autorizado" };
            if (!ModelState.IsValid)
            {
                return null;
            }

            try
            {
                if (!this.User.Identity.IsAuthenticated)
                    return response;

                //var userId = Convert.ToInt32(_sessionHandler.GetSessionKey(SessionOptions.UserId));
               // var admin = _userFramework.GetByEmailOrUsername(this.User.Identity.Name);
                if (this.User.IsInRole(RoleConstants.Admin) || this.User.IsInRole(RoleConstants.Owner))
                {
                    string role = this.User.IsInRole(RoleConstants.Admin) ? RoleConstants.Admin : RoleConstants.Owner;
                    return _employeeFramework.Insert(employee,role);
                }

                return response;
            }
            catch (Exception)
            {
                response.Message = "Ocorreu um erro. Tente novamente mais tarde.";

                return response;
            }
        }


        [HttpPut("api/v1/employee")]
        public EmployeeResponse Put([FromBody] EmployeeRequest employee)
        {
            EmployeeResponse response = new EmployeeResponse() { Success = false, Message = "Utilizador não autorizado" };
            if (!ModelState.IsValid)
            {
                return null;
            }

            try
            {
                if (!this.User.Identity.IsAuthenticated)
                    return response;
                //var userId = Convert.ToInt32(_sessionHandler.GetSessionKey(SessionOptions.UserId));
                //var admin = _userFramework.Get(userId);
                if (this.User.IsInRole(RoleConstants.Admin) || this.User.IsInRole(RoleConstants.Owner))
                {
                    return _employeeFramework.Update(employee);
                }

                return response;
            }
            catch (Exception)
            {
                response.Message = "Ocorreu um erro. Tente novamente mais tarde.";
                return response;
            }
        }


        [HttpDelete("api/v1/employee/{id}")]
        public EmployeeResponse Delete(long id)
        {
            EmployeeResponse response = new EmployeeResponse() { Success = false, Message = "Utilizador não autorizado" };
            if (!ModelState.IsValid)
            {
                return null;
            }

            try
            {
                if (!this.User.Identity.IsAuthenticated)
                    return response;
                //var userId = Convert.ToInt32(_sessionHandler.GetSessionKey(SessionOptions.UserId));
                //var admin = _userFramework.Get(userId);
                if (this.User.IsInRole(RoleConstants.Admin) || this.User.IsInRole(RoleConstants.Owner))
                {
                    return _employeeFramework.Delete(id);
                }

                return response;
                
            }
            catch (Exception)
            {

                return response;
            }
        }
    }
}
