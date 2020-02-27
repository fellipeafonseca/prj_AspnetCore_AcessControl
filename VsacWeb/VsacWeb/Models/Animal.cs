using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VsacWeb.Models
{
    public class Animal
    {

        public Int64 Id { get; set; }
        public string Nome { get; set; }
        public byte Image { get; set; }

        public ESexo Sexo { get; set; }

        public ETamanho Porte { get; set; }
        public ICollection<PessoaAnimal> Pessoas { get; set; }
    }
}
