using Combio_24.Model.DocumentTypeModels;
using Combio_24.Model.EmployeeModels;
using System;
using System.ComponentModel.DataAnnotations;

namespace Combio_24.Model.ClientModels
{
    public class ClientRequest
    {
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        public string Address { get; set; }
        //[EmailAddress]
        public string Email { get; set; }
        //[DataType(DataType.Date)]
        public string BirthDate { get; set; }
        public string Phonenumber { get; set; }
        [Required]
        public string TaxNumber { get; set; }
        [Required]
        public string DocNumber { get; set; }
        [Required]
        public long DocumentTypeId { get; set; }
        public DocumentTypeModel DocumentType { get; set; }
        [Required]
        public long EmployeeId { get; set; }
        public EmployeeModel Employee { get; set; }
    }
}
