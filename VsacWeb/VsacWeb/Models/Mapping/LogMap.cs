using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace VsacWeb.Models.Mapping
{
    public class LogMap : IEntityTypeConfiguration<Log>
    {

        public void Configure(EntityTypeBuilder<Log> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Data).IsRequired();
            builder.Property(x => x.Operacao).HasMaxLength(60).IsRequired();
            builder.Property(x => x.Tabela).HasMaxLength(60).IsRequired();
            builder.Property(x => x.ValorAntigo).HasMaxLength(200);
            builder.Property(x => x.ValorNovo).HasMaxLength(200);

            builder.HasOne(x => x.Usuario).WithMany(x => x.Logs);

        }
    }
}
