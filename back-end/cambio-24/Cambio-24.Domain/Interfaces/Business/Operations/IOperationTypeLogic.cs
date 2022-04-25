using Combio_24.Model.OperationTypeModels;

namespace Cambio_24.Domain.Interfaces.Business.Operations
{
    public interface IOperationTypeLogic
    {
        OperationTypeResponse Get();
        OperationTypeResponse Get(long id);
        OperationTypeResponse Get(string Code);
        OperationTypeResponse Insert(OperationTypeRequest operationType);
        OperationTypeResponse Update(OperationTypeRequest operationType);
        OperationTypeResponse Delete(long id);
    }
}
