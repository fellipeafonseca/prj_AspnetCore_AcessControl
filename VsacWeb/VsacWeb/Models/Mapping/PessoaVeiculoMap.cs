using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace VsacWeb.Models.Mapping
{
    public class PessoaVeiculoMap : IEntityTypeConfiguration<PessoaVeiculo>
    {

        public void Configure(EntityTypeBuilder<PessoaVeiculo> builder)
        {
           
            builder.HasKey(pc => new { pc.CarroId, pc.PessoaId });
            builder.HasOne(pc => pc.Carro)
                .WithMany(c => c.Pessoas)
                .HasForeignKey(pc => pc.CarroId);

            builder.HasOne(pc => pc.Pessoa)
               .WithMany(p => p.Veiculos)
               .HasForeignKey(pc => pc.PessoaId);


        }
    }
}
