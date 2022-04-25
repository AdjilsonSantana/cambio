using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cambio_24.Domain.Entities
{
    public class BaseEntity
    {
        [Column("id")]
        public long Id { get; set; }
        private DateTime? _createdAt;
        [Column("created_at")]
        public DateTime? CreatedAt
        {
            get { return _createdAt; }
            set { _createdAt = (value == null ? DateTime.UtcNow : value); }
        }
        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }
    }
}
