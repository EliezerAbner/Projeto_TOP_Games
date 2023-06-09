using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TOP_Games
{
    class Venda
    {
        public int vendaId { get; set; }
        public string produto { get; set; }
        public int quantidade { get; set; }
        public decimal precoUnitario { get; set; }


        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Programas\\Projeto_TOP_Games\\topGamesDB.mdf;Integrated Security=True");

        public List<Venda> listaPedidos(string produto, string produtoId)
        {
            List<Venda> li = new List<Venda> ();
            string sql = "";
            
            if(produto == "ARTIGO")
            {
                sql = "EXEC listaArtigo @artigoId '"+ produtoId + "'";
            }
            else if (produto == "JOGO")
            {
                sql = "EXEC listaJogo @jogoId = '"+ produtoId + "'";
            }

            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Venda listaVenda = new Venda ();

                listaVenda.produto = dr["PRODUTO"].ToString();
                listaVenda.quantidade = (int)dr["QUANTIDADE"];
                listaVenda.precoUnitario = Convert.ToDecimal(dr["PRECO_UNITARIO"]);
            }
            return li;
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

        public void AtualizarVenda(int vendaId, decimal precoTotal)
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

        public void InserirPedido(int vendaId, string artigoId, string qtdeArtigo, string jogoId, string qtdeJogo) 
        { 
            string sql = "INSERT INTO Pedidos(vendaId, artigoId, qtdeArtigo, jogoId, qtdeJogo) VALUES ('"+ vendaId + "', '"+ artigoId + "', '"+ qtdeArtigo + "', '"+ jogoId + "', '"+ qtdeJogo + "')";
            con.Open();
            SqlCommand cadArtigo = new SqlCommand(sql, con);
            cadArtigo.ExecuteNonQuery();
            con.Close();
        }

        public void ExcluirPedido(int vendaId)
        {
            string sql = "DELETE * FROM Pedidos WHERE vendaId='" + vendaId + "'";
            con.Open();
            SqlCommand cadArtigo = new SqlCommand(sql, con);
            cadArtigo.ExecuteNonQuery();
            con.Close();
        }
        
    }
}
