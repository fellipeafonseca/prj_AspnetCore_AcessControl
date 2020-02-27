using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace VsacWeb.Models.Mapping
{
    public class PessoaMap : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome).HasMaxLength(200).IsRequired();
            builder.Property(x => x.CPF).HasMaxLength(11).IsRequired();
            builder.Property(x => x.Rg).HasMaxLength(11);
            builder.Property(x => x.Image).HasMaxLength(200);
            builder.Property(x => x.DataNascimento);



            builder.HasOne(x => x.Local);
            builder.HasOne(x => x.Perfil).WithMany(t => t.Pessoas);


        }


    }
}
