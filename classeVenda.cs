using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace TOP_Games
{
    class Venda
    {
        public int vendaId { get; set; }
        public int pedidoId { get; set; }
        public int produtoId { get; set; }
        public string nomeProduto { get; set; }
        public int quantidade { get; set; }
        public decimal precoUnitario { get; set; }
        public string tipoProduto { get; set; }


        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Programas\\Projeto_TOP_Games\\topGamesDB.mdf;Integrated Security=True");

        public List<Venda> listaPedidos(int vendaId)
        {
            List<Venda> li = new List<Venda>();

            string sql = "SELECT * FROM Pedidos WHERE vendaId='"+vendaId+"'";

            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                Venda venda = new Venda();
                int produtoId = (int)dataReader["produtoId"];
                venda.quantidade = (int)dataReader["qtdeProduto"];
                venda.precoUnitario = Convert.ToDecimal(dataReader["precoUnitario"]);
                string tipoProduto = dataReader["tipoProduto"].ToString();
                venda.nomeProduto = obterNome(produtoId, tipoProduto); 
                li.Add(venda);
            }
            con.Close();
            return li;
        }

        public string obterNome(int Id, string tipoProduto)
        {
            string nome = "";

            if (tipoProduto == "ARTIGO")
            {
                Artigo buscaNome = new Artigo();
                buscaNome.Buscar(Id);
                nome = buscaNome.nome;
            }
            else if (tipoProduto == "JOGO")
            {
                Jogo buscaNome = new Jogo();
                buscaNome.Buscar(Id);
                nome = buscaNome.titulo;
            }
            return nome;
        }

        public void CriarVenda(DateTime dataVenda)
        {
            string sql = "INSERT INTO Vendas(dataVenda) VALUES ('"+dataVenda+"')";
            con.Open();
            SqlCommand cadArtigo = new SqlCommand(sql, con);
            cadArtigo.ExecuteNonQuery();
            con.Close();

            
            string sqlId = "SELECT max(vendaId) AS id FROM Vendas";
            con.Open ();
            SqlCommand cmd = new SqlCommand(sqlId, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                vendaId = (int)dr["id"];
            }
            con.Close();
        }

        public void ExcluirVenda(int vendaId)
        {
            string sql = "DELETE * FROM Pedidos WHERE vendaId='" + vendaId + "'";
            con.Open();
            SqlCommand deletePedido = new SqlCommand(sql, con);
            deletePedido.ExecuteNonQuery();
            con.Close();

            string sqlVenda = "DELETE * FROM Venda WHERE vendaId='" + vendaId + "'";
            con.Open();
            SqlCommand deleteVenda = new SqlCommand(sqlVenda, con);
            deleteVenda.ExecuteNonQuery();
            con.Close();
        }

        public void ConcluirVenda(int vendaId, decimal precoTotal)
        {
            string sql = "UPDATE Vendas SET valorTotal='" + precoTotal + "' WHERE vendaId ='"+vendaId+"'";
            con.Open();
            SqlCommand cadArtigo = new SqlCommand(sql, con);
            cadArtigo.ExecuteNonQuery();
            con.Close();
        }

        public bool BuscarVenda(int vendaId)
        {
            string sql = "SELECT * FROM Vendas WHERE vendaId='" + vendaId + "'";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if(dr.HasRows)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void InserirPedido(int vendaId, string produtoId, int qtdeProduto, string tipoProduto, decimal precoUnitario) 
        { 
            string sql = "INSERT INTO Pedidos(vendaId, produtoId, qtdeProduto, tipoProduto, precoUnitario) VALUES ('"+ vendaId + "', '"+ produtoId + "', '"+ qtdeProduto + "', '"+ tipoProduto + "', '"+precoUnitario+"')";
            con.Open();
            SqlCommand cadArtigo = new SqlCommand(sql, con);
            cadArtigo.ExecuteNonQuery();
            con.Close();
        }

        public void ExcluirPedido(int vendaId)
        {
            string sql = "DELETE max(pedidoId) FROM Pedidos WHERE vendaId='" + vendaId + "'";
            con.Open();
            SqlCommand deletePedido = new SqlCommand(sql, con);
            deletePedido.ExecuteNonQuery();
            con.Close();
        }
        
        public List<Venda> obterPedidos(int vendaId)
        {
            List<Venda> li = new List<Venda>();

            string sql = "SELECT * FROM Pedidos WHERE vendaId='" + vendaId + "'";

            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                Venda venda = new Venda();

                venda.produtoId = (int)dataReader["produtoId"];
                venda.tipoProduto = dataReader["tipoProduto"].ToString();
                venda.quantidade = (int)dataReader["qtdeProduto"];
                venda.pedidoId = (int)dataReader["pedidoId"];

                li.Add(venda);
            }
            con.Close();
            return li;
        }
    }
}
