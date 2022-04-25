using Combio_24.Model.DocumentTypeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cambio_24.Framework.Interfaces
{
    public interface IDocumentTypeFramework
    {
        DocumentTypeResponse Get();
        DocumentTypeResponse Get(long id);
        DocumentTypeResponse GetByCode(string docCode);
        DocumentTypeResponse Insert(DocumentTypeRequest docType);
        DocumentTypeResponse Update(DocumentTypeRequest docType);
        DocumentTypeResponse Delete(long id);
    }
}
