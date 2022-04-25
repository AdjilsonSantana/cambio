using Cambio_24.Data.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Cambio_24.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<Cambio24Context>

    {
        /// <summary>
        /// Set migrations in target database
        /// </summary>
        public Cambio24Context CreateDbContext(string[] args)
        {
            var connectionString = DatabaseConfig.DbConnection;
            var optionsBuilder = new DbContextOptionsBuilder<Cambio24Context>();
            optionsBuilder.UseNpgsql(connectionString);
            return new Cambio24Context(optionsBuilder.Options);
        }
    }
}
