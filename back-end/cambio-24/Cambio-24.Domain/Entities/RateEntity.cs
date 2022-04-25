namespace Cambio_24.Domain.Entities
{
    public class RateEntity : BaseEntity
    {
        public string Code { get; set; }
        public long TaxRate { get; set; }
        public long TaxRatePurchase { get; set; }
        public long TaxRateSales { get; set; }
        public string Name { get; set; }
        public long Balance { get; set; }
        public string Symbol { get; set; }
    }
}
