using Payment.Application.Models.PaymentInstituition;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Payment.Application.Services.PaymentInstituitionService
{
    public interface IPaymentInstituitionService
    {
        Task Add(PaymentInstituitionRequest request);
        IList<PaymentInstituitionResponse> GetAll();
        Task Delete(Guid id);
        Task Update(Guid id, PaymentInstituitionRequest request);
    }
}