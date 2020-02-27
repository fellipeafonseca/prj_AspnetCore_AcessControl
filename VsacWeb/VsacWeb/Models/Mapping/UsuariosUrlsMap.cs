using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VsacWeb.Models.Mapping
{
    public class UsuariosUrlsMap : IEntityTypeConfiguration<UsuarioUrls>
    {
        public void Configure(EntityTypeBuilder<UsuarioUrls> builder)
        {
          


            //builder.HasKey(pc => new { pc.AppUserId, pc.UrlId });

            builder.HasKey(pc => pc.Id);


            builder.HasOne(pc => pc.Usuario)
                .WithMany(c => c.UsuarioUrls)
                .HasForeignKey(pc => pc.AppUserId);

            builder.HasOne(pc => pc.Url)
               .WithMany(p => p.UsuarioUrls)
               .HasForeignKey(pc => pc.UrlId);



        }
    }
}
