using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Payment.Domain.Entity;

namespace Payment.Infra.Mapping
{
    public class ExpenseMapping : IEntityTypeConfiguration<Expense>
    {
        public void Configure(EntityTypeBuilder<Expense> builder)
        {
            builder.Property(x => x.Name);
            builder.Property(x => x.Amount);
            builder.Property(x => x.ExpenseType);
            builder.Property(x => x.PaymentStatus);
            builder.Property(x => x.PaymentInstituitionId);
            builder.Property(x => x.PaymentDate);
            builder.Property(x => x.DueDate);
            builder.Property(x => x.Invoice);
            builder.HasOne(x => x.PaymentType)
                .WithMany()
                .HasForeignKey(x => x.PaymentTypeId);
            builder.HasOne(x => x.PaymentInstituition)
                .WithMany()
                .HasForeignKey(x => x.PaymentInstituitionId);
        }
    }
}
