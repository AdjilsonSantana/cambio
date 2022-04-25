using AutoMapper;
using Cambio_24.Data.UnitOfWork;
using Cambio_24.Domain.Entities;
using Cambio_24.Domain.Interfaces.Business.DocumentType;
using Combio_24.Model.DocumentTypeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cambio_24.Business.DocumentType
{
    public class DocumentTypeLogic : IDocumentTypeLogic
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public DocumentTypeLogic(
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public DocumentTypeResponse Delete(long id)
        {
            var result = new DocumentTypeResponse();

            try
            {
                var isDeleted = _unitOfWork.DocumentTypeRepository.Delete(id);

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

        public DocumentTypeResponse Get()
        {

            var result = new DocumentTypeResponse();

            try
            {
                var docuTypes = _unitOfWork.DocumentTypeRepository.Get();
                result.DocumentTypes = _mapper.Map<IEnumerable<DocumentTypeEntity>, IEnumerable<DocumentTypeModel>>(docuTypes);
                result.Success = true;

            }
            catch (Exception)
            {
                result.Success = false;
            }

            return result;
        }

        public DocumentTypeResponse Get(long id)
        {
            var result = new DocumentTypeResponse();

            try
            {
                var docuType = _unitOfWork.DocumentTypeRepository.Get(id);
                result.DocumentType = _mapper.Map<DocumentTypeEntity, DocumentTypeModel>(docuType);
                result.Success = true;

            }
            catch (Exception)
            {
                result.Success = false;
            }

            return result;
        }

        public DocumentTypeResponse GetByCode(string docCode)
        {
            var result = new DocumentTypeResponse();

            try
            {
                var docuType = _unitOfWork.DocumentTypeRepository.GetByCode(docCode);
                result.DocumentType = _mapper.Map<DocumentTypeEntity, DocumentTypeModel>(docuType);
                result.Success = true;

            }
            catch (Exception)
            {
                result.Success = false;
            }

            return result;
        }

        public DocumentTypeResponse Insert(DocumentTypeRequest docType)
        {

            var result = new DocumentTypeResponse();

            try
            {
                var storedDocType = _unitOfWork.DocumentTypeRepository.GetByCode(docType.DocTypeCode);

                if (storedDocType != null)
                {
                    result.Success = false;
                    result.Message = "Already exists";
                }
                else
                {

                    var docTypeEntity = _mapper.Map<DocumentTypeRequest, DocumentTypeEntity>(docType);
                    docTypeEntity.DocTypeCode = docTypeEntity.DocTypeCode.ToUpper();
                    var createdDocType = _unitOfWork.DocumentTypeRepository.Insert(docTypeEntity);

                    _unitOfWork.Commit();

                    result.DocumentType = _mapper.Map<DocumentTypeEntity, DocumentTypeModel>(createdDocType);
                    result.Success = true;
                }
            }
            catch (Exception e)
            {
                if (e.InnerException.Message.Contains("duplicate"))
                {
                    result.Success = false;
                    result.Message = "Já existe um tipo documento com esse codigo.";
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

        public DocumentTypeResponse Update(DocumentTypeRequest docType)
        {
            var result = new DocumentTypeResponse();

            try
            {
                var docTypeEntity = _mapper.Map<DocumentTypeRequest, DocumentTypeEntity>(docType);
                docTypeEntity.UpdatedAt = DateTime.UtcNow;
                docTypeEntity.DocTypeCode = docTypeEntity.DocTypeCode.ToUpper();
                var updatedDocType = _unitOfWork.DocumentTypeRepository.Update(docTypeEntity);

                _unitOfWork.Commit();

                result.DocumentType = _mapper.Map<DocumentTypeEntity, DocumentTypeModel>(updatedDocType); ;
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
