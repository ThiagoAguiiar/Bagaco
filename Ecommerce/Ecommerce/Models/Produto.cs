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

        public string Cadastro(string nome, double preco, int cod, int qtd)
        {
            MySqlConnection con = new MySqlConnection(conexao);

            try
            {
                con.Open();

                MySqlCommand comando = new MySqlCommand("INSERT INTO Produto VALUES (@nome, @preco, @cod, @quantidade)", con);
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
    }
} 

        //retorna uma lista de produtos
/*  public static List<Produto> Listar()
 {
     MySqlConnection con = new MySqlConnection(conexao);

     try
     {
         con.Open();
         MySqlCommand comando = new MySqlCommand("SELECT * FROM Produtos", con);
         MySqlDataReader leitor = comando.ExecuteReader();

         while (leitor.Read())
         {
             Produto p = new Produto(leitor["nome"].ToString(),
                 leitor["preco"].ToString(),
                 leitor["descricao"].ToString(),
                 leitor["cod"].ToString(),
                 leitor["qtd"].ToString());

         }


         con.Close();
     }
     catch (Exception e)
     {
         return null;
     }
 }
}
}

 */
