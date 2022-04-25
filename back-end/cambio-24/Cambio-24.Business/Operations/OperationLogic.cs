using AutoMapper;
using Cambio_24.Data.UnitOfWork;
using Cambio_24.Domain.Entities;
using Cambio_24.Domain.Interfaces.Business.Operations;
using Cambio_24.Domain.Interfaces.Business.Rate;
using Combio_24.Model.OperationModels;
using Combio_24.Model.RatesModels;
using System;
using System.Collections.Generic;

namespace Cambio_24.Business.Operations
{
    public class OperationLogic : IOperationLogic
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRateLogic _rateLogic;
        private readonly IOperationTypeLogic _operationTypeLogic;
        public OperationLogic(IUnitOfWork unitOfWork, 
            IMapper mapper, IRateLogic rateLogic,
            IOperationTypeLogic operationTypeLogic)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _rateLogic = rateLogic;
            _operationTypeLogic = operationTypeLogic;
        }


        public OperationResponse Delete(long id)
        {
            var result = new OperationResponse();

            try
            {
                var isDeleted = _unitOfWork.OperationRepository.Delete(id);

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

        public OperationResponse Get()
        {

            var result = new OperationResponse();

            try
            {
                var operations = _unitOfWork.OperationRepository.Get();
                result.Operations = _mapper.Map<IEnumerable<OperationEntity>, IEnumerable<OperationModel>>(operations);
                result.Success = true;

            }
            catch (Exception)
            {
                result.Success = false;
            }

            return result;
        }

        public OperationResponse Get(long id)
        {

            var result = new OperationResponse();

            try
            {
                var operation = _unitOfWork.OperationRepository.Get(id);
                result.Operation = _mapper.Map<OperationEntity, OperationModel>(operation);
                result.Success = true;

            }
            catch (Exception)
            {
                result.Success = false;
            }

            return result;
        }


        public OperationResponse Insert(OperationRequest operation)
        {
            var result = new OperationResponse();

            try
            {
                List<RateModel> rates = new List<RateModel>();
                if (operation.CurrencyInput != null && operation.CurrencyOutput != null)
                {
                    rates.Add(operation.CurrencyOutput);
                    rates.Add(operation.CurrencyInput);

                    var rate = _rateLogic.UpdateBalance(rates);
                    var operationType = _operationTypeLogic.Get(operation.OperationTypeCode);

                    if (rate != null && rate.Success)
                    {
                        if (operationType.Success && operationType.OperationType!=null)
                        {
                            operation.CurrencyInput = null;
                            operation.CurrencyOutput = null;
                            operation.OperationType = null;
                            operation.Client = null;
                            var operationEntity = _mapper.Map<OperationRequest, OperationEntity>(operation);
                            operationEntity.OperationDate = DateTime.UtcNow;
                            operationEntity.OperationTypeId = operationType.OperationType.Id;
                            operationEntity.Description = operationType.OperationType.Code == "V" ? "Venda" : "Compra";
                            var createdOperation = _unitOfWork.OperationRepository.Insert(operationEntity);
                            _unitOfWork.Commit();

                            result.Operation = _mapper.Map<OperationEntity, OperationModel>(createdOperation);
                            result.Success = true; 
                        }
                        else
                        {
                            result.Success = false;
                            result.Message = "Deve indicar o tipo de operação realizada!";
                        }
                    }
                        

                }
                else
                {
                    result.Success = false;
                    result.Message = "Deve indicar as moedas de entrada e saida!";
                }

            }
            catch (Exception e)
            {
                _unitOfWork.Rollback();
                result.Success = false;
            }

            return result;
        }

        public OperationResponse Update(OperationRequest operation)
        {
            var result = new OperationResponse();

            try
            {
                var operationEntity = _mapper.Map<OperationRequest, OperationEntity>(operation);
                operationEntity.UpdatedAt = DateTime.UtcNow;
                var updatedOperation = _unitOfWork.OperationRepository.Update(operationEntity);

                _unitOfWork.Commit();

                var operationTypeModel = _mapper.Map<OperationEntity, OperationModel>(updatedOperation);

                result.Operation = operationTypeModel;
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
