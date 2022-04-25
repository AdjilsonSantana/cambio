using Cambio_24.Models.UserModels;
using Combio_24.Model.ClientModels;
using Combio_24.Model.OperationTypeModels;
using Combio_24.Model.RatesModels;
using System;
using System.ComponentModel.DataAnnotations;

namespace Combio_24.Model.OperationModels
{
    public class OperationRequest
    {
        public long Id { get; set; }
        [Required]
        public string OperationTypeCode { get; set; }
        public OperationTypeModel OperationType { get; set; }
        public string Description { get; set; }
        [Required]
        public long CurrencyInputId { get; set; }
        public RateModel CurrencyInput { get; set; }
        [Required]
        public long CurrencyOutputId { get; set; }
        public RateModel CurrencyOutput { get; set; }
        [Required]
        public long AmountReceived { get; set; }
        [Required]
        public long Amount { get; set; }
        [Required]
        public long UserId { get; set; }
        public UserModel User { get; set; }
        [Required]
        public long ClientId { get; set; }
        public ClientModel Client { get; set; }
    }
}
