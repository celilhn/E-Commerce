using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class UserConfigurations : ExtendedBaseModelConfiguration<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.Name).HasColumnType("varchar(100)");
            builder.Property(x => x.Surname).HasColumnType("varchar(100)");
            builder.Property(x => x.UserName).HasColumnType("varchar(80)");
            builder.Property(x => x.Email).HasColumnType("varchar(100)");
            builder.Property(x => x.Password).HasColumnType("varchar(255)");
            builder.Property(x => x.ImageUrl).HasColumnType("varchar(256)");
            builder.Property(x => x.UserType).HasColumnType("int");
        }
    }
}
