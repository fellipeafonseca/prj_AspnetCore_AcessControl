using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VsacWeb.Models
{
    public class Veiculo
    {
        public Int64 Id { get; set; }
        public string Nome { get; set; }
        public int Ano { get; set; }
        public string Placa { get; set; }

        public byte Image { get; set; }

        public ICollection<PessoaVeiculo> Pessoas { get; set; }
    }
}
