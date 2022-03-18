using Application.Models.PaymentType;
using Payment.Domain.Entity;
using Payment.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services.PaymentTypeService
{
    public class PaymentTypeService : IPaymentTypeService
    {
        private readonly IPaymentTypeRepository _paymentTypeRepository;

        public PaymentTypeService(IPaymentTypeRepository paymentTypeRepository)
        {
            _paymentTypeRepository = paymentTypeRepository;
        }

        public async Task Add(PaymentTypeRequest request)
        {
            IsPaymentTypeAlreadyRegistered(request.Name);
            var paymentType = new PaymentType(request.Name);
            await _paymentTypeRepository.Create(paymentType);
        }

        public IList<PaymentTypeResponseModel> GetAll()
        {
            var response = _paymentTypeRepository
                .GetAll()
                .Where(x => x.Active)
                .ToList();

            var test = response.Select(d => new PaymentTypeResponseModel
            {
                Name = d.Name,
                Id = d.Id,
                Active = d.Active,
                CreatedAt = d.CreatedAt,
                UpdatedAt = d.UpdatedAt
            }).ToList();

            return test;
        }

        public async Task Delete(Guid id)
        {
            var response = await _paymentTypeRepository.GetById(id);

            if (response != null)
            {
                await _paymentTypeRepository.Delete(id);
            }
        }

        public async Task Update(Guid id, PaymentTypeRequest request)
        {
            IsPaymentTypeAlreadyRegistered(request.Name);

            var paymentType = new PaymentType(request.Name, id);

            await _paymentTypeRepository.Update(id, paymentType);
        }

        private void IsPaymentTypeAlreadyRegistered(string paymentName)
        {
            var response = _paymentTypeRepository.GetAll().Any(x => x.Name == paymentName);
            if (response)
            {
                throw new Exception($"Método de pagamento {paymentName} já cadastrado!");
            }
        }
    }
}
