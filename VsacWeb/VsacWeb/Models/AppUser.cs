using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VsacWeb.Models
{
    public class AppUser:IdentityUser
    {

     
        public string Nome { get; set; }
        public string Sobrenome { get; set; }

       
        public ICollection<UsuarioUrls> UsuarioUrls { get; set; }

        public ICollection<Log> Logs { get; set; }
    }
}
