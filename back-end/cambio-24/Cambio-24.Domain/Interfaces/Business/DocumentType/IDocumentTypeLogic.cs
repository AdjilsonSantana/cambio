using Combio_24.Model.DocumentTypeModels;

namespace Cambio_24.Domain.Interfaces.Business.DocumentType
{
    public interface IDocumentTypeLogic
    {
        DocumentTypeResponse Get();
        DocumentTypeResponse Get(long id);
        DocumentTypeResponse GetByCode(string docCode);
        DocumentTypeResponse Insert(DocumentTypeRequest docType);
        DocumentTypeResponse Update(DocumentTypeRequest docType);
        DocumentTypeResponse Delete(long id);
    }
}
