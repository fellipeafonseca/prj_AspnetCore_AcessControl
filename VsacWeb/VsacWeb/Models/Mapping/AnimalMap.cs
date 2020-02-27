using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace VsacWeb.Models.Mapping
{
    public class AnimalMap : IEntityTypeConfiguration<Animal>
    {
       
        public void Configure(EntityTypeBuilder<Animal> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).HasMaxLength(200).IsRequired();
            builder.Property(x => x.Image).HasMaxLength(200).IsRequired(false);
            builder.Property(x => x.Porte).IsRequired(false);
            builder.Property(x => x.Sexo).IsRequired(false);

            builder.HasMany(x => x.Pessoas);   
        }
    }
}
