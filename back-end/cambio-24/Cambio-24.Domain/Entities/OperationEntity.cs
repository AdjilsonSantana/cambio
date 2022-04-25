using System;

namespace Cambio_24.Domain.Entities
{
    public class OperationEntity : BaseEntity
    {
        public long OperationTypeId { get; set; }
        public OperationTypeEntity OperationType { get; set; }
        public string Description { get; set; }
        public long CurrencyInputId { get; set; }
        public RateEntity CurrencyInput { get; set; }
        public long CurrencyOutputId { get; set; }
        public RateEntity CurrencyOutput { get; set; }
        public long AmountReceived { get; set; }
        public long Amount { get; set; }
        public long UserId { get; set; }
        public UserEntity User { get; set; }
        public long ClientId { get; set; }
        public ClientEntity Client { get; set; }

        private DateTime? _operationDate;
        public DateTime? OperationDate
        {
            get { return _operationDate; }
            set { _operationDate = (value == null ? DateTime.UtcNow : value); }
        }
    }
}
