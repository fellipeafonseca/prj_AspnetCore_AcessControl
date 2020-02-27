using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace VsacWeb.Models
{
    public class Local
    {
        public Int64 Id { get; set; }

        public string Nome { get; set; }
        public string Endereco { get; set; }
        public String Bloco { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }

        public TipoLocal TipoLocal { get; set; }

       // public Pessoa Pessoa { get; set; }

        //  public ICollection<PessoaLocal> Pessoas{ get; set; }

    }

    
}
