using Cambio_24.Data.Context;
using Cambio_24.Domain.Entities;
using Cambio_24.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Cambio_24.Data.Repository
{
    public class DocumentTypeRepository : Repository<DocumentTypeEntity>, IDocumentTypeRepository
    {
        private readonly DbSet<DocumentTypeEntity> _dataset;
        public DocumentTypeRepository(Cambio24Context context) : base(context)
        {
            _dataset = _context.Set<DocumentTypeEntity>();
        }

        public DocumentTypeEntity GetByCode(string docCode)
        {
            try
            {
                return _dataset.SingleOrDefault(d => d.DocTypeCode.Equals(docCode));
            }
            catch (Exception ex)
            {

                return null;
            }
        }
    }
}
