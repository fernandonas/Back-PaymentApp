using Payment.Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Payment.Domain.Interfaces
{
    public interface IExpenseRepository: IGenericRepository<Expense>
    {
        Task<IList<Expense>> GetExpenseListWithEspenseTypeAndPaymentType();
    }
}
