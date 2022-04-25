

using Cambio_24.Data.Mapping;
using Cambio_24.Domain.Constants;
using Cambio_24.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Cambio_24.Data.Context
{
    public class Cambio24Context : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<DocumentTypeEntity> DocumentTypes { get; set; }
        public DbSet<EmployeeEntity> Employees { get; set; }
        public DbSet<ClientEntity> Clients { get; set; }
        public DbSet<RateEntity> Rates { get; set; }
        public DbSet<OperationTypeEntity> OperationTypes { get; set; }
        public DbSet<OperationEntity> Operations { get; set; }



        public Cambio24Context(DbContextOptions<Cambio24Context> options) : base(options)
        {
            //Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserEntity>(new UserMap().Configure);
            modelBuilder.Entity<EmployeeEntity>(new EmployeeMap().Configure);
            modelBuilder.Entity<DocumentTypeEntity>(new DocumentTypeMap().Configure);
            modelBuilder.Entity<RateEntity>(new RateMap().Configure);
            modelBuilder.Entity<ClientEntity>(new ClientMap().Configure);
            modelBuilder.Entity<OperationTypeEntity>(new OperationTypeMap().Configure);
            modelBuilder.Entity<OperationEntity>(new OperationMap().Configure);

        }
    }
}
