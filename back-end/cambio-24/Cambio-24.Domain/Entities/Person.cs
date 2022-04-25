using System;

namespace Cambio_24.Domain.Entities
{
    public class Person : BaseEntity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime BirthDate { get; set; }
        public string Phonenumber { get; set; }
        public string TaxNumber { get; set; }
        public string DocNumber { get; set; }
        public long DocumentTypeId { get; set; }
        public DocumentTypeEntity DocumentType { get; set; }

    }
}
