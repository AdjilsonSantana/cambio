using AutoMapper;
using Cambio_24.Business.Authentication;
using Cambio_24.Business.Client;
using Cambio_24.Business.DocumentType;
using Cambio_24.Business.Employee;
using Cambio_24.Business.Operations;
using Cambio_24.Business.Rate;
using Cambio_24.Business.User;
using Cambio_24.Data.UnitOfWork;
using Cambio_24.Domain.Entities;
using Cambio_24.Domain.Helper.Converter;
using Cambio_24.Domain.Helper.Interface;
using Cambio_24.Domain.Interfaces.Business.Authentication;
using Cambio_24.Domain.Interfaces.Business.Client;
using Cambio_24.Domain.Interfaces.Business.DocumentType;
using Cambio_24.Domain.Interfaces.Business.Employee;
using Cambio_24.Domain.Interfaces.Business.Operations;
using Cambio_24.Domain.Interfaces.Business.Rate;
using Cambio_24.Domain.Interfaces.Business.User;
using Cambio_24.Framework.Authentication;
using Cambio_24.Framework.Client;
using Cambio_24.Framework.DocumentType;
using Cambio_24.Framework.Employee;
using Cambio_24.Framework.Interfaces;
using Cambio_24.Framework.Operations;
using Cambio_24.Framework.Rate;
using Cambio_24.Framework.User;
using Cambio_24.Models.UserModels;
using Cambio_24.Security.Authentication;
using Cambio_24.Security.Interfaces;
using Combio_24.Model.ClientModels;
using Combio_24.Model.DocumentTypeModels;
using Combio_24.Model.EmployeeModels;
using Combio_24.Model.OperationModels;
using Combio_24.Model.OperationTypeModels;
using Combio_24.Model.RatesModels;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Cambio_24.CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService(IServiceCollection serviceCollection)
        {
            //Session
            serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //UnitOfWork
            serviceCollection.AddTransient<IUnitOfWork, UnitOfWork>();

            //Framework
            serviceCollection.AddTransient<IUserFramework, UserFramework>();
            serviceCollection.AddTransient<IAuthenticationFramework, AuthenticationFramework>();
            serviceCollection.AddTransient<IEmployeeFramework, EmployeeFramework>();
            serviceCollection.AddTransient<IDocumentTypeFramework, DocumentTypeFramework>();
            serviceCollection.AddTransient<IClientFramework, ClientFramework>();
            serviceCollection.AddTransient<IRateFramework, RateFramework>();
            serviceCollection.AddTransient<IOperationTypeFramework, OperationTypeFramework>();
            serviceCollection.AddTransient<IOperationFramework, OperationFramework>();

            //Logic
            serviceCollection.AddTransient<IUserLogic, UserLogic>();
            serviceCollection.AddTransient<IAuthenticationLogic, AuthenticationLogic>();
            serviceCollection.AddTransient<IEmployeeLogic, EmployeeLogic>();
            serviceCollection.AddTransient<IDocumentTypeLogic, DocumentTypeLogic>();
            serviceCollection.AddTransient<IClientLogic, ClientLogic>();
            serviceCollection.AddTransient<IRateLogic, RateLogic>();
            serviceCollection.AddTransient<IOperationTypeLogic, OperationTypeLogic>();
            serviceCollection.AddTransient<IOperationLogic, OperationLogic>();

            //Helper
            serviceCollection.AddScoped<IConverterCalc, ConverterCalc>();

            //Security
            serviceCollection.AddTransient<IJwtHandler, JwtHandler>();
            //serviceCollection.AddTransient<ICertificateHandler, CertificateHandler>();

            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                #region User
                cfg.CreateMap<UserEntity, UserModel>();
                cfg.CreateMap<UserModel, UserEntity>();
                cfg.CreateMap<UserModel, UserRequest>();
                cfg.CreateMap<UserRequest, UserEntity>();
                cfg.CreateMap<UserResponse, UserEntity>();
                #endregion

                #region Employee
                cfg.CreateMap<EmployeeEntity, EmployeeModel>();
                cfg.CreateMap<EmployeeModel, EmployeeEntity>();
                cfg.CreateMap<EmployeeModel, EmployeeRequest>();
                cfg.CreateMap<EmployeeRequest, EmployeeEntity>();
                cfg.CreateMap<EmployeeResponse, EmployeeEntity>();
                #endregion

                #region Document Type
                cfg.CreateMap<DocumentTypeEntity, DocumentTypeModel>();
                cfg.CreateMap<DocumentTypeModel, DocumentTypeEntity>();
                cfg.CreateMap<DocumentTypeModel, DocumentTypeRequest>();
                cfg.CreateMap<DocumentTypeRequest, DocumentTypeEntity>();
                cfg.CreateMap<DocumentTypeResponse, DocumentTypeEntity>();
                #endregion

                #region Client
                cfg.CreateMap<ClientEntity, ClientModel>();
                cfg.CreateMap<ClientModel, ClientEntity>();
                cfg.CreateMap<ClientModel, ClientRequest>();
                cfg.CreateMap<ClientRequest, ClientEntity>();
                cfg.CreateMap<ClientResponse, ClientEntity>();
                #endregion


                #region Rate
                cfg.CreateMap<RateEntity, RateModel>();
                cfg.CreateMap<RateModel, RateEntity>();
                cfg.CreateMap<RateModel, RateRequest>();
                cfg.CreateMap<RateRequest, RateEntity>();
                cfg.CreateMap<RateResponse, RateEntity>();
                #endregion #region 

                #region Operation Type
                cfg.CreateMap<OperationTypeEntity, OperationTypeModel>();
                cfg.CreateMap<OperationTypeModel, OperationTypeEntity>();
                cfg.CreateMap<OperationTypeModel, OperationTypeRequest>();
                cfg.CreateMap<OperationTypeRequest, OperationTypeEntity>();
                cfg.CreateMap<OperationTypeResponse, OperationTypeEntity>();
                #endregion #region 

                #region Operation
                cfg.CreateMap<OperationEntity, OperationModel>();
                cfg.CreateMap<OperationModel, OperationEntity>();
                cfg.CreateMap<OperationModel, OperationRequest>();
                cfg.CreateMap<OperationRequest, OperationEntity>();
                cfg.CreateMap<OperationResponse, OperationEntity>();
                #endregion

            });

            IMapper mapper = config.CreateMapper();
            serviceCollection.AddSingleton(mapper);
        }
    }
}
