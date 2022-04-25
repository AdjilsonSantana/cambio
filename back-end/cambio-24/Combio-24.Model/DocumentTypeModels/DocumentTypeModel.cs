using System;

namespace Combio_24.Model.DocumentTypeModels
{
    public class DocumentTypeModel
    {
        public long Id { get; set; }
        public string DocTypeCode { get; set; }
        public string DocDescription { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}