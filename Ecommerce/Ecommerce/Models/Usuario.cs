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
            this.nome = null;
            this.telefone = null;
            this.tipo = null;
            this.cpf = cpf;
            this.senha = senha;
            this.endereco = null;
        }

        public string Nome { get => nome; set => nome = value; }
        public string Telefone { get => telefone; set => telefone = value; }
        public string Tipo { get => tipo; set => tipo = value; }
        public string Cpf { get => cpf; set => cpf = value; }
        public string Senha { get => senha; set => senha = value; }
        public string Endereco { get => endereco; set => endereco = value; }

        public string Login(string cpf, string senha)
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

                // Verifica se Existe no Banco
                if (leitor.HasRows)
                {
                    // Verifica se é Adm ou Cliente
                    if (leitor["Adm"].ToString() == "sim")
                    {
                        return "Bem-vindo, Adm";
                    }
                    else
                    {
                        return "Bem-vindo Cliente";
                    }
                }

                con.Close();

                return "ERRO";

            }
            catch (Exception e)
            {
                return "ERRO: " + e.Message;
            }
        }

        public string Cadastro(string nome, string cpf, string senha)
        {
            MySqlConnection con = new MySqlConnection(conexao);
            try
            {
                con.Open();
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
