using EWallet.DataAcess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EWallet.DataAcess.Configurations
{
    public class OtpConfiguration : IEntityTypeConfiguration<OtpEntity>
    {
        public void Configure(EntityTypeBuilder<OtpEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Email)
                .HasMaxLength(100);
            builder.HasAlternateKey(x => x.Email);


            builder.Property(x => x.Reference)
                .HasMaxLength(10);
            builder.Property(x => x.Otp)
                .HasMaxLength(10);

            builder.Property(x => x.CreateDateTime);
        }
    }
}
