using Payment.Domain.Enums;
using System;

namespace Payment.Application.Models.Expense
{
    public class ExpenseRequestModel : ModelBase
    {
        public string Name { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal Amount { get; set; }
        public ExpenseType ExpenseType { get; set; }
        public Guid PaymentInstituitionId { get; set; }
        public Guid PaymentTypeId { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
    }
}
