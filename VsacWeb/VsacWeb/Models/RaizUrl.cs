using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VsacWeb.Models
{
    public class RaizUrl
    {
        public Int64 Id { get; set; }
        public string Nome { get; set; }

        public ICollection<Url> Urls { get; set; }
    }
}
