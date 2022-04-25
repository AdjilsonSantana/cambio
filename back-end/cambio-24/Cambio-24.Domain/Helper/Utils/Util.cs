using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Cambio_24.Domain.Helper.Utils
{
    public static class Util
    {
        public static string CurrencyConverterValue(decimal value, string symbol)
        {
            return $"{value.ToString("N2", new CultureInfo("pt-PT"))} {symbol}";
        }

        public static bool IsValideBalance(long balance, long amount)
        {
            if (balance < amount)
            {
                return false;
            }

            return true;
        }

        public static long FormatTolong(string value)
        {
            value = value.Replace(".", ",");

            if (value.Contains(","))
            {
                var listValue = value.Split(",");
                value = value.Replace(",", "");
                if (listValue[1].Length == 1)
                {
                    value += "0";
                }
            }
            else
            {
                value += "00";
            }

            var valueFormatted = Regex.Replace(value, @"\s+", "");

            long formatValue = long.Parse(valueFormatted);

            return formatValue;
        }
    }
}
