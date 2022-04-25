using Cambio_24.Domain.Interfaces.Business.Operations;
using Cambio_24.Framework.Interfaces;
using Combio_24.Model.OperationTypeModels;

namespace Cambio_24.Framework.Operations
{
    public class OperationTypeFramework : IOperationTypeFramework
    {
        private readonly IOperationTypeLogic _operationTypeLogic;
        public OperationTypeFramework(IOperationTypeLogic operationTypeLogic)
        {
            _operationTypeLogic = operationTypeLogic;
        }

        public OperationTypeResponse Delete(long id)
        {
            return _operationTypeLogic.Delete(id);
        }

        public OperationTypeResponse Get()
        {
            return _operationTypeLogic.Get();
        }

        public OperationTypeResponse Get(long id)
        {
            return _operationTypeLogic.Get(id);
        }

        public OperationTypeResponse Insert(OperationTypeRequest operationType)
        {
            return _operationTypeLogic.Insert(operationType);
        }

        public OperationTypeResponse Update(OperationTypeRequest operationType)
        {
            return _operationTypeLogic.Update(operationType);
        }
    }
}
