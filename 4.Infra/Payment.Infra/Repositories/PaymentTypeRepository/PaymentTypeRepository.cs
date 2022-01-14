using Payment.Domain.Entity;
using Payment.Domain.Interfaces;
using Payment.Infra.Context;
using Payment.Infra.Repositories.GenericRepository;

namespace Payment.Infra.Repositories.PaymentTypeRepository
{
    public class PaymentTypeRepository : GenericRepository<PaymentType>, IPaymentTypeRepository
    {
        public PaymentTypeRepository(MainContext dbContext) : base(dbContext)
        {
        }
    }
}
