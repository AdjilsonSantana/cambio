using Cambio_24.Models.Generics;
using System.Collections.Generic;

namespace Combio_24.Model.OperationModels
{
    public class OperationResponse : GenericResult
    {
        public OperationModel Operation { get; set; }
        public IEnumerable<OperationModel> Operations { get; set; }
    }
}
