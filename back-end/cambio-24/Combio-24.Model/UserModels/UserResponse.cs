using Cambio_24.Models.Generics;
using System.Collections.Generic;

namespace Cambio_24.Models.UserModels
{
    public class UserResponse : GenericResult
    {
        public UserModel User { get; set; }
        public IEnumerable<UserModel> Users { get; set; }
    }
}
