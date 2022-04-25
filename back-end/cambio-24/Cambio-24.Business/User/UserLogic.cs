using AutoMapper;
using Cambio_24.Data.UnitOfWork;
using Cambio_24.Domain.Constants;
using Cambio_24.Domain.Entities;
using Cambio_24.Domain.Interfaces.Business.User;
using Cambio_24.Models.UserModels;
using Cambio_24.Security.Cryptography;
using System;
using System.Collections.Generic;

namespace Cambio_24.Business.User
{
    public class UserLogic : IUserLogic
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UserLogic(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public UserResponse Get()
        {
            var result = new UserResponse();

            try
            {
                var users = _unitOfWork.UserRepository.Get();
                result.Users = _mapper.Map<IEnumerable<UserEntity>, IEnumerable<UserModel>>(users);
                result.Success = true;

            }
            catch (Exception)
            {
                result.Success = false;
            }

            return result;
        }

        public UserResponse Get(long id)
        {
            var result = new UserResponse();

            try
            {
                var user = _unitOfWork.UserRepository.Get(id);
                var userModel = _mapper.Map<UserEntity, UserModel>(user);
                result.User = userModel;
                result.Success = true;

            }
            catch (Exception)
            {
                result.Success = false;
            }

            return result;
        }

        public UserResponse GetByEmailOrUsername(string email)
        {
            var result = new UserResponse();

            try
            {
                var user = _unitOfWork.UserRepository.GetByEmailOrUsername(email);
                var userModel = _mapper.Map<UserEntity, UserModel>(user);
                result.User = userModel;
                result.Success = true;

            }
            catch (Exception)
            {
                result.Success = false;
            }

            return result;
        }

        public UserResponse Insert(UserRequest user, string role = "")
        {
            var result = new UserResponse();

            try
            {
                var storedUser = _unitOfWork.UserRepository.GetByEmailOrUsername(user.Email);

                if (storedUser != null)
                {
                    result.Success = false;
                    result.Message = "Already exists";
                }
                else
                {
                    user.Role = role == RoleConstants.Admin ? user.Role : RoleConstants.Operator;
                    //Todo para analizar, se preferivel colocar imagem
                    user.Avatar = $"https://api.adorable.io/avatars/{new Random().Next(10000)}";
                    user.Password = Cryptography.Encrypt(user.Password);
                    var userEntity = _mapper.Map<UserRequest, UserEntity>(user);
                    var createdUser = _unitOfWork.UserRepository.Insert(userEntity);

                    _unitOfWork.Commit();

                    result.User = _mapper.Map<UserEntity, UserModel>(createdUser);
                    result.Success = true;
                }
            }
            catch (Exception e)
            {
                if (e.InnerException.Message.Contains("duplicate"))
                {
                    result.Success = false;
                    result.Message = "Já existe um utilizador com esse email ou username";
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

        public UserResponse Update(UserRequest user)
        {
            var result = new UserResponse();

            try
            {
                var userEntity = _mapper.Map<UserRequest, UserEntity>(user);
                userEntity.UpdatedAt = DateTime.UtcNow;
                var updatedUser = _unitOfWork.UserRepository.Update(userEntity);

                _unitOfWork.Commit();

                var userModel = _mapper.Map<UserEntity, UserModel>(updatedUser);

                result.User = userModel;
                result.Success = true;
            }
            catch (Exception e)
            {
                _unitOfWork.Rollback();
                result.Success = false;
            }

            return result;
        }

        public UserResponse Delete(long id)
        {
            var result = new UserResponse();

            try
            {
                var isDeleted = _unitOfWork.UserRepository.Delete(id);

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



    }
}
