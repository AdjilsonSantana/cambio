using Cambio_24.Models.Generics;
using Cambio_24.Models.UserModels;

namespace Cambio_24.Models.AuthenticationModels
{
    public class AuthenticationResponse : GenericResult
    {
        public UserModel User { get; set; }
        public string Token { get; set; }
        public bool FirstAccess { get; set; }
        public long EmployeeId { get; set; }
    }
}
