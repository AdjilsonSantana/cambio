using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cambio_24.Data.Configuration
{
    public class DatabaseConfig
    {
        // Database Postgre
        public static string DatabaseUserPostgre = "qmbnzwipyedpir";
        private static readonly string DatabaseNamePostgre = "d2ndp44qi71vf";
        private static readonly string DatabasePasswordPostgre = "6ae3252cbdc443cbf4e0e6c3934e1d07cb7eef1cf73a4c0947796e08ae7260d4";
        private static readonly string DatabaseHostPostgre = "ec2-54-220-35-19.eu-west-1.compute.amazonaws.com";

        public static string DbConnectionPostgre = $"server={DatabaseHostPostgre};Port=5432;Database={DatabaseNamePostgre};User ID ={DatabaseUserPostgre};Password={DatabasePasswordPostgre};sslmode=Require;Trust Server Certificate=true;";

        // Database to Test Postgre
        public static string TestDatabaseUserPostgre = "zfwditnizxzpuv";
        private static readonly string TestDatabaseNamePostgre = "d5vecm826ap5fp";
        private static readonly string TestDatabasePasswordPostgre = "0c230a3cd3611422583fe9cf222f5c2e6b94277757d8df906f116d20c10da911";
        private static readonly string TestDatabaseHostPostgre = "ec2-54-163-254-204.compute-1.amazonaws.com";

        public static string TestDbConnectionPostgre = $"Server={TestDatabaseHostPostgre};Port=5432;User ID ={TestDatabaseUserPostgre};Password={TestDatabasePasswordPostgre};Database={TestDatabaseNamePostgre};sslmode=Require;Trust Server Certificate=true;";

        // Database
        public static string DatabaseUser = "sa";
        private static readonly string DatabaseName = "cambio_24";
        private static readonly string DatabasePassword = "santech_123";

        public static string DbConnection = $"Server=(localDb)\\MSSQLLocalDB;user={DatabaseUser};password={DatabasePassword};database={DatabaseName}";
        //public static string DbConnection = $"Server=cambio_24.database.windows.net;user={DatabaseUser};password={DatabasePassword};database={DatabaseName};";

        // Database to Test
        public static string TestDatabaseUser = "sa";
        private static readonly string TestDatabaseName = "cambio_24_test";
        private static readonly string TestDatabasePassword = "santech_123";

        public static string TestDbConnection = $"Server=(localDb)\\MSSQLLocalDB;user={TestDatabaseUser};password={TestDatabasePassword};database={TestDatabaseName}";
        //public static string TestDbConnection = $"Server=cambio_24.database.windows.net;user={TestDatabaseUser};password={TestDatabasePassword};database={TestDatabaseName};";
    }
}
