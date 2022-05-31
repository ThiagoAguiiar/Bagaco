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

        public Usuario(string cpf, string nome, string telefone, string senha, string tipo, string endereco)
        {
            this.cpf = cpf;
            this.nome = nome;
            this.telefone = telefone;
            this.senha = senha;
            this.tipo = tipo;
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
                    Usuario u = new Usuario(leitor["cpf"].ToString(),
                        leitor["nome"].ToString(),
                        leitor["Telefone"].ToString(),
                        leitor["senha"].ToString(),
                        leitor["Tipo"].ToString(),
                        leitor["endereco"].ToString());
                   
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
        public string Cadastro()
        {
            MySqlConnection con = new MySqlConnection(conexao);
            try
            {
                con.Open();

                //insere dados no banco
                MySqlCommand qry = new MySqlCommand("INSERT INTO Usuario VALUES (@cpf, @nome, @telefone, @senha, null, @endereco)", con);
                qry.Parameters.AddWithValue("@cpf", cpf);
                qry.Parameters.AddWithValue("@nome", nome);
                qry.Parameters.AddWithValue("@telefone", telefone);
                qry.Parameters.AddWithValue("@senha", senha);
                qry.Parameters.AddWithValue("@endereco", endereco);
                qry.ExecuteNonQuery();
                con.Close();

                return "Cadastro feito com sucesso";

            }
            catch (Exception e)
            {
                return "ERRO: " + e.Message;
            }
        }

        public string Promove()
        {
            MySqlConnection con = new MySqlConnection(conexao);
            try
            {
                con.Open();

                //atualiza o campo "tipo" 
                MySqlCommand qry = new MySqlCommand("UPDATE Usuario SET tipo ='Adm' WHERE cpf = @cpf", con);
                qry.Parameters.AddWithValue("@cpf", cpf);

                qry.ExecuteNonQuery();
                con.Close();

                return "Promoção feita";

            }
            catch (Exception e)
            {
                return null;
            }
        }

        public string Alterar(string cpf, string nome, string telefone, string senha, string endereco)
        {
            MySqlConnection con = new MySqlConnection(conexao);
            try
            {
                con.Open();
                MySqlCommand qry = new MySqlCommand("UPDATE Usuario Set nome = @nome, telefone = @telefone, senha = @senha, endereco = @endereco WHERE cpf= @cpf ", con);
                qry.Parameters.AddWithValue("@cpf", cpf);
                qry.Parameters.AddWithValue("@nome", nome);
                qry.Parameters.AddWithValue("@telefone", telefone);
                qry.Parameters.AddWithValue("@senha", senha);
                qry.Parameters.AddWithValue("@endereco", endereco);
                qry.ExecuteNonQuery();
                con.Close();

                return "Cadastro feito com sucesso";

            }
            catch (Exception e)
            {
                return null;
            }
        }
        public static List<Usuario> ListarClientes()
        {
            List<Usuario> lista = new List<Usuario>();

            MySqlConnection con = new MySqlConnection(conexao);

            try
            {
                con.Open();
                MySqlCommand comando = new MySqlCommand("SELECT * FROM Usuario WHERE tipo = 'Cliente'", con);
                MySqlDataReader leitor = comando.ExecuteReader();

                while (leitor.Read())
                {
                    Usuario u = new Usuario(leitor["cpf"].ToString(),
                        leitor["nome"].ToString(),
                        leitor["Telefone"].ToString(),
                        leitor["senha"].ToString(),
                        leitor["Tipo"].ToString(),
                        leitor["endereco"].ToString());

                    lista.Add(u);
                }
                con.Close();

                return lista;
            }

            catch (Exception e)
            {
                return null;
            }
        }


    }
}
