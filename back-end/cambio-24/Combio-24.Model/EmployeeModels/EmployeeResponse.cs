using Cambio_24.Models.Generics;
using System.Collections.Generic;

namespace Combio_24.Model.EmployeeModels
{
    public class EmployeeResponse : GenericResult
    {
        public EmployeeModel Employee { get; set; }
        public IEnumerable<EmployeeModel> Employees { get; set; }
    }
}
