using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class SizeConfigurations : ExtendedBaseModelConfiguration<Size>
    {
        public override void Configure(EntityTypeBuilder<Size> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.Name).HasColumnType("varchar(10)");
        }
    }
}
