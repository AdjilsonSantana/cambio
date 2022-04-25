using System;

namespace Combio_24.Model.RatesModels
{
    public class RateModel
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public long TaxRate { get; set; }
        public long TaxRatePurchase { get; set; }
        public long TaxRateSales { get; set; }
        public string Name { get; set; }
        public long Balance { get; set; }
        public string Symbol { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public string RateName { get { return this !=null ? $"{Code}-{Name}":""; }}
        
    }
}
