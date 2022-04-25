using Cambio_24.Data.Context;
using Cambio_24.Domain.Constants;
using Cambio_24.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cambio_24.Data.SeedDb
{
    public class SeedDb
    {
        private readonly Cambio24Context _context;
        public SeedDb(Cambio24Context context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();

            if (!_context.DocumentTypes.Any())
            {
                _context.DocumentTypes.Add(new DocumentTypeEntity
                {
                    //Id = 1,
                    DocTypeCode = "BI",
                    DocDescription = "Bilhete de Identidade",
                    CreatedAt = DateTime.Now
                });

                await _context.SaveChangesAsync();
            }

            if (!_context.Users.Any())
            {
                _context.Users.Add(new UserEntity
                {
                   // Id = 1,
                    Username = "cambio24",
                    Email = "cambio24@santech.pt",
                    Role = RoleConstants.Admin,
                    Password = "5FADV0glAXzBIHFHigM3ew==", //123456
                    Avatar = "https://api.adorable.io/avatars/326",
                    CreatedAt = DateTime.Now
                });
                await _context.SaveChangesAsync();
            }

            if (!_context.Employees.Any())
            {
                _context.Employees.Add(new EmployeeEntity
                {
                    //Id = 1,
                    Name = "Cambio24",
                    LastName = "Geral",
                    Address = "Aeroporto de São tomé",
                    BirthDate = DateTime.Now,
                    Phonenumber = "999999999",
                    TaxNumber = "999999999",
                    DocNumber = "0001",
                    DocumentTypeId = 1,
                    UserId = 1,
                    CreatedAt = DateTime.Now
                });

                await _context.SaveChangesAsync();
            }

            if (!_context.Clients.Any())
            {
                _context.Clients.Add(new ClientEntity
                {
                    //Id = 1,
                    Name = "Consomidor",
                    LastName = "Final",
                    Address = "Aeroporto de São tomé",
                    BirthDate = DateTime.Now,
                    Phonenumber = "999999999",
                    TaxNumber = "000000000",
                    DocNumber = "000",
                    DocumentTypeId = 1,
                    EmployeeId = 1,
                    CreatedAt = DateTime.Now
                });
                await _context.SaveChangesAsync();
            }

        }
    }
}
