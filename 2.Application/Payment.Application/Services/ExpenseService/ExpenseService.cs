using Application.Models.PaymentType;
using Payment.Application.Models.Expense;
using Payment.Application.Models.PaymentInstituition;
using Payment.Domain.Entity;
using Payment.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payment.Application.Services.ExpenseService
{
    public class ExpenseService : IExpenseService
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
                    request.DueDate,
                    request.Invoice
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
                } : null,
                PaymentType = d.PaymentTypeId != null ? new PaymentTypeResponseModel()
                {
                    UpdatedAt = d.PaymentType.UpdatedAt,
                    Name = d.PaymentType.Name,
                    CreatedAt = d.PaymentType.CreatedAt,
                    Active = d.PaymentType.Active,
                    Id = d.PaymentType.Id
                } : null,
                Id = d.Id,
                Active = d.Active,
                CreatedAt = d.CreatedAt,
                UpdatedAt = d.UpdatedAt
            }).OrderBy(x => x.DueDate).ToList();
        }

        public async Task<ExpenseResponseModel> GetById(Guid id)
        {
            var expense = await _expenseRepository.GetExpenseWithEspenseTypeAndPaymentType(id);

            if (expense == null)
            {
                throw new Exception("Despesa não encontrada!");
            }

            var response = new ExpenseResponseModel
            {
                Name = expense.Name,
                PurchaseDate = expense.PurchaseDate,
                Amount = expense.Amount,
                ExpenseType = expense.ExpenseType,
                PaymentInstituitionId = expense.PaymentInstituitionId,
                PaymentTypeId = expense.PaymentTypeId,
                PaymentStatus = expense.PaymentStatus,
                PaymentDate = expense.PaymentDate,
                DueDate = expense.DueDate,
                PaymentInstituition = expense.PaymentInstituitionId != null ? new PaymentInstituitionResponse()
                {
                    Id = expense.PaymentInstituition.Id,
                    Active = expense.PaymentInstituition.Active,
                    CreatedAt = expense.PaymentInstituition.CreatedAt,
                    Name = expense.PaymentInstituition.Name,
                    UpdatedAt = expense.PaymentInstituition.UpdatedAt
                } : null,
                PaymentType = expense.PaymentTypeId != null ? new PaymentTypeResponseModel()
                {
                    UpdatedAt = expense.PaymentType.UpdatedAt,
                    Name = expense.PaymentType.Name,
                    CreatedAt = expense.PaymentType.CreatedAt,
                    Active = expense.PaymentType.Active,
                    Id = expense.PaymentType.Id
                } : null,
                Id = expense.Id,
                Active = expense.Active,
                CreatedAt = expense.CreatedAt,
                UpdatedAt = expense.UpdatedAt,
                Invoice = expense.Invoice
            };

            return response;
        }



        public async Task Delete(Guid id)
        {
            await _expenseRepository.Delete(id);
        }
    }
}
