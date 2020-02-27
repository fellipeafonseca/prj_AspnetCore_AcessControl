using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VsacWeb.Models
{
    public class PerfilPessoa
    {
        public Int64 Id { get; set; }
        public string Nome { get; set; }

        public ICollection<Pessoa> Pessoas { get; set; }
    }
}
