using Cambio_24.Domain.Interfaces.Business.Rate;
using Cambio_24.Framework.Interfaces;
using Combio_24.Model.RatesModels;
using System.Collections.Generic;

namespace Cambio_24.Framework.Rate
{
    public class RateFramework : IRateFramework
    {
        private readonly IRateLogic _rateLogic;
        public RateFramework(IRateLogic rateLogic)
        {
            _rateLogic = rateLogic;
        }
        public RateResponse Delete(long id)
        {
            return _rateLogic.Delete(id);
        }

        public RateResponse Get()
        {
            return _rateLogic.Get();
        }

        public RateResponse Get(long id)
        {
            return _rateLogic.Get(id);
        }

        public RateResponse GetByCode(string code)
        {
            return _rateLogic.GetByCode(code);
        }

        public RateResponse Insert(RateRequest rate)
        {
            return _rateLogic.Insert(rate);
        }

        public RateResponse Update(RateRequest rate)
        {
            return _rateLogic.Update(rate);
        }

        public RateResponse UpdateBalance(List<RateModel> rates)
        {
            return _rateLogic.UpdateBalance(rates);
        }
    }
}
