using Cambio_24.Domain.Entities;

namespace Cambio_24.Domain.Interfaces
{
    public interface IDocumentTypeRepository : IRepository<DocumentTypeEntity>
    {
        DocumentTypeEntity GetByCode(string docCode);
    }
}
