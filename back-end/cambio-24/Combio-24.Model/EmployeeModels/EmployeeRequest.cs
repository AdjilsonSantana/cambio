using Cambio_24.Models.UserModels;
using Combio_24.Model.DocumentTypeModels;
using System;
using System.ComponentModel.DataAnnotations;

namespace Combio_24.Model.EmployeeModels
{
    public class EmployeeRequest
    {
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Address { get; set; }
        public DateTime BirthDate { get; set; }
        [Required]
        public string Phonenumber { get; set; }
        [Required]
        public string DocNumber { get; set; }
        [Required]
        public string TaxNumber { get; set; }
        [Required]
        public long DocumentTypeId { get; set; }
        public DocumentTypeModel DocumentType { get; set; }
        [Required]
        public long UserId { get; set; }
        public UserModel User { get; set; }
    }
}
