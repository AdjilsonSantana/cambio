using AutoMapper;
using Cambio_24.Data.UnitOfWork;
using Cambio_24.Domain.Constants;
using Cambio_24.Domain.Entities;
using Cambio_24.Domain.Interfaces.Business.Employee;
using Cambio_24.Domain.Interfaces.Business.User;
using Cambio_24.Models.UserModels;
using Combio_24.Model.EmployeeModels;
using System;
using System.Collections.Generic;

namespace Cambio_24.Business.Employee
{
    public class EmployeeLogic : IEmployeeLogic
    {

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserLogic _userLogic;

        public EmployeeLogic(IUnitOfWork unitOfWork, IMapper mapper, IUserLogic userLogic)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _userLogic = userLogic;
        }



        public EmployeeResponse Delete(long id)
        {
            var result = new EmployeeResponse();

            try
            {
                var isDeleted = _unitOfWork.EmployeeRepository.Delete(id);

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

        public EmployeeResponse Get()
        {

            var result = new EmployeeResponse();

            try
            {
                var employees = _unitOfWork.EmployeeRepository.Get();
                result.Employees = _mapper.Map<IEnumerable<EmployeeEntity>, IEnumerable<EmployeeModel>>(employees);
                result.Success = true;

            }
            catch (Exception)
            {
                result.Success = false;
            }

            return result;
        }

        public EmployeeResponse Get(long id)
        {

            var result = new EmployeeResponse();

            try
            {
                var employee = _unitOfWork.EmployeeRepository.Get(id);
                result.Employee = _mapper.Map<EmployeeEntity, EmployeeModel>(employee);
                result.Success = true;

            }
            catch (Exception)
            {
                result.Success = false;
            }

            return result;
        }

        public EmployeeResponse GetByDocNumberOrNif(string docOrnif)
        {
            var result = new EmployeeResponse();

            try
            {
                var employee = _unitOfWork.EmployeeRepository.GetByDocNumberOrNif(docOrnif);
                result.Employee = _mapper.Map<EmployeeEntity, EmployeeModel>(employee);
                result.Success = true;

            }
            catch (Exception)
            {
                result.Success = false;
            }

            return result;
        }

        public EmployeeResponse GetByUser(string user)
        {
            var result = new EmployeeResponse();

            try
            {
                var userEntity = _unitOfWork.UserRepository.GetByEmailOrUsername(user);
                var employee = _unitOfWork.EmployeeRepository.GetByUser(userEntity);
                result.Employee = _mapper.Map<EmployeeEntity, EmployeeModel>(employee);
                result.Success = true;

            }
            catch (Exception)
            {
                result.Success = false;
            }

            return result;
        }

        public EmployeeResponse Insert(EmployeeRequest employee, string role="")
        {
            var result = new EmployeeResponse();
            try
            {
                EmployeeEntity storedEmployee = _unitOfWork.EmployeeRepository.GetByDocNumberOrNif(employee.TaxNumber);

                UserEntity user = _unitOfWork.UserRepository.GetByEmailOrUsername(employee.User.Email);

                UserResponse createdUser;
                if (user != null)
                {
                    result.Success = false;
                    result.Message = "Já existe um utilizador com o email associado.";

                    return result;
                }
                else
                {
                    UserRequest userRequest = _mapper.Map<UserModel, UserRequest>(employee.User);
                    
                    createdUser = _userLogic.Insert(userRequest, role);
                }


                if (storedEmployee != null)
                {
                    result.Success = false;
                    result.Message = "O empregado já existe.";

                    return result;
                }
                else if (createdUser != null && createdUser.Success)
                {

                    var employeeEntity = _mapper.Map<EmployeeRequest, EmployeeEntity>(employee);
                    employeeEntity.User = null;
                    employeeEntity.UserId = createdUser.User.Id;
                    employeeEntity.AdmissionDate = DateTime.UtcNow;
                    employee.BirthDate = Convert.ToDateTime(employee.BirthDate);
                    var createdEmployee = _unitOfWork.EmployeeRepository.Insert(employeeEntity);

                    _unitOfWork.Commit();

                    result.Employee = _mapper.Map<EmployeeEntity, EmployeeModel>(createdEmployee);
                    result.Employee.User = createdUser.User;
                    result.Success = true;
                }
                else
                {
                    result.Success = false;
                    result.Message = string.IsNullOrEmpty(createdUser.Message) ? "Ocorreu um erro.": createdUser.Message;
                }
            }
            catch (Exception e)
            {
                if (e.InnerException.Message.Contains("duplicate"))
                {
                    result.Success = false;
                    result.Message = "Já existe um empregado com esse NIF.";
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

        public EmployeeResponse Update(EmployeeRequest employee)
        {
            var result = new EmployeeResponse();

            try
            {
                var employeeEntity = _mapper.Map<EmployeeRequest, EmployeeEntity>(employee);
                employeeEntity.UpdatedAt = DateTime.UtcNow;
                employee.BirthDate = Convert.ToDateTime(employee.BirthDate);
                employee.User = null;
                var updatedEmployee = _unitOfWork.EmployeeRepository.Update(employeeEntity);

                _unitOfWork.Commit();

                var employeeModel = _mapper.Map<EmployeeEntity, EmployeeModel>(updatedEmployee);

                result.Employee = employeeModel;
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
