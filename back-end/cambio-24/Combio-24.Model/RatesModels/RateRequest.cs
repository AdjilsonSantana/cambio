using System.ComponentModel.DataAnnotations;

namespace Combio_24.Model.RatesModels
{
    public class RateRequest
    {
        public long Id { get; set; }
        [Required]
        public string Code { get; set; }
        public decimal TaxRate { get; set; }
        [Required]
        public decimal TaxRatePurchase { get; set; }
        [Required]
        public decimal TaxRateSales { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Balance { get; set; }
        [Required]
        public string Symbol { get; set; }
    }
}
