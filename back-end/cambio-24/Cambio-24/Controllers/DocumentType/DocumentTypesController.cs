using Cambio_24.Framework.Interfaces;
using Cambio_24.WebApi.Sesson.Interface;
using Combio_24.Model.DocumentTypeModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Cambio_24.Controllers.DocumentType
{
    [Authorize]
    [ApiController]
    public class DocumentTypesController : ControllerBase
    {
        private readonly IDocumentTypeFramework _documentTypeFramework;

        private readonly ISessionHandler _sessionHandler;

        public DocumentTypesController(IDocumentTypeFramework documentTypeFramework,
            ISessionHandler sessionHandler)
        {
            _sessionHandler = sessionHandler;
            _documentTypeFramework = documentTypeFramework;
        }

        [HttpGet("api/v1/documentType")]
        public DocumentTypeResponse Get()
        {
            if (!ModelState.IsValid)
            {
                return null;
            }

            try
            {
                if (!this.User.Identity.IsAuthenticated)
                    return new DocumentTypeResponse() { Success = false, Message = "Utilizador não autorizado" };
                //var userId = Convert.ToInt32(_sessionHandler.GetSessionKey(SessionOptions.UserId));
                return _documentTypeFramework.Get();
            }
            catch (Exception)
            {

                return new DocumentTypeResponse() { Success = false, Message = "Ocorreu um erro. Tente novamente mais tarde." };
            }
        }

        [HttpGet]
        [Route("api/v1/documentType/{id}", Name = "GetWithDocTypeId")]
        public DocumentTypeResponse Get(long id)
        {
            if (!ModelState.IsValid)
            {
                return null;
            }

            try
            {
                //var userId = Convert.ToInt32(_sessionHandler.GetSessionKey(SessionOptions.UserId));
                if (!this.User.Identity.IsAuthenticated)
                    return new DocumentTypeResponse() { Success = false, Message = "Utilizador não autorizado" };

                return _documentTypeFramework.Get(id);
            }
            catch (Exception)
            {

                return new DocumentTypeResponse() { Success = false, Message = "Ocorreu um erro. Tente novamente mais tarde." };
            }
        }


        [HttpGet("api/v1/documentType/{docCode}", Name = "GetWithDocCode")]
        public DocumentTypeResponse GetByCode(string docCode)
        {
            if (!ModelState.IsValid)
            {
                return null;
            }

            try
            {
                //var userId = Convert.ToInt32(_sessionHandler.GetSessionKey(SessionOptions.UserId));
                if (!this.User.Identity.IsAuthenticated)
                    return new DocumentTypeResponse() { Success = false, Message = "Utilizador não autorizado" };

                return _documentTypeFramework.GetByCode(docCode);
            }
            catch (Exception)
            {

                return new DocumentTypeResponse() { Success = false, Message = "Ocorreu um erro. Tente novamente mais tarde." };
            }
        }




        [HttpPost("api/v1/documentType")]
        public DocumentTypeResponse Post([FromBody] DocumentTypeRequest documentType)
        {
            if (!ModelState.IsValid)
            {
                return null;
            }

            try
            {
                if (!this.User.Identity.IsAuthenticated)
                    return new DocumentTypeResponse() { Success = false, Message = "Utilizador não autorizado" };

                return _documentTypeFramework.Insert(documentType);
            }
            catch (Exception)
            {

                return new DocumentTypeResponse() { Success = false, Message = "Ocorreu um erro. Tente novamente mais tarde." };
            }
        }


        [HttpPut("api/v1/documentType")]
        public DocumentTypeResponse Put([FromBody] DocumentTypeRequest documentType)
        {
            if (!ModelState.IsValid)
            {
                return null;
            }

            try
            {
                if (!this.User.Identity.IsAuthenticated)
                    return new DocumentTypeResponse() { Success = false, Message = "Utilizador não autorizado" };

                return _documentTypeFramework.Update(documentType);
            }
            catch (Exception)
            {

                return new DocumentTypeResponse() { Success = false, Message = "Ocorreu um erro. Tente novamente mais tarde." };
            }
        }


        [HttpDelete("api/v1/documentType/{id}")]
        public DocumentTypeResponse Delete(long id)
        {
            if (!ModelState.IsValid)
            {
                return null;
            }

            try
            {
                if (!this.User.Identity.IsAuthenticated)
                    return new DocumentTypeResponse() { Success = false, Message = "Utilizador não autorizado" };

                return _documentTypeFramework.Delete(id);
            }
            catch (Exception)
            {

                return new DocumentTypeResponse() { Success = false, Message = "Ocorreu um erro. Tente novamente mais tarde." };
            }
        }
    }
}
