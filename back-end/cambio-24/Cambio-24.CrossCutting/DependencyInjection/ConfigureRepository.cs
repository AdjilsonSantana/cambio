using Cambio_24.CrossCutting.Configuration;
using Cambio_24.CrossCutting.Configuration.Constants;
using Cambio_24.Data.Configuration;
using Cambio_24.Data.Context;
using Cambio_24.Data.Repository;
using Cambio_24.Data.SeedDb;
using Cambio_24.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Cambio_24.CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {


        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection)
        {
            var environment = EnvironmentConfiguration.Database == EnvironmentDatabaseEnum.Prod ? DatabaseConfig.DbConnection : DatabaseConfig.TestDbConnection;

            if (EnvironmentConfiguration.ConnectionString == EnvironmentDatabaseConnectionString.Postgre)
            {

                 environment = EnvironmentConfiguration.Database == EnvironmentDatabaseEnum.Prod ? DatabaseConfig.DbConnectionPostgre : DatabaseConfig.TestDbConnectionPostgre;
                
            }
           


            
            serviceCollection.AddTransient<SeedDb>();
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            serviceCollection.AddScoped(typeof(IUserRepository), typeof(UserRepository));
            serviceCollection.AddScoped(typeof(IEmployeeRepository), typeof(EmployeeRepository));
            serviceCollection.AddScoped(typeof(IDocumentTypeRepository), typeof(DocumentTypeRepository));
            serviceCollection.AddScoped(typeof(IClientRepository), typeof(ClientRepository));
            serviceCollection.AddScoped(typeof(IRateRepository), typeof(RateRepository));
            serviceCollection.AddScoped(typeof(IOperationTypeRepository), typeof(OperationTypeRepository));
            serviceCollection.AddScoped(typeof(IOperationRepository), typeof(OperationRepository));




            if (EnvironmentConfiguration.ConnectionString == EnvironmentDatabaseConnectionString.Postgre)
            {
                serviceCollection.AddDbContext<Cambio24Context>(
                options => options.UseNpgsql(environment)

            );
            }
            else
            {
                serviceCollection.AddDbContext<Cambio24Context>(
                options => options.UseSqlServer(environment)


            );

            }

        }
    }
}
