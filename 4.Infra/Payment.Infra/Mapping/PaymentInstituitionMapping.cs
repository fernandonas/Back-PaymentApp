using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Payment.Domain.Entity;

namespace Payment.Infra.Mapping
{
    public class PaymentInstituitionMapping : IEntityTypeConfiguration<PaymentInstituition>
    {
        public void Configure(EntityTypeBuilder<PaymentInstituition> builder)
        {
            builder.Property(x => x.Name);
        }
    }
}
