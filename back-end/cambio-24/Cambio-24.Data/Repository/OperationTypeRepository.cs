using Cambio_24.Data.Context;
using Cambio_24.Domain.Entities;
using Cambio_24.Domain.Interfaces;
using Combio_24.Model.OperationTypeModels;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Cambio_24.Data.Repository
{
    public class OperationTypeRepository : Repository<OperationTypeEntity>, IOperationTypeRepository
    {
        private readonly DbSet<OperationTypeEntity> _dataset;
        public OperationTypeRepository(Cambio24Context context) : base(context)
        {
            _dataset = _context.Set<OperationTypeEntity>();
        }

        public bool Exists(OperationTypeRequest operationType)
        {
            try
            {
                return _dataset.Any(o => o.Description.Equals(operationType.Description));
            }
            catch (System.Exception)
            {

                return false;
            }
        }

        public OperationTypeEntity Get(string code)
        {
            try
            {
                return _dataset.SingleOrDefault(o => o.Code.Equals(code));
            }
            catch (System.Exception)
            {

                return null;
            }
        }
    }
}
