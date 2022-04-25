using Combio_24.Model.OperationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cambio_24.Domain.Interfaces.Business.Operations
{
    public interface IOperationLogic
    {
        OperationResponse Get();
        OperationResponse Get(long id);
        OperationResponse Insert(OperationRequest operation);
        OperationResponse Update(OperationRequest operation);
        OperationResponse Delete(long id);
    }
}
