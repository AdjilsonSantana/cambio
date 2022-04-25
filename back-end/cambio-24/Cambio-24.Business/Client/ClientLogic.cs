using AutoMapper;
using Cambio_24.Data.UnitOfWork;
using Cambio_24.Domain.Entities;
using Cambio_24.Domain.Interfaces.Business.Client;
using Combio_24.Model.ClientModels;
using System;
using System.Collections.Generic;

namespace Cambio_24.Business.Client
{
    public class ClientLogic : IClientLogic
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public ClientLogic(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public ClientResponse Delete(long id)
        {
            var result = new ClientResponse();

            try
            {
                var isDeleted = _unitOfWork.ClientRepository.Delete(id);

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

        public ClientResponse Get()
        {
            var result = new ClientResponse();

            try
            {
                var clients = _unitOfWork.ClientRepository.Get();
                result.Clients = _mapper.Map<IEnumerable<ClientEntity>, IEnumerable<ClientModel>>(clients);
                result.Success = true;

            }
            catch (Exception)
            {
                result.Success = false;
            }

            return result;
        }

        public ClientResponse Get(long id)
        {
            var result = new ClientResponse();

            try
            {
                var Client = _unitOfWork.ClientRepository.Get(id);
                result.Client = _mapper.Map<ClientEntity, ClientModel>(Client);
                result.Success = true;

            }
            catch (Exception)
            {
                result.Success = false;
            }

            return result;
        }

        public ClientResponse GetByDocNumberOrNif(string docOrnif)
        {
            var result = new ClientResponse();

            try
            {
                var Client = _unitOfWork.ClientRepository.GetByDocNumberOrNif(docOrnif);
                result.Client = _mapper.Map<ClientEntity, ClientModel>(Client);
                result.Success = true;

            }
            catch (Exception)
            {
                result.Success = false;
            }

            return result;
        }

        public ClientResponse Insert(ClientRequest Client)
        {
            var result = new ClientResponse();

            try
            {
                var storedEmployee = _unitOfWork.ClientRepository.GetByDocNumberOrNif(Client.TaxNumber);
                //storedEmployee = _unitOfWork.ClientRepository.GetByDocNumberOrNif(Client.TaxNumber);

                if (storedEmployee != null)
                {
                    result.Success = false;
                    result.Message = "Cliente já existe!";
                }
                else
                {

                    try
                    {
                        // DateTime birthdate = Convert.ToDateTime(Client.BirthDate);
                        Client.BirthDate = string.IsNullOrEmpty(Client.BirthDate) ? default(DateTime).ToLongDateString() : Convert.ToDateTime(Client.BirthDate).ToLongDateString();
                    }
                    catch (Exception ex)
                    {
                        result.Success = false;
                        result.Message = ex.Message;
                        return result;
                    }
                    var clientEntity = _mapper.Map<ClientRequest, ClientEntity>(Client);
                    clientEntity.Employee = null;
                    clientEntity.DocumentType = null;
                    clientEntity.BirthDate = Convert.ToDateTime(clientEntity.BirthDate);
                    var createdClient = _unitOfWork.ClientRepository.Insert(clientEntity);

                    _unitOfWork.Commit();

                    result.Client = _mapper.Map<ClientEntity, ClientModel>(createdClient);
                    result.Success = true;
                }
            }
            catch (Exception e)
            {
                if (e.InnerException.Message.Contains("duplicate"))
                {
                    result.Success = false;
                    result.Message = "Já existe um cliente com esse NIF.";
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

        public ClientResponse Update(ClientRequest Client)
        {
            var result = new ClientResponse();

            try
            {
                var clientEntity = _mapper.Map<ClientRequest, ClientEntity>(Client);
                clientEntity.UpdatedAt = DateTime.UtcNow;
                clientEntity.BirthDate = Convert.ToDateTime(clientEntity.BirthDate);
                var updatedClient = _unitOfWork.ClientRepository.Update(clientEntity);

                _unitOfWork.Commit();

                var ClientModel = _mapper.Map<ClientEntity, ClientModel>(updatedClient);

                result.Client = ClientModel;
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
