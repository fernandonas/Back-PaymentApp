using Payment.Application.Models.PaymentInstituition;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Payment.Application.Services.PaymentInstituitionService
{
    public interface IPaymentInstituitionService
    {
        Task Add(PaymentInstituitionRequestModel request);
        IList<PaymentInstituitionResponseModel> GetAll();
        Task Delete(Guid id);
        Task Update(Guid id, PaymentInstituitionRequestModel request);
    }
}