using System;

namespace Payment.Application.Models
{
    public abstract class ModelBase
    {
        public Guid Id { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
