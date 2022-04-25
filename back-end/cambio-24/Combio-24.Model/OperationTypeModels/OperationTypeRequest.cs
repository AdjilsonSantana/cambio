using System.ComponentModel.DataAnnotations;

namespace Combio_24.Model.OperationTypeModels
{
    public class OperationTypeRequest
    {
        public long Id { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
