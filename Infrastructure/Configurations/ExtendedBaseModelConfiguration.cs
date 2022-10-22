using Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using static Domain.Constants.Constants;

namespace Infrastructure.Configurations
{
    public class ExtendedBaseModelConfiguration<Model> : IEntityTypeConfiguration<Model> where Model : ExtendedBaseModel
    {
        public virtual void Configure(EntityTypeBuilder<Model> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.InsertionDate).HasColumnType("datetime").HasDefaultValueSql("GETDATE()");
            builder.Property(x => x.UpdateDate).HasColumnType("datetime").HasDefaultValueSql("GETDATE()");
            builder.Property(x=>x.Status).HasColumnType("tinyint").HasDefaultValue(StatusCodes.Active);
        }
    }
}
