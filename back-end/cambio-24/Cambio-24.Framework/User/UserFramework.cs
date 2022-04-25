using Cambio_24.Domain.Interfaces.Business.User;
using Cambio_24.Framework.Interfaces;
using Cambio_24.Models.UserModels;

namespace Cambio_24.Framework.User
{
    public class UserFramework : IUserFramework
    {
        private readonly IUserLogic _userLogic;
        public UserFramework(IUserLogic userLogic)
        {
            _userLogic = userLogic;
        }

        public UserResponse Get()
        {
            return _userLogic.Get();
        }

        public UserResponse Get(long id)
        {
            return _userLogic.Get(id);
        }

        public UserResponse GetByEmailOrUsername(string email)
        {
            return _userLogic.GetByEmailOrUsername(email);
        }

        public UserResponse Insert(UserRequest user, string role)
        {
            return _userLogic.Insert(user,role);
        }

        public UserResponse Update(UserRequest user)
        {
            return _userLogic.Update(user);
        }
        public UserResponse Delete(long id)
        {
            return _userLogic.Delete(id);
        }

    }
}
