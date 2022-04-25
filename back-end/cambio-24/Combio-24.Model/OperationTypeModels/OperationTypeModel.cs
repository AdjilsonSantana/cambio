using System;

namespace Combio_24.Model.OperationTypeModels
{
    public class OperationTypeModel
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
