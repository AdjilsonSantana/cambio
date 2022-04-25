using Cambio_24.Data.Context;
using Cambio_24.Data.Repository;
using Cambio_24.Domain.Interfaces;

namespace Cambio_24.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Cambio24Context _context;
        private IUserRepository _userRepository;
        private IEmployeeRepository _employeeRepository;
        private IDocumentTypeRepository _documentTypeRepository;
        private IClientRepository _clientRepository;
        private IRateRepository _rateRepository;
        private IOperationTypeRepository _operationTypeRepository;
        private IOperationRepository _operationRepository;

        public UnitOfWork(Cambio24Context context,
            IUserRepository userRepository,
            IEmployeeRepository employeeRepository,
            IDocumentTypeRepository documentTypeRepository,
            IClientRepository clientRepository,
            IRateRepository rateRepository,
            IOperationTypeRepository operationTypeRepository,
            IOperationRepository operationRepository)
        {
            _context = context;
            _userRepository = userRepository;
            _employeeRepository = employeeRepository;
            _documentTypeRepository = documentTypeRepository;
            _clientRepository = clientRepository;
            _rateRepository = rateRepository;
            _operationTypeRepository = operationTypeRepository;
            _operationRepository = operationRepository;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Rollback()
        {
            //Todo Ver o que fazer aqui....
        }

        IUserRepository IUnitOfWork.UserRepository
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new UserRepository(_context);
                }
                return _userRepository;
            }

            set { }
        }

        IEmployeeRepository IUnitOfWork.EmployeeRepository
        {
            get
            {
                if (_employeeRepository == null)
                {
                    _employeeRepository = new EmployeeRepository(_context);
                }
                return _employeeRepository;
            }

            set { }
        }


        IDocumentTypeRepository IUnitOfWork.DocumentTypeRepository
        {
            get
            {
                if (_documentTypeRepository == null)
                {
                    _documentTypeRepository = new DocumentTypeRepository(_context);
                }
                return _documentTypeRepository;
            }

            set { }
        }

        IClientRepository IUnitOfWork.ClientRepository
        {
            get
            {
                if (_clientRepository == null)
                {
                    _clientRepository = new ClientRepository(_context);
                }
                return _clientRepository;
            }

            set { }
        }

        IRateRepository IUnitOfWork.RateRepository
        {
            get
            {
                if (_rateRepository == null)
                {
                    _rateRepository = new RateRepository(_context);
                }
                return _rateRepository;
            }

            set { }
        }

        IOperationTypeRepository IUnitOfWork.OperationTypeRepository
        {
            get
            {
                if (_operationTypeRepository == null)
                {
                    _operationTypeRepository = new OperationTypeRepository(_context);
                }
                return _operationTypeRepository;
            }

            set { }
        }


        IOperationRepository IUnitOfWork.OperationRepository
        {
            get
            {
                if (_operationRepository==null)
                {
                    _operationRepository = new OperationRepository(_context);
                }
                return _operationRepository;
            }
            set { }

        }
    }
}
