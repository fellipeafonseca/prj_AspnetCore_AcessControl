using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VsacWeb.Models
{
    public class UsuarioUrls
    {


        public Int64 Id { get; set; }
        public AppUser Usuario{ get; set; }
       

        public string AppUserId { get; set; }

        public Int64 UrlId { get; set; }
        public Url Url { get; set; }
    }
}
