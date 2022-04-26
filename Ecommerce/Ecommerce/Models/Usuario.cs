using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce
{
    public class Usuario
    {
        private string nome;
        private string telefone;
        private string email;
        private string tipo;

        public string Nome { get => nome; set => nome = value; }
        public string Telefone { get => telefone; set => telefone = value; }
        public string Email { get => email; set => email = value; }
        public string Tipo { get => tipo; set => tipo = value; }

        public string CadastroCliente()
        {
           Usuario user = new Usuario();


        }

        public string EntraCliente()
        {

        }

        public string EntraAdm()
        { 
        
        }
    }
}
