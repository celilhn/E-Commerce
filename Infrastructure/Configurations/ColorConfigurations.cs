using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class ColorConfigurations : ExtendedBaseModelConfiguration<Color>
    {
        public override void Configure(EntityTypeBuilder<Color> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.Name).HasColumnType("varchar(100)");
        }
    }
}
