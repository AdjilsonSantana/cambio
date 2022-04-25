using Cambio_24.Data.Context;
using Cambio_24.Domain.Entities;
using Cambio_24.Domain.Interfaces;
using Combio_24.Model.OperationModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cambio_24.Data.Repository
{
   public class OperationRepository : Repository<OperationEntity>,IOperationRepository
    {
        private readonly DbSet<OperationEntity> _dataset;
        public OperationRepository(Cambio24Context context):base(context)
        {
            _dataset = _context.Set<OperationEntity>();
        }

       
    }
}
