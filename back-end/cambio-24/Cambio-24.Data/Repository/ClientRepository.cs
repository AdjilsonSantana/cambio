using Cambio_24.Data.Context;
using Cambio_24.Domain.Entities;
using Cambio_24.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cambio_24.Data.Repository
{
    public class ClientRepository : Repository<ClientEntity>, IClientRepository
    {
        private readonly DbSet<ClientEntity> _dataset;
        public ClientRepository(Cambio24Context context) : base(context)
        {
            _dataset = _context.Set<ClientEntity>();
        }

        public ClientEntity GetByDocNumberOrNif(string docOrnif = "")
        {
            try
            {
               
                if (!string.IsNullOrEmpty(docOrnif))
                    return _dataset.SingleOrDefault(p => p.TaxNumber.Equals(docOrnif) || p.DocNumber.Equals(docOrnif));
            }
            catch (Exception ex)
            {

                return null;
            }

            return null;
        }
    }
}
