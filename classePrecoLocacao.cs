using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TOP_Games
{
    class PrecoLocacao
    {
        public double valorLocacao { get; set; }

        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Programas\\Projeto_TOP_Games\\EliezerAbner\\Projeto_TOP_Games\\topGamesDB.mdf;Integrated Security=True");

        public void cadastrarPreco(double valor)
        {
            string sql = "INSERT INTO PrecoLocacao (precoLocacao) VALUES ('" + valor + "')";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void atualizarPreco(double valor)
        {
            string sql = "UPDATE PrecoLocacao SET precoLocacao='" + valor + "'";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void buscarPreco()
        {
            string sql = "SELECT * FROM PrecoLocacao"; 
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();
            
            while (dr.Read())
            {
                valorLocacao = Convert.ToDouble(dr["precoLocacao"]);
            }
            
            con.Close();
        }
    }
}
