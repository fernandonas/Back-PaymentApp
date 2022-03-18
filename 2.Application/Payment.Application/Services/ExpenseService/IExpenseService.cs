using Payment.Application.Models.Expense;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Payment.Application.Services.ExpenseService
{
    public interface IExpenseService : IExpenseServiceGetters, IExpenseServiceCommand
    {
    }

    public interface IExpenseServiceCommand
    {
        Task Add(ExpenseRequestModel request);
        Task Delete(Guid id);
    }

    public interface IExpenseServiceGetters
    {
        Task<IList<ExpenseResponseModel>> GetAll();
        Task<ExpenseResponseModel> GetById(Guid id);
    }
}