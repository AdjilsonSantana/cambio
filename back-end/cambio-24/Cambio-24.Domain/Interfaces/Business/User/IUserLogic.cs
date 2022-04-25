using Cambio_24.Models.UserModels;
using System;

namespace Cambio_24.Domain.Interfaces.Business.User
{
    public interface IUserLogic
    {
        UserResponse Get();
        UserResponse Get(long id);
        UserResponse GetByEmailOrUsername(string email);
        UserResponse Insert(UserRequest user, string role);
        UserResponse Update(UserRequest user);
        UserResponse Delete(long id);
    }
}
