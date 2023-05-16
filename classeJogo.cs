using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TOP_Games
{
    class Jogo
    {
        public int jogoId { get; set; }
        public string titulo { get; set; }
        public string plataforma { get; set; }
        public string genero { get; set; }
        public string desenvolvedora { get; set; }
        public string anoLancamento { get; set; }
        public string quantidade { get; set; }
        public string precoVenda { get; set; }

        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Programas\\topGamesDB.mdf;Integrated Security=True");

        public List<Jogo> listaJogos()
        {
            List<Jogo> li = new List<Jogo>();
            string sql = "SELECT * FROM Jogos";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                Jogo jogos = new Jogo();
                jogos.jogoId = (int)dataReader["jogoId"];
                jogos.titulo = dataReader["titulo"].ToString();
                jogos.plataforma = dataReader["plataforma"].ToString();
                jogos.genero = dataReader["genero"].ToString();
                jogos.desenvolvedora = dataReader["desenvolvedora"].ToString();
                jogos.anoLancamento = dataReader["anoLancamento"].ToString();
                jogos.quantidade = dataReader["quantidade"].ToString();
                jogos.precoVenda = dataReader["precoVenda"].ToString();
                li.Add(jogos);
            }
            con.Close();
            return li;
        }

        public void Cadastrar(string titulo, string plataforma, string genero, string desenvolvedora, string anoLancamento, string quantidade, string precoVenda)
        {
            float preco = float.Parse(precoVenda);
            string sql = "INSERT INTO Jogos (titulo, plataforma, genero, desenvolvedora, anoLancamento, quantidade, precoVenda) VALUES ('"+titulo+"', '"+ plataforma + "', '"+ genero + "', '"+ desenvolvedora + "', '"+ anoLancamento + "', '"+ quantidade + "', '"+preco+"')";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void Atualizar(int Id, string titulo, string plataforma, string genero, string desenvolvedora, string anoLancamento, string quantidade, string precoVenda)
        {
            float preco = float.Parse(precoVenda);
            string sql = "UPDATE Jogos SET titulo='" + titulo + "', plataforma='" + plataforma + "', genero='" + genero + "', desenvolvedora='" + desenvolvedora + "', anoLancamento='" + anoLancamento + "', quantidade='" + quantidade + "', precoVenda='" + preco + "' WHERE jogoId='"+Id+"'";
            con.Open();
            SqlCommand cmd = new SqlCommand (sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void Apagar(int Id)
        {
            string sql = "DELETE FROM Jogos WHERE jogoId='"+Id+"'";
            con.Open();
            SqlCommand cmd = new SqlCommand (sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void Buscar(int Id)
        {
            string sql = "SELECT * FROM Jogos WHERE jogoId='"+Id+"'";
            con.Open();
            SqlCommand cmd = new SqlCommand (sql, con); 
            SqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                jogoId = Convert.ToInt16(dataReader["jogoId"]);
                titulo = dataReader["titulo"].ToString();
                plataforma = dataReader["plataforma"].ToString();
                genero = dataReader["genero"].ToString();
                desenvolvedora = dataReader["desenvolvedora"].ToString();
                anoLancamento = dataReader["anoLancamento"].ToString();
                quantidade = dataReader["quantidade"].ToString();
                precoVenda = dataReader["precoVenda"].ToString();
            }
            con.Close();
        }
    }
}
