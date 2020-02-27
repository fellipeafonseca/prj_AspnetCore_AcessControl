using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VsacWeb.Models.Mapping
{
    public class PerfilPessoaMap : IEntityTypeConfiguration<PerfilPessoa>
    {
        public void Configure(EntityTypeBuilder<PerfilPessoa> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome).HasMaxLength(200).IsRequired();
            builder.HasMany(x => x.Pessoas).WithOne(c => c.Perfil);
        }
    }
}
