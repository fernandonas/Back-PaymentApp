using FluentValidation;
using Payment.Domain.Validations;
using System;

namespace Payment.Domain.Entity
{
    public class PaymentType : BaseEntity
    {
        protected PaymentType() {}

        public PaymentType(string name)
        {
            Name = name;
            Validate();
        }

        public PaymentType(string name, Guid id)
        {
            Name = name;
            Id = id;


            Validate();
        }

        private void Validate()
        {
            var validate = new PaymentTypeValidator();
            validate.ValidateAndThrow(this);
        }


        public string Name { get; set; }
    }
}
