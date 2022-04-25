using Cambio_24.WebApi.Sesson.Interface;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Cambio_24.WebApi.Sesson
{
    public class SessionHandler : ISessionHandler
    {
        private readonly IHttpContextAccessor _httpContext;

        public SessionHandler(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }

        public void SetSessionKey(SessionOptions option, string value)
        {
            _httpContext.HttpContext.Session.SetString(option.ToString(), value);
        }

        public string GetSessionKey(SessionOptions option)
        {
            try
            {
                var value = _httpContext.HttpContext.Session.GetString(option.ToString());
                return value ?? "";
            }
            catch (Exception)
            {
                return "";
            }
        }
    }
}
