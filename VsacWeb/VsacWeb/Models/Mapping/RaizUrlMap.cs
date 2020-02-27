using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VsacWeb.Models.Mapping
{
    public class RaizUrlMap : IEntityTypeConfiguration<RaizUrl>
    {
       

        public void Configure(EntityTypeBuilder<RaizUrl> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(c => c.Nome).HasMaxLength(200).IsRequired();
            builder.HasMany(c => c.Urls);

        }
    }
}
