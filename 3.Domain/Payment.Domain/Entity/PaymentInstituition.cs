using System;

namespace Payment.Domain.Entity
{
    public class PaymentInstituition : BaseEntity
    {
        protected PaymentInstituition() { }

        public PaymentInstituition(string name)
        {
            Name = name;
        }

        public PaymentInstituition(string name, Guid id)
        {
            Name = name;
            Id = id;
        }
        public string Name { get; set; }
    }
}
