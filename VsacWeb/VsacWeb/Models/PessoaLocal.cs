using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VsacWeb.Models
{
    public class PessoaLocal
    {
        public Int64 PessoaId { get; set; }

        public Int64 ResidenciaId { get; set; }

        public Local Residencia { get; set; }
        public Pessoa Pessoa { get; set; }

        public DateTime Data { get; set; }
    }

    
}
