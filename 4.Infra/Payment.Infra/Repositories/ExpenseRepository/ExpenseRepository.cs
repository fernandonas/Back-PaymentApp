using Microsoft.EntityFrameworkCore;
using Payment.Domain.Entity;
using Payment.Domain.Interfaces;
using Payment.Infra.Context;
using Payment.Infra.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payment.Infra.Repositories.ExpenseRepository
{
    public class ExpenseRepository : GenericRepository<Expense>, IExpenseRepository
    {
        public ExpenseRepository(MainContext dbContext) : base(dbContext)
        {
        }

        public async Task<IList<Expense>> GetExpenseListWithEspenseTypeAndPaymentType()
        {
            return await _dbContext.Set<Expense>()
                .Include(x => x.PaymentType)
                .Include(x => x.PaymentInstituition)
                .ToListAsync();
        }

        public async Task<Expense> GetExpenseWithEspenseTypeAndPaymentType(Guid id)
        {
            return await _dbContext.Set<Expense>()
                .Include(x => x.PaymentType)
                .Include(x => x.PaymentInstituition)
                .Where(x => x.Id == id).FirstOrDefaultAsync();
        }
    }
}
