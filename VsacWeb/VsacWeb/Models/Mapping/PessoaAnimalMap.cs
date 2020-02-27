using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace VsacWeb.Models.Mapping
{
    public class PessoaAnimalMap : IEntityTypeConfiguration<PessoaAnimal>
    {

        public void Configure(EntityTypeBuilder<PessoaAnimal> builder)
        {

            builder.HasKey(pa => new { pa.AnimalId, pa.PessoaId });
            builder.HasOne(pa => pa.Animal)
                .WithMany(a => a.Pessoas)
                .HasForeignKey(pa => pa.AnimalId);

            builder.HasOne(pa => pa.Pessoa)
               .WithMany(p => p.Animais)
               .HasForeignKey(pa => pa.PessoaId);


        }
    }
}
