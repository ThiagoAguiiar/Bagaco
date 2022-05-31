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
        public static List<Produto> carrinho = new List<Produto>();

        private string nome;
        private double preco;
        private string descricao;
        private int codigo;
        private int qtd;
        private byte[] img;

        public Produto(string nome, double preco, string descricao, int codigo, int qtd, byte[] img)
        {
            this.nome = nome;
            this.preco = preco;
            this.descricao = descricao;
            this.codigo = codigo;
            this.qtd = qtd;
            this.img = img;
        }

        public string Nome { get => nome; set => nome = value; }
        public double Preco { get => preco; set => preco = value; }
        public string Descricao { get => descricao; set => descricao = value; }
        public int Codigo { get => codigo; set => codigo = value; }
        public int Qtd { get => qtd; set => qtd = value; }
        public byte[] Img { get => img; set => img = value; }

        public string Cadastro()
        {
            MySqlConnection con = new MySqlConnection(conexao);

            try
            {
                con.Open();

                MySqlCommand comando = new MySqlCommand("INSERT INTO produto VALUES (@nome, @preco, @descricao, @codigo, @quantidade,@imagem)", con);
                comando.Parameters.AddWithValue("@nome", nome);
                comando.Parameters.AddWithValue("@preco", preco);
                comando.Parameters.AddWithValue("@descricao", descricao);
                comando.Parameters.AddWithValue("@codigo", codigo);
                comando.Parameters.AddWithValue("@quantidade", qtd);
                comando.Parameters.AddWithValue("@imagem", img);

                comando.ExecuteNonQuery();

                con.Close();

                return "Feito";


            }
            catch (Exception e)
            {
                return "Erro " + e;
            }
        }
        //retorna uma lista de produtos
        public static List<Produto> Listar()
        {
            List<Produto> lista = new List<Produto>();

            MySqlConnection con = new MySqlConnection(conexao);

            try
            {
                con.Open();
                MySqlCommand comando = new MySqlCommand("SELECT * FROM Produto", con);
                MySqlDataReader leitor = comando.ExecuteReader();

                while (leitor.Read())
                {
                    byte[] imgBytes = (byte[])leitor["imagem"];
                    Produto produto = new Produto(
                        leitor["nome"].ToString(),
                        (Double)leitor["preco"],
                        leitor["descricao"].ToString(),
                        (int)leitor["codigo"],
                        (int)leitor["quantidade"],
                        imgBytes);

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

        // CARRINHO 
        public string AddCarrinho()
        {
            MySqlConnection con = new MySqlConnection(conexao);

            try
            {
                con.Open();
                MySqlCommand comando = new MySqlCommand("SELECT * FROM Produto WHERE codigo = @codigo", con);
                comando.Parameters.AddWithValue("@codigo", codigo);

                MySqlDataReader leitor = comando.ExecuteReader();

                while (leitor.Read())
                {
                    byte[] imgBytes = (byte[])leitor["imagem"];
                    Produto produto = new Produto(
                        leitor["nome"].ToString(),
                        (Double)leitor["preco"],
                        leitor["descricao"].ToString(),
                        (int)leitor["codigo"],
                        (int)leitor["quantidade"],
                        imgBytes);

                    if (carrinho.Count == 0)
                    {
                        carrinho.Add(produto);
                    }
                    else
                    {
                        foreach (var item in carrinho)
                        {
                            if (item.codigo == produto.codigo)
                            {
                                item.qtd += produto.qtd;
                            }
                            else
                            {
                                carrinho.Add(produto);
                            }
                        }
                    }
                }



                con.Close();

                return "Adicionado";
            }
            catch (Exception e)
            {
                return "Erro " + e;
            }
        }

        public static List<Produto> MostrarCarrinho()
        {
            try
            {

                return carrinho;

            } catch (Exception e)
            {
                return null;
            }
        }

        public string AlterarProduto(int codigo)
        {
            MySqlConnection con = new MySqlConnection(conexao);
            try
            {
               con.Open();
               MySqlCommand comando = new MySqlCommand("UPDATE Produto Set nome = @nome, preco = @preco, descricao = @descricao, codigo = @codigo, quantidade = @quantidade, imagem = @img WHERE codigo = @codigo", con);
               comando.Parameters.AddWithValue("@nome", nome);
               comando.Parameters.AddWithValue("@preco", preco);
               comando.Parameters.AddWithValue("@descricao", descricao);
               comando.Parameters.AddWithValue("@codigo", codigo);
               comando.Parameters.AddWithValue("@quantidade", qtd);
               comando.Parameters.AddWithValue("@img", img);

                comando.ExecuteNonQuery();

                con.Close();

               return "Alteração feita com sucesso";
            }
               catch (Exception e)
            {
               return null;
            }

        }

        public static List<Produto> RetornarDados(int codigo)
        { 
            MySqlConnection con = new MySqlConnection(conexao);

            List<Produto> lista = new List<Produto>();

            try
            {
                con.Open();
                MySqlCommand comando = new MySqlCommand("SELECT * FROM Produto WHERE codigo = @codigo", con);
                comando.Parameters.AddWithValue("@codigo", codigo);
                MySqlDataReader leitor = comando.ExecuteReader();

                while(leitor.Read())
                {
                    byte[] imgBytes = (byte[])leitor["imagem"];

                    Produto p = new Produto(
                        leitor["nome"].ToString(),
                        (Double)leitor["preco"],
                        leitor["descricao"].ToString(),
                        (int)leitor["codigo"],
                        (int)leitor["quantidade"],
                        imgBytes);

                    lista.Add(p);
                }

                return lista;

            } catch (Exception e)
            {
                
                return null;
            } finally
            {
                con.Close();
            }

        }


    }
}
           