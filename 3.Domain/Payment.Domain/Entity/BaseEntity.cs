using System;

namespace Payment.Domain.Entity
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
        public bool Active { get; set; } = true;
    }
}
