using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce
{
    public class Usuario
    {
        static string conexao = "Server=ESN509VMYSQL;Database=bagaco;User id=aluno;Password=Senai1234";

        
        private string nome;
        private string telefone;
        private string email;
        private string tipo;
        private string cpf;
        private string senha;

        public Usuario(string cpf, string senha)
        {
            this.senha = senha;
            this.cpf = cpf;
        }

        public string Nome { get => nome; set => nome = value; }
        public string Telefone { get => telefone; set => telefone = value; }
        public string Email { get => email; set => email = value; }
        public string Tipo { get => tipo; set => tipo = value; }
        public string Cpf { get => cpf; set => cpf = value; }
        public string Senha { get => senha; set => senha = value; }

        public string Entra(string cpf, string senha)
        {
            
            MySqlConnection con = new MySqlConnection(conexao);
            MySqlCommand qry = new MySqlCommand("SELECT FROM Usuario(CPF) WHERE = '@cpf'", con);
          

            MySqlDataReader leitor = qry.ExecuteReader();

            try{
                

            }
            catch (Exception e)
            {
                return 
            }
            


            try
            {
                //abre a conexão
                con.Open();

            }
            catch (Exception e)
            {
                return null;
            }


        }
    }
}
