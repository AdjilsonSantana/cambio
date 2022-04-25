using Cambio_24.Domain.Entities;

namespace Cambio_24.Domain.Interfaces
{
    public interface IRateRepository : IRepository<RateEntity>
    {
        RateEntity GetByCode(string code);
    }
}
