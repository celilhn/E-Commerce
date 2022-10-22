using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class FaqConfigurations : ExtendedBaseModelConfiguration<Faq>
    {
        public override void Configure(EntityTypeBuilder<Faq> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.Answer).HasColumnType("varchar(1500)");
            builder.Property(x => x.Question).HasColumnType("varchar(1500)");
        }
    }
}
