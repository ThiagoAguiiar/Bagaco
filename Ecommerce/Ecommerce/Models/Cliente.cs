using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models
{
    public class Cliente : Usuario
    {
        private string endereco;

        public Cliente(string cpf, string senha) : base(cpf, senha)
        {

        }

    }
}
