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
        public string[] telefone { get; set; }
        public string[] telefoneId { get; set; }
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
                cli.Id = (int)dr["clienteId"];
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

        public void Cadastrar(string nome, string dataNascimento, string cpf, string[] telefone, string email, string logradouro, string numero, string bairro, string cidade)
        {
            string sql = "INSERT INTO Clientes(nome, dataNascimento, cpf, email, logradouro, numero, bairro, cidade) VALUES ('" + nome + "', '" + dataNascimento + "', '" + cpf + "', '" + email + "', '" + logradouro + "', '" + numero + "', '" + bairro + "', '" + cidade + "')";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();

            con.Open();
            string sqlId = "SELECT IDENT_CURRENT('Clientes') AS sqlId";
            SqlCommand cmd2 = new SqlCommand(sqlId, con);
            string clienteId = Convert.ToString(cmd2.ExecuteScalar());
            con.Close();

            foreach (string telefones in telefone)
            {
                string sqlTelefone = "INSERT INTO Telefones(clienteId, telefone) VALUES('" + clienteId + "', '" + telefones + "')";
                con.Open();
                SqlCommand cmdTelefone = new SqlCommand(sqlTelefone, con);
                cmdTelefone.ExecuteNonQuery();
                con.Close();
            }
        }

        public void Atualizar(int Id, string nome, string dataNascimento, string cpf, string[] telefone, string email, string logradouro, string numero, string bairro, string cidade)
        {
            string sql = "UPDATE Clientes SET nome='" + nome + "', dataNascimento= '" + dataNascimento + "', cpf='" + cpf + "', email='" + email + "', logradouro='" + logradouro + "', numero='" + numero + "', bairro='" + bairro + "', cidade='" + cidade + "' WHERE clienteId = '"+Id+"'";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();

            Cliente buscaTelefone = new Cliente();
            buscaTelefone.Buscar(Id);
            string[] idTelefone = buscaTelefone.telefoneId;


            for(int i = 0; i < telefone.Length; i++)
            {
                string sqlTelefone = "UPDATE Telefones SET telefone='" + telefone[i] +"' WHERE clienteId='"+Id+"' AND telefoneId='" + idTelefone[i] +"'";
                con.Open();
                SqlCommand cmdTelefone = new SqlCommand(sqlTelefone, con);
                cmdTelefone.ExecuteNonQuery();
                con.Close();
            }
        }

        public void Apagar(int Id)
        {

        }
        public void Buscar(int id)
        {
            string sql = "SELECT * from Clientes WHERE clienteId='" + id + "'";
            con.Open();
            SqlCommand buscaCliente = new SqlCommand(sql, con);
            SqlDataReader dr = buscaCliente.ExecuteReader();
            while (dr.Read())
            {
                Id = Convert.ToInt16(dr["clienteId"]);
                nome = dr["nome"].ToString();
                dataNascimento = dr["dataNascimento"].ToString();
                cpf = dr["cpf"].ToString();
                email = dr["email"].ToString();
                logradouro = dr["logradouro"].ToString();
                numero = dr["numero"].ToString();
                bairro = dr["bairro"].ToString();
                cidade = dr["cidade"].ToString();
            }
            con.Close();

            string sqlTelefone = "SELECT * from Telefones WHERE clienteId='" + Id + "'";
            con.Open();
            SqlCommand buscaTelefone = new SqlCommand (sqlTelefone, con);
            SqlDataReader dataReader = buscaTelefone.ExecuteReader();
            if (dataReader.HasRows)
            {
                int contador = 0;

                while (dataReader.Read())
                {
                    telefone[contador] = dataReader["telefone"].ToString();
                    telefoneId[contador] = dataReader["telefoneId"].ToString();
                    contador++;
                }
            }
            con.Close();
        }

        public void Check(int Id)
        {

        }
    }
}