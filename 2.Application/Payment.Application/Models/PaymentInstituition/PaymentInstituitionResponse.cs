using System;

namespace Payment.Application.Models.PaymentInstituition
{
    public class PaymentInstituitionResponse : PaymentInstituitionModelBase
    {
        public Guid Id { get; set; }
        public bool Active { get; set; }
    }
}
