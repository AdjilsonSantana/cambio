using Cambio_24.Domain.Entities;
using Cambio_24.Models.AuthenticationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cambio_24.Security.Interfaces
{
    public interface IJwtHandler
    {
        string GenerateToken(UserEntity user);
        AuthenticationModel GetTokenContent(string token);
    }
}

