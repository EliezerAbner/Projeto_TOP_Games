using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TOP_Games
{
    class Artigo
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string quantidade { get; set; }
        public string precoVenda { get; set; }
        public string descricao { get; set; }

        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Programas\\Projeto_TOP_Games\\topGamesDB.mdf;Integrated Security=True");

        public List<Artigo> listaArtigos()
        {
            List<Artigo> li = new List<Artigo>();
            string sql = "SELECT * FROM Artigos";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Artigo artigos = new Artigo();
                artigos.id = (int)dr["artigoId"];
                artigos.nome = dr["nome"].ToString();
                artigos.quantidade = dr["quantidade"].ToString();
                artigos.precoVenda = dr["precoVenda"].ToString();
                artigos.descricao = dr["descricao"].ToString();
                li.Add(artigos);
            }
            return li;
        }

        public void Cadastrar(string nome, string quantidade, string precoVenda, string descricao)
        {
            float preco = float.Parse(precoVenda);
            string sql = "INSERT INTO Artigos (nome, quantidade, precoVenda, descricao) VALUES ('"+nome+"', '"+quantidade+"', '"+ preco+ "', '"+descricao+"')";
            con.Open();
            SqlCommand cadArtigo = new SqlCommand(sql, con);
            cadArtigo.ExecuteNonQuery();
            con.Close();
        }

        public void Atualizar(int Id, string nome, string quantidade, string precoVenda, string descricao)
        {
            string sql = "UPDATE Artigos SET nome='" + nome + "', quantidade='" + quantidade + "', precoVenda='" + precoVenda + "', descricao='" + descricao + "' WHERE artigoId='" + Id + "'";
            con.Open();
            SqlCommand atualizarArtigo = new SqlCommand(sql, con);
            atualizarArtigo.ExecuteNonQuery();
            con.Close();
        }

        public void Apagar(int Id) 
        {
            string sql = "DELETE FROM Artigos WHERE artigoId = '" + Id + "'";
            con.Open();
            SqlCommand delArtigo = new SqlCommand(sql, con);
            delArtigo.ExecuteNonQuery();
            con.Close();
        }

        public void Buscar(int Id)
        {
            string sql = "SELECT * FROM Artigos WHERE artigoId='" + Id + "'";
            con.Open();
            SqlCommand buscarArtigo = new SqlCommand(sql, con);
            SqlDataReader dataReader = buscarArtigo.ExecuteReader();
            while (dataReader.Read())
            {
                nome = dataReader["nome"].ToString();
                quantidade = dataReader["quantidade"].ToString();
                precoVenda = dataReader["precoVenda"].ToString();
                descricao = dataReader["descricao"].ToString();
            }
            con.Close();
        }

        public void Quantidade(int Id, int carrinho, bool addSub) //addSub true = adiciona, addSub false = subtrai
        {
            Artigo buscar = new Artigo();
            buscar.Buscar(Id);
            int qtdeEstoque = int.Parse(buscar.quantidade);
            int qtde;

            if (addSub)
            {
                qtde = qtdeEstoque + carrinho;
            }
            else
            {
                qtde = qtdeEstoque - carrinho;
            }

            string sql = "UPDATE Artigos SET quantidade='" + qtde + "' WHERE artigoId='" + Id + "'";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
