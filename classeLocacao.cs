using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TOP_Games
{
    class Locacao : Conexao
    {
        public int locacaoId { get; set; }
        public string dataLocacao { get; set; }
        public string dataRetorno { get; set; }
        public int jogoId { get; set; }
        public int clienteId { get; set; }

        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Aluno\\Source\\Repos\\EliezerAbner\\Projeto_TOP_Games\\topGamesDB.mdf;Integrated Security=True");
            
        public List<Locacao> listaLocacao(int Id, string diaLocacao)
        {
             
            List<Locacao> li = new List<Locacao>();
            string sql = "SELECT * FROM Locacao WHERE clienteId='"+Id+"' AND dataLocacao='"+diaLocacao+"'";
            
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                Locacao locacao = new Locacao();
                locacao.locacaoId = (int)dataReader["locacaoId"];
                locacao.dataLocacao = dataReader["dataLocacao"].ToString();
                locacao.dataRetorno = dataReader["dataRetorno"].ToString();
                locacao.jogoId = (int)dataReader["jogoId"];
                locacao.clienteId = (int)dataReader["clienteId"];
                li.Add(locacao);
            }
            con.Close();
            return li;
        }

        public void adicionarLocacao(string dataLocacao, DateTime dataRetorno, int jogoId, int clienteId)
        {
            string sql = "INSERT INTO Locacao (dataLocacao, dataRetorno, jogoId, clienteId) VALUES ('"+dataLocacao+"', '"+dataRetorno+"', '"+jogoId+"', '"+clienteId+"')";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void excluirLocacao(int clienteId, int jogoId)
        {
            string sql = "DELETE FROM Locacao WHERE clienteId='" + clienteId + "' AND jogoId='"+jogoId+"'";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void buscarLocacao(int clienteId, int jogoId)
        {
            string sql = "SELECT * FROM Locacao WHERE clienteId='"+clienteId+"' AND jogoId='"+jogoId+"'";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                locacaoId = (int)dataReader["locacaoId"];
                dataLocacao = dataReader["dataLocacao"].ToString();
                dataRetorno = dataReader["dataRetorno"].ToString();
                clienteId = (int)dataReader["clienteId"];
                jogoId = (int)dataReader["jogoId"];
            }
            con.Close();
        }
    }
}
