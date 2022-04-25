using System.ComponentModel.DataAnnotations;

namespace Combio_24.Model.DocumentTypeModels
{
    public class DocumentTypeRequest
    {
        public long Id { get; set; }
        [Required]
        public string DocTypeCode { get; set; }
        [Required]
        public string DocDescription { get; set; }
    }
}
