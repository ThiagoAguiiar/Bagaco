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

                return "Produto cadastrado com sucesso!";


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
        public string AddCarrinho(int quantidade)
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
                        quantidade,
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

                return "Produto adicionado ao carrinho";
            }
            catch (Exception e)
            {
                return "Erro " + e;
            }
        }

        public static string AlterarCarrinho(List<int> lista)
        {

            try
            {
                int i = 0;

                foreach(var item in carrinho)
                {
                    item.qtd = lista[i];

                    i++;
                }

                return "Alterado com Sucesso";

            } catch(Exception e)
            {
                return "Erro: " + e;
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

        public static string Deletar(int id)
        {
            try
            {
                carrinho.RemoveAt(id);

                return "Removido com Sucesso";

            }
            catch (Exception e)
            {

                return "Erro " + e;

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

        public static string FinalizarCompra(string cpf)
        {
            MySqlConnection con = new MySqlConnection(conexao);
            int idPedido = 0;

            try
            {
                con.Open();

                MySqlCommand qry = new MySqlCommand("SELECT COUNT(DISTINCT id_pedido) FROM Pedido", con);

                MySqlDataReader leitor = qry.ExecuteReader();

                if(leitor.Read())
                {
                    string aux;
                    aux = leitor["COUNT(DISTINCT id_pedido)"].ToString();

                    idPedido = int.Parse(aux);
                }

                leitor.Close();

                foreach(var item in carrinho)
                {
                    MySqlCommand comando = new MySqlCommand("INSERT INTO Pedidos VALUES (@fk_Produto_Codigo, @fk_Usuario_Cpf, @nome_produto, @preco_produto, @Quantidade_produto, @Descricao_produto, @id_Pedido, @imagem)", con);
                    comando.Parameters.AddWithValue("@fk_Produto_Codigo", item.codigo);
                    comando.Parameters.AddWithValue("@fk_Usuario_Cpf", cpf);
                    comando.Parameters.AddWithValue("@nome_produto", item.nome);
                    comando.Parameters.AddWithValue("@preco_produto", item.preco);
                    comando.Parameters.AddWithValue("@Quantidade_produto", item.qtd);
                    comando.Parameters.AddWithValue("@Descricao_produto", item.descricao);
                    comando.Parameters.AddWithValue("@imagem", item.img);
                    comando.Parameters.AddWithValue("@id_pedido", idPedido + 1);

                    comando.ExecuteNonQuery();
                }

                con.Close();

                return "Produto cadastrado com sucesso!";


            }
            catch (Exception e)
            {
                return "Erro " + e;
            }


        }

        //retorna dados para o carrinho
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

        public string Excluir()
        {
            //Remover do BD
            MySqlConnection con = new MySqlConnection(
                conexao);
            try
            {
                con.Open();
                MySqlCommand qry = new MySqlCommand(
                    "DELETE FROM Produto WHERE codigo = @codigo", con);
                qry.Parameters.AddWithValue("@codigo", codigo);
                qry.ExecuteNonQuery();
                con.Close();

                return "Produto excluido com sucesso!";
            }
            catch (Exception ex)
            {
                return "Erro: " + ex.Message;
            }
        }


        // PEGA OS PRODUTOS QUE O USUÁRIO COMPROU E SALVA NUMA LISTA. ESSA LISTA SERÁ MOSTRADA NA VIEW DE PRODUTOS COMPRADOS
        public static List<Produto> ListarPedidos(string cpf)
        {
            List<Produto> lista = new List<Produto>();

            MySqlConnection con = new MySqlConnection(conexao);

            try
            {
                con.Open();
                MySqlCommand qry = new MySqlCommand("SELECT * FROM Pedidos WHERE fk_Usuario_Cpf = @cpf", con);
                qry.Parameters.AddWithValue("@cpf", cpf);

                MySqlDataReader leitor = qry.ExecuteReader();

                while (leitor.Read())
                {
                    byte[] imgBytes = (byte[])leitor["imagem"];

                Produto p = new Produto(
                leitor["nome_produto"].ToString(),
                (Double)leitor["preco_produto"],
                leitor["Descricao_produto"].ToString(),
                (int)leitor["fk_Produto_Codigo"],
                (int)leitor["Quantidade_produto"],
                imgBytes);

                lista.Add(p);

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
           