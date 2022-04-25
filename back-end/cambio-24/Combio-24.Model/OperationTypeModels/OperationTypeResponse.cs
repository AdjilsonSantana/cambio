using Cambio_24.Models.Generics;
using System.Collections.Generic;

namespace Combio_24.Model.OperationTypeModels
{
    public class OperationTypeResponse : GenericResult
    {
        public OperationTypeModel OperationType { get; set; }
        public IEnumerable<OperationTypeModel> OperationTypes { get; set; }
    }
}
