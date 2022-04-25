using Cambio_24.Models.Generics;
using System.Collections.Generic;

namespace Combio_24.Model.DocumentTypeModels
{
    public class DocumentTypeResponse : GenericResult
    {
        public DocumentTypeModel DocumentType { get; set; }
        public IEnumerable<DocumentTypeModel> DocumentTypes { get; set; }
    }
}
