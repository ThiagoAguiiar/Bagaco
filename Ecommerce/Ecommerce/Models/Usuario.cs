using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models
{
    public class Usuario
    {
        static string conexao = "Server=ESN509VMYSQL;Database=bagaco;User id=aluno;Password=Senai1234";

        private string nome;
        private string telefone;
        private string tipo;
        private string cpf;
        private string senha;
        private string endereco;

        public Usuario(string nome, string telefone, string tipo, string cpf, string senha, string endereco)
        {
            this.nome = nome;
            this.telefone = telefone;
            this.tipo = tipo;
            this.cpf = cpf;
            this.senha = senha;
            this.endereco = endereco;
        }

        public string Nome { get => nome; set => nome = value; }
        public string Telefone { get => telefone; set => telefone = value; }
        public string Tipo { get => tipo; set => tipo = value; }
        public string Cpf { get => cpf; set => cpf = value; }
        public string Senha { get => senha; set => senha = value; }
        public string Endereco { get => endereco; set => endereco = value; }

        public static Usuario Entra(string cpf, string senha)
        {
            MySqlConnection con = new MySqlConnection(conexao);

            try
            {
                // Abre a Conexão
                con.Open();
                MySqlCommand qry = new MySqlCommand("SELECT * FROM Usuario WHERE cpf = @cpf AND senha = @senha", con);
                qry.Parameters.AddWithValue("@cpf", cpf);
                qry.Parameters.AddWithValue("@senha", senha);

                MySqlDataReader leitor = qry.ExecuteReader();
                leitor.Read();

                // Verifica se existe no Banco
                if (leitor.HasRows)
                {
                    Usuario u = new Usuario(leitor["nome"].ToString(),
                        leitor["telefone"].ToString(),
                        leitor["Tipo"].ToString(),
                        leitor["cpf"].ToString(),
                        leitor["senha"].ToString(),
                        leitor["endereco"].ToString());
                    // Verifica se é Adm ou Cliente no banco e retorna para o Controller
                     return u; 
                    
                }

                con.Close();
                return null;

            }
            catch (Exception e)
            {
                return null;
            }
        }

        //alterar a parte de cadastro
        public string Cadastro(string nome, string cpf, string senha)
        {
            MySqlConnection con = new MySqlConnection(conexao);
            try
            {
                con.Open();

                //insere dados no banco
                MySqlCommand qry = new MySqlCommand("INSERT INTO Usuario VALUES (@cpf, @nome, null, @senha, null, null)", con);
                qry.Parameters.AddWithValue("@nome", nome);
                qry.Parameters.AddWithValue("@cpf", cpf);
                qry.Parameters.AddWithValue("@senha", senha);
                qry.ExecuteNonQuery();
                con.Close();

                return "Seja Bem-Vindo!";

            }
            catch (Exception e)
            {
                return "ERRO: " + e.Message;
            }
        }
    }
}
