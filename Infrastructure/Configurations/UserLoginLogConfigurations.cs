using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class UserLoginLogConfigurations : ExtendedBaseModelConfiguration<UserLoginLog>
    {
        public override void Configure(EntityTypeBuilder<UserLoginLog> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.Email).HasColumnType("varchar(255)");
            builder.Property(x => x.HashPassword).HasColumnType("varchar(255)");
            builder.Property(x => x.LoginStatus).HasColumnType("int");
        }
    }
}
