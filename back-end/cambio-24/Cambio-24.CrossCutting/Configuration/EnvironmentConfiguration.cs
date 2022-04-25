using Cambio_24.CrossCutting.Configuration.Constants;

namespace Cambio_24.CrossCutting.Configuration
{
    public static class EnvironmentConfiguration
    {
        public static EnvironmentEnum Environment = EnvironmentEnum.Prod;
        public static EnvironmentDatabaseEnum Database = EnvironmentDatabaseEnum.Dev;
        public static EnvironmentDatabaseConnectionString ConnectionString = EnvironmentDatabaseConnectionString.Postgre;
    }
}
