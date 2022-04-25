using Cambio_24.Security.Authentication;
using Cambio_24.WebApi.Sesson;
using Cambio_24.WebApi.Sesson.Interface;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;

namespace Cambio_24.WebApi.Middleware
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ISessionHandler _sessionHandler;

        public JwtMiddleware(ISessionHandler sessionHandler, RequestDelegate next)
        {
            _next = next;
            _sessionHandler = sessionHandler;
        }

        public async Task Invoke(HttpContext context)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token != null)
                AttachUserToContext(context, token);

            await _next(context);
        }

        private void AttachUserToContext(HttpContext context, string token)
        {
            try
            {
                var jwtHandler = new JwtHandler();
                var tokenContent = jwtHandler.GetTokenContent(token);

                var userId = _sessionHandler.GetSessionKey(SessionOptions.UserId);
                var tokenUserId = tokenContent.UserId;

                // attach user to context on successful jwt validation

                if (string.IsNullOrEmpty(userId))
                    userId = tokenUserId;

                if (userId.Equals(tokenUserId))
                    context.Session.SetString(SessionOptions.UserId.ToString(), tokenContent.UserId);
            }
            catch
            {
                // do nothing if jwt validation fails
                // user is not attached to context so request won't have access to secure routes
            }
        }
    }
}
