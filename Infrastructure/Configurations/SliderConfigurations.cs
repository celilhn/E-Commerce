using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class SliderConfigurations : ExtendedBaseModelConfiguration<Slider>
    {
        public override void Configure(EntityTypeBuilder<Slider> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.ImageUrl).HasColumnType("varchar(255)");
            builder.Property(x => x.Text).HasColumnType("varchar(1000)");
            builder.Property(x => x.Href).HasColumnType("varchar(255)");
            builder.Property(x => x.ButtonText).HasColumnType("varchar(255)");
            builder.Property(x => x.ButtonColor).HasColumnType("varchar(255)");
        }
    }
}
