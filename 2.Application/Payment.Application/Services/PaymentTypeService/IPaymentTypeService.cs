using Application.Models.PaymentType;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services.PaymentTypeService
{
    public interface IPaymentTypeService
    {
        Task Add(PaymentTypeRequest request);
        IList<PaymentTypeResponseModel> GetAll();
        Task Delete(Guid id);
        Task Update(Guid id, PaymentTypeRequest request);
    }
}