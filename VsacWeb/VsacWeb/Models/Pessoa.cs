using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VsacWeb.Models
{
    public class Pessoa
    {
        public Int64 Id { get; set; }
        public string Nome { get; set; }
        public string Rg { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }

        public string Telefone1 { get; set; }

        public string Telefone2 { get; set; }

        public Local Local { get; set; }

        public PerfilPessoa Perfil { get; set; } // Morador, Visitante, Prestador

        public byte Image { get; set; }


        public ICollection<PessoaVeiculo> Veiculos { get; set; }
        //public ICollection<PessoaLocal> Locais { get; set; }
        public ICollection<PessoaAnimal> Animais { get; set; }



    }
}
