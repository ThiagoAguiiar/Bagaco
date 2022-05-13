using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models
{
    public class Produto
    {
        static string conexao = "Server=ESN509VMYSQL;Database=bagaco;User id=aluno;Password=Senai1234";

        private string nome;
        private double preco;
        private string descricao;
        private int codigo;
        private int qtd;

        public Produto(string nome, double preco, string descricao, int codigo, int qtd)
        {
            this.nome = nome;
            this.preco = preco;
            this.descricao = descricao;
            this.codigo = codigo;
            this.qtd = qtd;
        }

        public string Nome { get => nome; set => nome = value; }
        public double Preco { get => preco; set => preco = value; }
        public string Descricao { get => descricao; set => descricao = value; }
        public int Codigo { get => codigo; set => codigo = value; }
        public int Qtd { get => qtd; set => qtd = value; }

        public string Cadastro(string nome, double preco, string descricao, int cod, int qtd)
        {
            MySqlConnection con = new MySqlConnection(conexao);

            try
            {
                con.Open();

                MySqlCommand comando = new MySqlCommand("INSERT INTO produto VALUES (@nome, @preco, @descricao, @cod, @quantidade)", con);
                comando.Parameters.AddWithValue("@nome", nome);
                comando.Parameters.AddWithValue("@preco", preco);
                comando.Parameters.AddWithValue("@descricao", descricao);
                comando.Parameters.AddWithValue("@cod", cod);
                comando.Parameters.AddWithValue("@quantidade", qtd);

                comando.ExecuteNonQuery();

                con.Close();

                return "Feito";


            }
            catch (Exception e)
            {
                return null;
            }
        }
        //retorna uma lista de produtos
        public static List<Produto> Listar()
        {
            List <Produto> lista = new List<Produto>();

            MySqlConnection con = new MySqlConnection(conexao);

            try
            {
                con.Open();
                MySqlCommand comando = new MySqlCommand("SELECT * FROM Produtos", con);
                MySqlDataReader leitor = comando.ExecuteReader();

                while (leitor.Read())
                {
                    Produto produto = new Produto(
                        leitor["nome"].ToString(),
                        Convert.ToDouble(leitor["preco"]),
                        leitor["descricao"].ToString(),
                        Convert.ToInt32(leitor["cod"]),
                        Convert.ToInt32(leitor["qtd"]));

                    lista.Add(produto);
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

     


