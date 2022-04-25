using Cambio_24.Domain.Interfaces;

namespace Cambio_24.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        void Commit();
        void Rollback();
        IUserRepository UserRepository { get; set; }
        IEmployeeRepository EmployeeRepository { get; set; }
        IDocumentTypeRepository DocumentTypeRepository { get; set; }
        IClientRepository ClientRepository { get; set; }
        IRateRepository RateRepository { get; set; }
        IOperationTypeRepository OperationTypeRepository { get; set; }
        IOperationRepository OperationRepository { get; set; }
    }
}
