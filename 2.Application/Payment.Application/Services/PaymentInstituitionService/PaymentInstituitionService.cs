using Payment.Application.Models.PaymentInstituition;
using Payment.Domain.Entity;
using Payment.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payment.Application.Services.PaymentInstituitionService
{
    public class PaymentInstituitionService : IPaymentInstituitionService
    {

        private readonly IPaymentInstituitionRepository _paymentInstituitionRepository;

        public PaymentInstituitionService(IPaymentInstituitionRepository paymentInstituitionRepository)
        {
            _paymentInstituitionRepository = paymentInstituitionRepository;
        }

        public async Task Add(PaymentInstituitionRequestModel request)
        {
            IsPaymentInstituitionlreadyRegistered(request.Name);

            var paymentInstituition = new PaymentInstituition(request.Name);

            await _paymentInstituitionRepository.Create(paymentInstituition);
        }

        public async Task Delete(Guid id)
        {
            await _paymentInstituitionRepository.Delete(id);
        }

        public IList<PaymentInstituitionResponseModel> GetAll()
        {
            var response = _paymentInstituitionRepository
                .GetAll()
                .Where(x => x.Active)
                .ToList();

            return response.Select(d => new PaymentInstituitionResponseModel
            {
                Name = d.Name,
                Id = d.Id,
                Active = d.Active,
                CreatedAt = d.CreatedAt,
                UpdatedAt = d.UpdatedAt
            }).ToList();
        }

        public async Task Update(Guid id, PaymentInstituitionRequestModel request)
        {
            IsPaymentInstituitionlreadyRegistered(request.Name);

            var paymentInstituition = new PaymentInstituition(request.Name, id);

            await _paymentInstituitionRepository.Update(id, paymentInstituition);
        }

        private void IsPaymentInstituitionlreadyRegistered(string paymentName)
        {
            var response = _paymentInstituitionRepository.GetAll().Any(x => x.Name == paymentName);
            if (response)
            {
                throw new Exception($"Instituição de pagamento {paymentName} já cadastrada!");
            }
        }
    }
}
