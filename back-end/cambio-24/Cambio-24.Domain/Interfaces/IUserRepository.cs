using Cambio_24.Domain.Entities;

namespace Cambio_24.Domain.Interfaces
{
    public interface IUserRepository : IRepository<UserEntity>
    {
        UserEntity GetByEmailOrUsername(string email);
        bool UpdateDateLastAccess(string email);
    }
}
