using Combio_24.Model.Converter;

namespace Cambio_24.Domain.Helper.Interface
{
    public interface IConverterCalc
    {
        ConverterResult Conversion(ConverterInput input);
    }
}
