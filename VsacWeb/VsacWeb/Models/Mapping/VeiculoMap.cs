using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VsacWeb.Models.Mapping
{
    public class VeiculoMap : IEntityTypeConfiguration<Veiculo>
    {
      

        public void Configure(EntityTypeBuilder<Veiculo> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome).HasMaxLength(200).IsRequired();
            builder.Property(x => x.Placa).HasMaxLength(10).IsRequired();
            builder.Property(x => x.Ano);
            builder.Property(x => x.Image).HasMaxLength(200);
            builder.HasMany(x => x.Pessoas);
            

        }
    }
}
