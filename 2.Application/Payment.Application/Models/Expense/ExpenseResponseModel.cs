using Application.Models.PaymentType;
using Payment.Application.Models.PaymentInstituition;

namespace Payment.Application.Models.Expense
{
    public class ExpenseResponseModel : ExpenseRequestModel
    {
        public PaymentInstituitionResponse PaymentInstituition { get; set; }
        public PaymentTypeResponseModel PaymentType { get; set; }
    }
}
