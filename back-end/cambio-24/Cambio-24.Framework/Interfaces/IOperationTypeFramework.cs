using Combio_24.Model.OperationTypeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cambio_24.Framework.Interfaces
{
    public interface IOperationTypeFramework
    {
        OperationTypeResponse Get();
        OperationTypeResponse Get(long id);
        OperationTypeResponse Insert(OperationTypeRequest operationType);
        OperationTypeResponse Update(OperationTypeRequest operationType);
        OperationTypeResponse Delete(long id);
    }
}
