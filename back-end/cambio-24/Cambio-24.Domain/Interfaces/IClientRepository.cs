using Cambio_24.Domain.Entities;

namespace Cambio_24.Domain.Interfaces
{
    public interface IClientRepository : IRepository<ClientEntity>
    {
        ClientEntity GetByDocNumberOrNif(string docOrnif);
    }
}
