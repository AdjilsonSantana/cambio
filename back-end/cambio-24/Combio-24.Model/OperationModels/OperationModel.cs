using Cambio_24.Models.UserModels;
using Combio_24.Model.ClientModels;
using Combio_24.Model.OperationTypeModels;
using Combio_24.Model.RatesModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combio_24.Model.OperationModels
{
    public class OperationModel
    {
        public long Id { get; set; }
        public long OperationTypeId { get; set; }
        public OperationTypeModel OperationType { get; set; }
        public string Description { get; set; }
        public long CurrencyInputId { get; set; }
        public RateModel CurrencyInput { get; set; }
        public long CurrencyOutputId { get; set; }
        public RateModel CurrencyOutput { get; set; }
        public long AmountReceived { get; set; }
        public long Amount { get; set; }
        public DateTime OperationDate { get; set; }
        public long UserId { get; set; }
        public UserModel User { get; set; }
        public long ClientId { get; set; }
        public ClientModel Client { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
