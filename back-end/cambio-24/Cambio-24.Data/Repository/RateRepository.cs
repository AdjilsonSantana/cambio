using Cambio_24.Data.Context;
using Cambio_24.Domain.Entities;
using Cambio_24.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Cambio_24.Data.Repository
{
    public class RateRepository : Repository<RateEntity>, IRateRepository
    {
        private readonly DbSet<RateEntity> _dataset;
        public RateRepository(Cambio24Context context) : base(context)
        {
            _dataset = _context.Set<RateEntity>();
        }

        public RateEntity GetByCode(string code)
        {
            try
            {
                return _dataset.SingleOrDefault(p => p.Code.Equals(code));
            }
            catch (Exception ex)
            {

                return null;
            }
        }
    }
}
