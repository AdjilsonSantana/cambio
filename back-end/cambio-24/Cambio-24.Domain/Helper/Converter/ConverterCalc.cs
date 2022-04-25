using Cambio_24.Domain.Helper.Interface;
using Cambio_24.Domain.Helper.Utils;
using Cambio_24.Domain.Interfaces.Business.Rate;
using Combio_24.Model.Converter;
using Combio_24.Model.RatesModels;
using System;

namespace Cambio_24.Domain.Helper.Converter
{
    public class ConverterCalc : IConverterCalc
    {
        private readonly IRateLogic _rateLogic;
        public ConverterCalc(IRateLogic rateLogic)
        {
            _rateLogic = rateLogic;
        }

        public ConverterResult Conversion(ConverterInput input)
        {
            RateModel currencyInput = _rateLogic.Get(input.CurrencyInput).Rate;
            RateModel currencyOutput = _rateLogic.Get(input.CurrencyOutput).Rate;
            long convertedValue = 0L;
            long taxRate = 0L;
            ConverterResult result = new ConverterResult
            {
                Success = false,
                Message = "",
                CurrencyInput = new RateModel(),
                CurrencyOutput = new RateModel(),
            };

            try
            {
                if (input == null)
                {
                    result.Message = "Deve indicar os valores para a conversão";
                    return result;
                }

                long amountReceived = Util.FormatTolong(input.AmountReceived.ToString());
                if (input.OperationTypeCode.ToUpper().Equals("V"))
                {
                    if (currencyInput.Code.Equals("STN"))
                    {
                        convertedValue = amountReceived / currencyOutput.TaxRateSales;
                        convertedValue *= 100;
                        result.Success = Util.IsValideBalance(currencyOutput.Balance, convertedValue);

                        if (result.Success)
                        {
                            currencyInput.Balance += amountReceived;
                            currencyOutput.Balance -= convertedValue;
                            taxRate = currencyOutput.TaxRateSales;
                        }
                        else
                        {
                            result.Message = "Quantia não disponível";
                            decimal balance = Convert.ToDecimal(currencyOutput.Balance) / 100;
                            balance.ToString("0.00");
                            string balanceInfo = Util.CurrencyConverterValue(balance,currencyOutput.Symbol);
                            result.BalanceInfo = $"Saldo disponível em caixa {balanceInfo}";

                            var amount = Convert.ToDecimal(convertedValue) / 100;
                            amount.ToString("0.00");
                            result.AmountWithSymbol = Util.CurrencyConverterValue(amount, currencyOutput.Symbol);
                        }


                    }
                    else if (!currencyInput.Code.Equals("STN"))
                    {
                        convertedValue = (amountReceived / 100) * currencyInput.TaxRateSales;

                        result.Success = Util.IsValideBalance(currencyInput.Balance, convertedValue);

                        if (result.Success)
                        {
                            currencyInput.Balance -= amountReceived;
                            currencyOutput.Balance += convertedValue;
                            taxRate = currencyInput.TaxRateSales;
                        }
                        else
                        {
                            result.Message = "Quantia não disponível";
                            decimal balance = Convert.ToDecimal(currencyInput.Balance) / 100;
                            balance.ToString("0.00");
                            string balanceInfo = Util.CurrencyConverterValue(balance, currencyInput.Symbol);
                            result.BalanceInfo = $"Saldo disponível em caixa {balanceInfo}";

                            var amount = Convert.ToDecimal(convertedValue) / 100;
                            amount.ToString("0.00");
                            result.AmountWithSymbol = Util.CurrencyConverterValue(amount, currencyOutput.Symbol);
                        }


                    }
                }
                else if (input.OperationTypeCode.ToUpper().Equals("C"))
                {
                    if (currencyInput.Code.Equals("STN"))
                    {
                        convertedValue = amountReceived / currencyOutput.TaxRatePurchase;
                        convertedValue *= 100;
                        result.Success = Util.IsValideBalance(currencyInput.Balance, convertedValue);

                        if (result.Success)
                        {
                            currencyInput.Balance -= amountReceived;
                            currencyOutput.Balance += convertedValue;
                            taxRate = currencyOutput.TaxRatePurchase;
                        }
                        else
                        {
                            result.Message = "Quantia não disponível";
                            decimal balance = Convert.ToDecimal(currencyInput.Balance) / 100;
                            balance.ToString("0.00");
                            string balanceInfo = Util.CurrencyConverterValue(balance, currencyInput.Symbol);
                            result.BalanceInfo = $"Saldo disponível em caixa {balanceInfo}";

                            var amount = Convert.ToDecimal(convertedValue) / 100;
                            amount.ToString("0.00");
                            result.AmountWithSymbol = Util.CurrencyConverterValue(amount, currencyOutput.Symbol);
                        }

                    }
                    else if (!currencyInput.Code.Equals("STN"))
                    {
                        convertedValue = (amountReceived / 100) * currencyInput.TaxRatePurchase;

                        result.Success = Util.IsValideBalance(currencyOutput.Balance, convertedValue);

                        if (result.Success)
                        {
                            currencyInput.Balance += amountReceived;
                            currencyOutput.Balance -= convertedValue;
                            taxRate = currencyInput.TaxRatePurchase;
                        }
                        else
                        {
                            result.Message = "Quantia não disponível";
                            decimal balance = Convert.ToDecimal(currencyOutput.Balance) / 100;
                            balance.ToString("0.00");
                            string balanceInfo = Util.CurrencyConverterValue(balance, currencyOutput.Symbol);
                            result.BalanceInfo = $"Saldo disponível em caixa {balanceInfo}";

                            var amount = Convert.ToDecimal(convertedValue) / 100;
                            amount.ToString("0.00");
                            result.AmountWithSymbol = Util.CurrencyConverterValue(amount, currencyOutput.Symbol);
                        }
                    }
                }
                else
                {
                    result.Success = false;
                    result.Message = " Deve Indicar o Tipo de Operação!";
                }


                if (result.Success)
                {
                    var amount = Convert.ToDecimal(convertedValue) / 100;
                    amount.ToString("0.00");

                    var amountReceivedWithSimbol = Convert.ToDecimal(amountReceived) / 100;
                    amountReceivedWithSimbol.ToString("0.00");

                    var taxAmount = Convert.ToDecimal(taxRate) / 100;
                    taxAmount.ToString("0.00");

                    var amountSymbol = !currencyInput.Code.Equals("STN") ? "DBS" : currencyOutput.Symbol;

                    var amountSymbolInput = currencyInput.Code.Equals("STN") ? "DBS" : currencyInput.Symbol;

                    result.Amount = convertedValue;
                    result.CurrencyInput = currencyInput;
                    result.CurrencyOutput = currencyOutput;
                    result.AmountReceived = amountReceived;
                    result.OperationTypeCode = input.OperationTypeCode;
                    result.OperationTypeDescription = input.OperationTypeCode.Equals("C") ? "Compra" : "Venda";


                    result.AmountWithSymbol = Util.CurrencyConverterValue(amount, amountSymbol);
                    result.TaxRate = Util.CurrencyConverterValue(taxAmount, "DBS");
                    result.AmountReceivedWithSymbol = Util.CurrencyConverterValue(amountReceivedWithSimbol, amountSymbolInput);
                }
            }
            catch (Exception ex)
            {
                result = new ConverterResult
                {
                    Success = false,
                    Message = "Falha ao converter",
                };
            }
            return result;
        }


    }



    /*

     Venda
        euro=20*taxaEuro.
        MoedaEstrangeira=ValorMoedaInserido20* ValorVendaMoedaEstrangeira =taxa
        MoedaNacional= ValorMoedaInserida /ValorVendaMoedaEstrangeira

    Compra

        MoedaEstrangeira= ValorMoedaInserido*ValorCompraMoedaEstrangeira
        MoedaNacional= ValorMoedaInserido/ValorCompraMoedaEstrangeira

     */

}
