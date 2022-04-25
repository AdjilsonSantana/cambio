using Combio_24.Model.DocumentTypeModels;
using Combio_24.Model.EmployeeModels;
using System;

namespace Combio_24.Model.ClientModels
{
    public class ClientModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string Phonenumber { get; set; }
        public string TaxNumber { get; set; }
        public string DocNumber { get; set; }
        public long DocumentTypeId { get; set; }
        public DocumentTypeModel DocumentType { get; set; }
        public long EmployeeId { get; set; }
        public EmployeeModel Employee { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
