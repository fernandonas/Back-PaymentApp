using System;

namespace Payment.Domain.Entity
{
    public class PaymentInstituition : BaseEntity
    {
        protected PaymentInstituition() { }

        public PaymentInstituition(string name)
        {
            Name = name;
            CreatedAt = DateTime.Now;
        }

        public PaymentInstituition(string name, Guid id)
        {
            Name = name;
            Id = id;
            UpdatedAt = DateTime.Now;
        }
        public string Name { get; set; }
    }
}
