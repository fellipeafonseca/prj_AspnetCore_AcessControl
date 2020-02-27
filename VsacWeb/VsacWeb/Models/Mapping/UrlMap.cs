using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VsacWeb.Models.Mapping
{
    public class UrlMap : IEntityTypeConfiguration<Url>
    {
        public void Configure(EntityTypeBuilder<Url> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(c => c.Caminho).HasMaxLength(200).IsRequired();
            builder.HasMany(c => c.UsuarioUrls);
            builder.HasOne(c => c.RaizUrl);
        }
    }
}
