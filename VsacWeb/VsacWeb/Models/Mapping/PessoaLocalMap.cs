using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace VsacWeb.Models.Mapping
{
    public class PessoaLocalMap : IEntityTypeConfiguration<PessoaLocal>
    {

        public void Configure(EntityTypeBuilder<PessoaLocal> builder)
        {

            //builder.HasKey(pr => new { pr.ResidenciaId, pr.PessoaId });
            //builder.HasOne(pr => pr.Residencia)
            //    .WithMany(r => r.Pessoas)
            //    .HasForeignKey(pr => pr.ResidenciaId);

            //builder.HasOne(pr => pr.Pessoa)
            //   .WithMany(p => p.Residencias)
            //   .HasForeignKey(pr => pr.PessoaId);


        }
    }
}
