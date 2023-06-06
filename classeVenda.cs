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
        public int artigoId { get; set; }
        public int qtdeArtigo { get; set; }
        public int jogoId { get; set; }
        public int qtdeJogo { get; set; }
        public DateTime dataVenda { get; set; }
        public float precoTotal { get; set; }
        public string produto { get; set; }
        public int quantidade { get; set; }
        public decimal precoUnitario { get; set; }


        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Programas\\Projeto_TOP_Games\\topGamesDB.mdf;Integrated Security=True");

        public List<Venda> listaPedidos(string produto, int jogoId, int artigoId)
        {
            List<Venda> li = new List<Venda> ();
            string sql = "";
            
            if(produto == "ARTIGO")
            {
                sql = "EXEC listaArtigo @artigoId '"+artigoId+"'";
            }
            else if (produto == "JOGO")
            {
                sql = "EXEC listaJogo @jogoId = '"+jogoId+"'";
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

        public int CriarVenda(DateTime dataVenda)
        {
            string sql = "INSERT INTO Vendas(dataVenda) VALUES ('"+dataVenda+"')";
            con.Open();
            SqlCommand cadArtigo = new SqlCommand(sql, con);
            cadArtigo.ExecuteNonQuery();
            con.Close();

            string sqlId = "SELECT max(vendaId) AS id FROM Vendas";
            int SoPraNaoQuebrar = 0;

            return SoPraNaoQuebrar;
        }

        public void InserirPedido(int vendaId, int artigoId, int qtdeArtigo, int jogoId, int qtdeJogo)
        {
            string sql = "INSERT INTO Pedidos(vendaId, artigoId, qtdeArtigo, jogoId, qtdeJogo)";
            con.Open();
            SqlCommand cadArtigo = new SqlCommand(sql, con);
            cadArtigo.ExecuteNonQuery();
            con.Close();
        }
    }
}
