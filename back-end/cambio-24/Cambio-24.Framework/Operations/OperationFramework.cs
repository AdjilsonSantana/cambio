using Cambio_24.Domain.Interfaces.Business.Operations;
using Cambio_24.Framework.Interfaces;
using Combio_24.Model.OperationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cambio_24.Framework.Operations
{
    public class OperationFramework : IOperationFramework
    {
        private readonly IOperationLogic _operationLogic;
        public OperationFramework(IOperationLogic operationLogic)
        {
            _operationLogic = operationLogic;
        }

        public OperationResponse Delete(long id)
        {
            return _operationLogic.Delete(id);
        }

        public OperationResponse Get()
        {
            return _operationLogic.Get();
        }

        public OperationResponse Get(long id)
        {
            return _operationLogic.Get(id);
        }

        public OperationResponse Insert(OperationRequest operation)
        {
            return _operationLogic.Insert(operation);
        }

        public OperationResponse Update(OperationRequest operation)
        {
            return _operationLogic.Update(operation);
        }
    }
}
