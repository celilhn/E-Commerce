using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class LoginLogConfigurations : ExtendedBaseModelConfiguration<LoginLog>
    {
        public override void Configure(EntityTypeBuilder<LoginLog> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.Email).HasColumnType("varchar(255)");
            builder.Property(x => x.HashPassword).HasColumnType("varchar(255)");
            builder.Property(x => x.LoginStatus).HasColumnType("int");
            builder.Property(x => x.LoginType).HasColumnType("int");
        }
    }
}
