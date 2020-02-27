using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VsacWeb.Models
{
    public class Log
    {
     
        public Int64 Id { get; set; }
        public string Tabela { get; set; }
        public DateTime Data { get; set; }
        public string Operacao { get; set; }
     
        public string ValorAntigo { get; set; }
        public string ValorNovo { get; set; }

        public string AppUserId { get; set; }
        public AppUser Usuario { get; set; }

    }
}
