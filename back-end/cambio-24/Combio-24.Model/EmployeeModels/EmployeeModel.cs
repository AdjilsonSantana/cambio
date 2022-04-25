using Cambio_24.Models.UserModels;
using Combio_24.Model.DocumentTypeModels;
using System;

namespace Combio_24.Model.EmployeeModels
{
    public class EmployeeModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime BirthDate { get; set; }
        public string Phonenumber { get; set; }
        public string TaxNumber { get; set; }
        public string DocNumber { get; set; }
        public long UserId { get; set; }
        public UserModel User { get; set; }
        public long DocumentTypeId { get; set; }
        public DocumentTypeModel DocumentType { get; set; }
        public DateTime AdmissionDate { get; set; }
        public DateTime ResignationDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
