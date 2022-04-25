using Cambio_24.Data.Context;
using Cambio_24.Domain.Entities;
using Cambio_24.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Cambio_24.Data.Repository
{
    public class EmployeeRepository : Repository<EmployeeEntity>, IEmployeeRepository
    {
        private readonly DbSet<EmployeeEntity> _dataset;
        public EmployeeRepository(Cambio24Context context) : base(context)
        {
            _dataset = _context.Set<EmployeeEntity>();
        }

        public EmployeeEntity GetByDocNumberOrNif(string docOrnif = "")
        {
            try
            {
               
                if (!string.IsNullOrEmpty(docOrnif))
                    return _dataset.Include(e => e.User).SingleOrDefault(p => p.TaxNumber.Equals(docOrnif) || p.DocNumber.Equals(docOrnif));
            }
            catch (Exception ex)
            {

                return null;
            }

            return null;
        }

        public EmployeeEntity GetByUser(UserEntity userEntity)
        {
            try
            {
                return _dataset.Include(e => e.User).SingleOrDefault(p => p.User.Equals(userEntity));
            }
            catch (Exception ex)
            {

                return null;
            }
        }
    }
}
