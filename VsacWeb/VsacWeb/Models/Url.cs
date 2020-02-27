using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VsacWeb.Models
{
    public class Url
    {
        public Int64 Id { get; set; }
        public string Caminho { get; set; }

        public Int64 RaizUrlId { get; set; }
        public RaizUrl RaizUrl { get; set; }
        public ICollection<UsuarioUrls> UsuarioUrls { get; set; }
    }
}
