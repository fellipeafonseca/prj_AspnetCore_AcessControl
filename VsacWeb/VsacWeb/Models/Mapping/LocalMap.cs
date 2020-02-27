using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace VsacWeb.Models.Mapping
{
    public class LocalMap :  IEntityTypeConfiguration<Local>
    {
        public void Configure(EntityTypeBuilder<Local> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome).HasMaxLength(200).IsRequired(false);
            builder.Property(x => x.Endereco).HasMaxLength(200).IsRequired(false);
            builder.Property(x => x.Bloco).HasMaxLength(200).IsRequired(false);
            builder.Property(x => x.Numero).HasMaxLength(60).IsRequired(false);
            builder.Property(x => x.Complemento).HasMaxLength(200).IsRequired(false);


            builder.HasOne(x => x.TipoLocal);
          //  builder.HasOne(x => x.Pessoa);

           
        }


    }
}
