using Combio_24.Model.RatesModels;
using System.Collections.Generic;

namespace Cambio_24.Framework.Interfaces
{
    public interface IRateFramework
    {
        RateResponse Get();
        RateResponse Get(long id);
        RateResponse GetByCode(string code);
        RateResponse Insert(RateRequest rate);
        RateResponse Update(RateRequest rate);
        RateResponse Delete(long id);
        RateResponse UpdateBalance(List<RateModel> rates);
    }
}
