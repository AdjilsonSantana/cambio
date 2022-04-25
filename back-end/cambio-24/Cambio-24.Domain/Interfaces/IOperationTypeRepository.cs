using Cambio_24.Domain.Entities;
using Combio_24.Model.OperationTypeModels;

namespace Cambio_24.Domain.Interfaces
{
    public interface IOperationTypeRepository : IRepository<OperationTypeEntity>
    {
        bool Exists(OperationTypeRequest operationType);

        OperationTypeEntity Get(string code);
    }
}
