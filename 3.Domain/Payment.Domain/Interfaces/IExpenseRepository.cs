using Payment.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Payment.Domain.Interfaces
{
    public interface IExpenseRepository: IGenericRepository<Expense>
    {
        Task<IList<Expense>> GetExpenseListWithEspenseTypeAndPaymentType();
        Task<Expense> GetExpenseWithEspenseTypeAndPaymentType(Guid id);
    }
}
