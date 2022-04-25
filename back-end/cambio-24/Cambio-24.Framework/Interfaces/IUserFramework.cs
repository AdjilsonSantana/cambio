using Cambio_24.Models.UserModels;

namespace Cambio_24.Framework.Interfaces
{
    public interface IUserFramework
    {
        UserResponse Get();
        UserResponse Get(long id);
        UserResponse GetByEmailOrUsername(string email);
        UserResponse Insert(UserRequest user, string role);
        UserResponse Update(UserRequest user);
        UserResponse Delete(long id);
    }
}
