using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VsacWeb.Models
{
    public class PessoaAnimal
    {
        public Int64 PessoaId { get; set; }

        public Int64 AnimalId { get; set; }

        public Animal Animal { get; set; }
        public Pessoa Pessoa { get; set; }
    }


}
