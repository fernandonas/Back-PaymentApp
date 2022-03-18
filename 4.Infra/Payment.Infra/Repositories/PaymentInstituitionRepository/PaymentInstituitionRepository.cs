using Payment.Domain.Entity;
using Payment.Domain.Interfaces;
using Payment.Infra.Context;
using Payment.Infra.Repositories.GenericRepository;

namespace Payment.Infra.Repositories.PaymentInstituitionRepository
{
    public class PaymentInstituitionRepository : GenericRepository<PaymentInstituition>, IPaymentInstituitionRepository
    {
        public PaymentInstituitionRepository(MainContext dbContext) : base(dbContext)
        {
        }
    }
}
