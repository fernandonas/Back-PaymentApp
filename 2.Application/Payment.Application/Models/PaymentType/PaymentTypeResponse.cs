using System;

namespace Application.Models.PaymentType
{
    public class PaymentTypeResponse : PaymentTypeModelBase
    {
        public Guid Id { get; set; }
        public bool Active { get; set; }
    }
}
