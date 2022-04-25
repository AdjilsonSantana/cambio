using AutoMapper;
using Cambio_24.Data.UnitOfWork;
using Cambio_24.Domain.Entities;
using Cambio_24.Domain.Interfaces.Business.Operations;
using Combio_24.Model.OperationTypeModels;
using System;
using System.Collections.Generic;

namespace Cambio_24.Business.Operations
{
    public class OperationTypeLogic : IOperationTypeLogic
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public OperationTypeLogic(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }


        public OperationTypeResponse Delete(long id)
        {
            var result = new OperationTypeResponse();

            try
            {
                var isDeleted = _unitOfWork.OperationTypeRepository.Delete(id);

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

        public OperationTypeResponse Get()
        {

            var result = new OperationTypeResponse();

            try
            {
                var operationTypes = _unitOfWork.OperationTypeRepository.Get();
                result.OperationTypes = _mapper.Map<IEnumerable<OperationTypeEntity>, IEnumerable<OperationTypeModel>>(operationTypes);
                result.Success = true;

            }
            catch (Exception)
            {
                result.Success = false;
            }

            return result;
        }

        public OperationTypeResponse Get(long id)
        {

            var result = new OperationTypeResponse();

            try
            {
                var operationType = _unitOfWork.OperationTypeRepository.Get(id);
                result.OperationType = _mapper.Map<OperationTypeEntity, OperationTypeModel>(operationType);
                result.Success = true;

            }
            catch (Exception)
            {
                result.Success = false;
            }

            return result;
        }

        public OperationTypeResponse Get(string Code)
        {

            var result = new OperationTypeResponse();

            try
            {
                var operationType = _unitOfWork.OperationTypeRepository.Get(Code);
                result.OperationType = _mapper.Map<OperationTypeEntity, OperationTypeModel>(operationType);
                result.Success = true;

            }
            catch (Exception)
            {
                result.Success = false;
            }

            return result;
        }

        public OperationTypeResponse Insert(OperationTypeRequest operationType)
        {
            var result = new OperationTypeResponse();

            try
            {
                var storedOperationType = _unitOfWork.OperationTypeRepository.Exists(operationType);

                if (storedOperationType)
                {
                    result.Success = false;
                    result.Message = "Already exists";
                }
                else
                {

                    var operationTypeEntity = _mapper.Map<OperationTypeRequest, OperationTypeEntity>(operationType);
                    operationTypeEntity.Code = operationTypeEntity.Code.ToUpper();
                    var createdOperationType = _unitOfWork.OperationTypeRepository.Insert(operationTypeEntity);

                    _unitOfWork.Commit();

                    result.OperationType = _mapper.Map<OperationTypeEntity, OperationTypeModel>(createdOperationType);
                    result.Success = true;
                }
            }
            catch (Exception e)
            {
                if (e.InnerException.Message.Contains("duplicate"))
                {
                    result.Success = false;
                    result.Message = "Já existe um tipo de operação com esse codigo.";
                }
                else
                {
                    result.Success = false;
                    result.Message = e.InnerException.Message;
                }
                _unitOfWork.Rollback();
            }
            return result;
        }

        public OperationTypeResponse Update(OperationTypeRequest operationType)
        {
            var result = new OperationTypeResponse();

            try
            {
                var operationTypeEntity = _mapper.Map<OperationTypeRequest, OperationTypeEntity>(operationType);
                operationTypeEntity.UpdatedAt = DateTime.UtcNow;
                operationTypeEntity.Code = operationTypeEntity.Code.ToUpper();
                var updatedOperationType = _unitOfWork.OperationTypeRepository.Update(operationTypeEntity);

                _unitOfWork.Commit();

                var operationTypeModel = _mapper.Map<OperationTypeEntity, OperationTypeModel>(updatedOperationType);

                result.OperationType = operationTypeModel;
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
