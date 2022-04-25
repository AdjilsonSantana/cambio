using Combio_24.Model.OperationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cambio_24.Framework.Interfaces
{
    public interface IOperationFramework
    {
        OperationResponse Get();
        OperationResponse Get(long id);
        OperationResponse Insert(OperationRequest operation);
        OperationResponse Update(OperationRequest operation);
        OperationResponse Delete(long id);
    }
}
