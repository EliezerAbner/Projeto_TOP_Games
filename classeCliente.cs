using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace TOP_Games
{
    class Cliente
    {
        public int Id { get; set; }
        public string nome { get; set; }
        public string dataNascimento { get; set; }
        public string cpf { get; set; }
        public string celular { get; set; }
        public string telContato { get; set; }
        public string email { get; set; }
        public string logradouro { get; set; }
        public string numero { get; set; }
        public string bairro { get; set; }
        public string cidade { get; set; }

        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Programas\\Projeto_TOP_Games\\topGamesDB.mdf;Integrated Security=True");

        public List<Cliente> listaCliente()
        {
            List<Cliente> li = new List<Cliente>();
            string sql = "SELECT * FROM Clientes";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Cliente cli = new Cliente();
                cli.Id = (int)dr["Id"];
                cli.nome = dr["nome"].ToString();
                cli.dataNascimento = dr["dataNascimento"].ToString();
                cli.cpf = dr["cpf"].ToString();
                cli.email = dr["email"].ToString();
                cli.logradouro = dr["logradouro"].ToString();
                cli.numero = dr["numero"].ToString();
                cli.bairro = dr["bairro"].ToString();
                cli.cidade = dr["cidade"].ToString();
                li.Add(cli);
            }
            return li;
        }

        public void Cadastrar(string nome, string dataNascimento, string cpf, string []telefone, string email, string logradouro, string numero, string bairro, string cidade)
        {
            string sql = "INSERT INTO Clientes(nome, dataNascimento, cpf, email, logradouro, numero, bairro, cidade) VALUES ('" + nome + "', '" + dataNascimento + "', '" + cpf + "', '" + email + "', '" + logradouro + "', '" + numero + "', '" + bairro + "', '" + cidade + "')";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            var clienteId = cmd.ExecuteScalar();
            con.Close();

            foreach (string telefones in telefone)
            {
                string sqlTelefone = "INSERT INTO Telefones(clienteId, telefone) VALUES('" + clienteId + "', '" + telefones + "',)";
                con.Open();
                SqlCommand cmdTelefone = new SqlCommand(sqlTelefone, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void Atualizar(int Id, string nome, string dataNascimento, string cpf, string[] telefone, string email, string logradouro, string numero, string bairro, string cidade)
        {
            string sql = "UPDATE Cliente SET nome='" + nome + "', dataNascimento= '" + dataNascimento + "', cpf='" + cpf + "', email='" + email + "', logradouro='" + logradouro + "', numero='" + numero + "', bairro='" + bairro + "', cidade='" + cidade + "'";
        }

        public void Apagar(int id)
        {

        }
        public void Buscar(int id)
        {

        }

        public void Check(int id)
        {

        }
    }
}

/*
string sql = "INSERT INTO Cliente(nome, celular, email, cidade) VALUES ('" + nome + "', '" + celular + "', '" + email + "', '" + cidade + "') ";
con.Open();
SqlCommand cmd = new SqlCommand(sql, con);
cmd.ExecuteNonQuery();
con.Close();
*/

//criar tabela itens :)