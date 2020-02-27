using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VsacWeb.Models
{
    public class PessoaVeiculo
    {
       // [Required (ErrorMessage ="oi")]
        [Display (Name = "Pessoa")]
        public Int64 PessoaId { get; set; }

        public Int64 CarroId { get; set; }

        public Veiculo Carro { get; set; }
        public Pessoa Pessoa { get; set; }
    }


}
