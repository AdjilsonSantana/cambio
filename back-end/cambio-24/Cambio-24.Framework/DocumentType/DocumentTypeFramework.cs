using Cambio_24.Domain.Interfaces.Business.DocumentType;
using Cambio_24.Framework.Interfaces;
using Combio_24.Model.DocumentTypeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cambio_24.Framework.DocumentType
{
    public class DocumentTypeFramework : IDocumentTypeFramework
    {
        private IDocumentTypeLogic _documentTypeLogic;
        public DocumentTypeFramework(IDocumentTypeLogic documentTypeLogic)
        {
            _documentTypeLogic = documentTypeLogic;
        }
        public DocumentTypeResponse Delete(long id)
        {
            return _documentTypeLogic.Delete(id);
        }

        public DocumentTypeResponse Get()
        {
            return _documentTypeLogic.Get();
        }

        public DocumentTypeResponse Get(long id)
        {
            return _documentTypeLogic.Get(id);
        }

        public DocumentTypeResponse GetByCode(string docCode)
        {
            return _documentTypeLogic.GetByCode(docCode);
        }

        public DocumentTypeResponse Insert(DocumentTypeRequest docType)
        {
            return _documentTypeLogic.Insert(docType);
        }

        public DocumentTypeResponse Update(DocumentTypeRequest docType)
        {
            return _documentTypeLogic.Update(docType);
        }
    }
}
