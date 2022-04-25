using AutoMapper;
using Cambio_24.Data.UnitOfWork;
using Cambio_24.Domain.Entities;
using Cambio_24.Domain.Helper.Utils;
using Cambio_24.Domain.Interfaces.Business.Rate;
using Combio_24.Model.RatesModels;
using System;
using System.Collections.Generic;

namespace Cambio_24.Business.Rate
{
    public class RateLogic : IRateLogic
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public RateLogic(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public RateResponse Delete(long id)
        {
            var result = new RateResponse();

            try
            {
                var isDeleted = _unitOfWork.RateRepository.Delete(id);

                if (isDeleted)
                    result.Success = true;
                else
                    result.Success = false;

                _unitOfWork.Commit();
            }
            catch (Exception)
            {
                result.Success = false;
            }

            return result;
        }

        public RateResponse Get()
        {

            var result = new RateResponse();

            try
            {
                var rates = _unitOfWork.RateRepository.Get();
                result.Rates = _mapper.Map<IEnumerable<RateEntity>, IEnumerable<RateModel>>(rates);
                result.Success = true;

            }
            catch (Exception)
            {
                result.Success = false;
            }

            return result;
        }

        public RateResponse Get(long id)
        {

            var result = new RateResponse();

            try
            {
                var rate = _unitOfWork.RateRepository.Get(id);
                result.Rate = _mapper.Map<RateEntity, RateModel>(rate);
                result.Success = true;

            }
            catch (Exception)
            {
                result.Success = false;
            }

            return result;
        }



        public RateResponse GetByCode(string code)
        {
            var result = new RateResponse();

            try
            {

                var rate = _unitOfWork.RateRepository.GetByCode(code);
                result.Rate = _mapper.Map<RateEntity, RateModel>(rate);
                result.Success = true;

            }
            catch (Exception)
            {
                result.Success = false;
            }

            return result;
        }

        public RateResponse Insert(RateRequest rate)
        {
            var result = new RateResponse();

            try
            {
                var storedRate = _unitOfWork.RateRepository.GetByCode(rate.Code);

                if (storedRate != null)
                {
                    result.Success = false;
                    result.Message = "Already exists";
                }
                else
                {

                    var rateEntity = _mapper.Map<RateRequest, RateEntity>(rate);
                    rateEntity.TaxRatePurchase = Util.FormatTolong(rate.TaxRatePurchase.ToString());
                    rateEntity.TaxRateSales = Util.FormatTolong(rate.TaxRateSales.ToString());
                    rateEntity.Balance = Util.FormatTolong(rate.Balance.ToString());
                    rateEntity.TaxRate = Util.FormatTolong(rate.TaxRate.ToString());
                    rateEntity.Code = rateEntity.Code.ToUpper();
                    var createdRate = _unitOfWork.RateRepository.Insert(rateEntity);

                    _unitOfWork.Commit();

                    result.Rate = _mapper.Map<RateEntity, RateModel>(createdRate);
                    result.Success = true;
                }
            }
            catch (Exception e)
            {
                _unitOfWork.Rollback();
                result.Success = false;
            }

            return result;
        }

        public RateResponse Update(RateRequest rate)
        {
            var result = new RateResponse();

            try
            {
                var rateEntity = _mapper.Map<RateRequest, RateEntity>(rate);
                rateEntity.UpdatedAt = DateTime.UtcNow;
                rateEntity.TaxRatePurchase = Util.FormatTolong(rate.TaxRatePurchase.ToString());
                rateEntity.TaxRateSales = Util.FormatTolong(rate.TaxRateSales.ToString());
                rateEntity.Balance = Util.FormatTolong(rate.Balance.ToString());
                rateEntity.TaxRate = Util.FormatTolong(rate.TaxRate.ToString());
                rateEntity.Code = rateEntity.Code.ToUpper();
                var updatedRate = _unitOfWork.RateRepository.Update(rateEntity);

                _unitOfWork.Commit();

                var RateModel = _mapper.Map<RateEntity, RateModel>(updatedRate);

                result.Rate = RateModel;
                result.Success = true;
            }
            catch (Exception e)
            {
                _unitOfWork.Rollback();
                result.Success = false;
            }

            return result;
        }

        public RateResponse UpdateBalance(List<RateModel> rates)
        {
            var result = new RateResponse();
            var resteTemp = new List<RateModel>();
            try
            {
                foreach (var rate in rates)
                {
                    var rateEntity = _mapper.Map<RateModel, RateEntity>(rate);
                    rateEntity.Balance = Util.FormatTolong(rate.Balance.ToString());
                    rateEntity.UpdatedAt = DateTime.UtcNow;
                    var updatedRate = _unitOfWork.RateRepository.Update(rateEntity);

                    _unitOfWork.Commit();

                    var RatesModel = _mapper.Map<RateEntity, RateModel>(updatedRate);

                    resteTemp.Add(RatesModel);
                }
                
                result.Rates = resteTemp;
                result.Success = true;
            }
            catch (Exception e)
            {
                _unitOfWork.Rollback();
                result.Success = false;
            }

            return result;
        }
    }
}
