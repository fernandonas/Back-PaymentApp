using Application.Models.PaymentType;
using Payment.Application.Models.Expense;
using Payment.Application.Models.PaymentInstituition;
using Payment.Domain.Entity;
using Payment.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Application.Services.ExpenseService
{
    public class ExpenseService
    {
        private readonly IExpenseRepository _expenseRepository;

        public ExpenseService(IExpenseRepository expenseRepository)
        {
            _expenseRepository = expenseRepository;
        }

        public async Task Add(ExpenseRequestModel request)
        {
            var expense = new Expense(
                    request.Name,
                    request.PurchaseDate,
                    request.Amount,
                    request.ExpenseType,
                    request.PaymentInstituitionId,
                    request.PaymentTypeId,
                    request.PaymentStatus,
                    request.PaymentDate,
                    request.DueDate
                );

            await _expenseRepository.Create(expense);
        }

        public async Task<IList<ExpenseResponseModel>> GetAll()
        {
            var response = await _expenseRepository
                .GetExpenseListWithEspenseTypeAndPaymentType();

            return response.Select(d => new ExpenseResponseModel
            {
                Name = d.Name,
                PurchaseDate = d.PurchaseDate,
                Amount = d.Amount,
                ExpenseType = d.ExpenseType,
                PaymentInstituitionId = d.PaymentInstituitionId,
                PaymentTypeId = d.PaymentTypeId,
                PaymentStatus = d.PaymentStatus,
                PaymentDate = d.PaymentDate,
                DueDate = d.DueDate,
                PaymentInstituition = d.PaymentInstituitionId != null ? new PaymentInstituitionResponse()
                {
                    Id = d.PaymentInstituition.Id,
                     Active = d.PaymentInstituition.Active,
                     CreatedAt = d.PaymentInstituition.CreatedAt,
                     Name = d.PaymentInstituition.Name,
                     UpdatedAt = d.PaymentInstituition.UpdatedAt
                }: null,
                PaymentType = d.PaymentTypeId != null ? new PaymentTypeResponseModel()
                {
                    UpdatedAt = d.PaymentType.UpdatedAt,
                    Name = d.PaymentType.Name,
                    CreatedAt = d.PaymentType.CreatedAt,
                    Active = d.PaymentType.Active,
                    Id = d.PaymentType.Id
                }: null,
                Id = d.Id,
                Active = d.Active,
                CreatedAt = d.CreatedAt,
                UpdatedAt = d.UpdatedAt
            }).ToList();
        }

        public async Task Delete(Guid id)
        {
            await _expenseRepository.Delete(id);
        }

    }
}
