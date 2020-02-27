using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VsacWeb.Models
{
    public class TipoLocal
    {
        public Int64 Id { get; set; }
        public string Nome { get; set; }

        public IEnumerable<Local> Locais { get; set; }

    }
}
