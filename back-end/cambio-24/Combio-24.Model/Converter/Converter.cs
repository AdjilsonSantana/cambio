using Cambio_24.Models.Generics;
using Combio_24.Model.RatesModels;

namespace Combio_24.Model.Converter
{
    public class ConverterResult : GenericResult
    {
        public long Amount { get; set; }
        public string AmountWithSymbol { get; set; }
        public RateModel CurrencyInput { get; set; }
        public RateModel CurrencyOutput { get; set; }
        public long AmountReceived { get; set; }
        public string AmountReceivedWithSymbol { get; set; }
        public string TaxRate { get; set; }
        public string OperationTypeCode { get; set; }
        public string OperationTypeDescription { get; set; }
        public string BalanceInfo { get; set; }
    }

    public class ConverterInput
    {

        public decimal AmountReceived { get; set; }
        public long CurrencyInput { get; set; }
        public long CurrencyOutput { get; set; }
        public string OperationTypeCode { get; set; }
    }
}
