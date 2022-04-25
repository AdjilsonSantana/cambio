using Cambio_24.Domain.Entities;
using System;

namespace Cambio_24.Domain.Interfaces
{
    public interface IEmployeeRepository : IRepository<EmployeeEntity>
    {
        EmployeeEntity GetByUser(UserEntity userEntity);
        EmployeeEntity GetByDocNumberOrNif(string docOrnif);
    }
}
