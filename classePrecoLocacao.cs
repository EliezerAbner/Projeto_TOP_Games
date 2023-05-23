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

        public double valorMulta { get; set; }

        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Programas\\Projeto_TOP_Games-master\\topGamesDB.mdf;Integrated Security=True");

        public void cadastrarPreco(double valorLocacao, double valorMulta)
        {
            string sql = "INSERT INTO PrecoLocacao (precoLocacao, preocMulta) VALUES ('" + valorLocacao + "', '" + valorMulta + "')";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void atualizarPreco(double valorLocacao, double valorMulta)
        {
            string sql = "UPDATE PrecoLocacao SET precoLocacao='" + valorLocacao + "', precoMulta = '" + valorMulta + "'";
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
                valorMulta = Convert.ToDouble(dr["precoMulta"]);
            }
            
            con.Close();
        }
    }
}
