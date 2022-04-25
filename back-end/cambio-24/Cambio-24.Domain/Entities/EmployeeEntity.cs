using System;

namespace Cambio_24.Domain.Entities
{
    public class EmployeeEntity : Person
    {
        public long UserId { get; set; }
        public UserEntity User { get; set; }

        private DateTime? _admissionDate;
        public DateTime? AdmissionDate
        {
            get { return _admissionDate; }
            set { _admissionDate = (value == null ? DateTime.UtcNow : value); }
        }

        public DateTime? ResignationDate { get; set; }
    }
}
