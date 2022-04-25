using AutoMapper;
using Cambio_24.Data.UnitOfWork;
using Cambio_24.Domain.Entities;
using Cambio_24.Domain.Interfaces.Business.Authentication;
using Cambio_24.Models.AuthenticationModels;
using Cambio_24.Models.UserModels;
using Cambio_24.Security.Cryptography;
using Cambio_24.Security.Interfaces;
using System;

namespace Cambio_24.Business.Authentication
{
    public class AuthenticationLogic : IAuthenticationLogic
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJwtHandler _tokenHandler;

        public AuthenticationLogic(IUnitOfWork unitOfWork, IMapper mapper, IJwtHandler tokenHandler)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _tokenHandler = tokenHandler;
        }

        public AuthenticationModel GetTokenContent(string token)
        {
            return _tokenHandler.GetTokenContent(token);
        }

        public AuthenticationResponse SignIn(AuthenticationRequest request)
        {
            var response = new AuthenticationResponse();
            try
            {
                var user = _unitOfWork.UserRepository.GetByEmailOrUsername(request.Email);
                user ??= _unitOfWork.UserRepository.GetByEmailOrUsername(request.Username);
                if (user == null)
                {
                    response.Success = false;
                }
                else
                {
                    if (Cryptography.IsEqual(user.Password, request.Password))
                    {

                        response.User = _mapper.Map<UserEntity, UserModel>(user);
                        response.Token = $"{_tokenHandler.GenerateToken(user)}";
                        response.Success = true;

                        if (user.LastAccessAt == null)
                        {
                            response.FirstAccess = true;
                        }

                        user.LastAccessAt = DateTime.Now;
                        _unitOfWork.UserRepository.UpdateDateLastAccess(user.Email);
                        _unitOfWork.Commit();
                    }
                    else
                    {
                        response.Success = false;
                    }
                }
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = e.Message;
            }

            return response;
        }
    }
}
