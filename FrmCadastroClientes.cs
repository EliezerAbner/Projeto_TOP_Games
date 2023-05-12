using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace TOP_Games
{
    public partial class FrmCadastroClientes : Form
    {
        public FrmCadastroClientes()
        {
            InitializeComponent();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void FrmCadastroClientes_Load(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();
            List<Cliente> cli = cliente.listaCliente();
            dgvCadClientes.DataSource = cli;
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            Cliente clienteInserir = new Cliente();
            string[] telefone = { txtCelular.Text, txtTelContato.Text };

            clienteInserir.Cadastrar(txtNome.Text, txtDataNascimento.Text, txtCpf.Text, telefone, txtEmail.Text, txtLogradouro.Text, txtNumero.Text, txtBairro.Text, txtCidade.Text);
            MessageBox.Show("Cliente cadastrado com sucesso!");
            List<Cliente> cli = clienteInserir.listaCliente();
            dgvCadClientes.DataSource= cli;
            txtId.Text = "";
            txtNome.Text = "";
            txtDataNascimento.Text = "";
            txtCpf.Text = "";
            txtNumero.Text = "";
            txtTelContato.Text = "";
            txtEmail.Text = "";
            txtLogradouro.Text = "";
            txtNumero.Text = "";
            txtBairro.Text = "";
            txtCidade.Text = "";
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            int Id = int.Parse(txtId.Text.Trim());
            string[] telefone = { txtCelular.Text, txtTelContato.Text };
            Cliente clienteAtualizar = new Cliente();

            clienteAtualizar.Atualizar(Id, txtNome.Text, txtDataNascimento.Text, txtCpf.Text, telefone, txtEmail.Text, txtLogradouro.Text, txtNumero.Text, txtBairro.Text, txtCidade.Text);
            MessageBox.Show("Cliente atualizado com sucesso!");
            List<Cliente> cli = clienteAtualizar.listaCliente();
            dgvCadClientes.DataSource = cli;
            txtId.Text = ""; 
            txtNome.Text = ""; 
            txtDataNascimento.Text = ""; 
            txtCpf.Text = ""; 
            txtNumero.Text = "";
            txtTelContato.Text = "";
            txtEmail.Text = ""; 
            txtLogradouro.Text = ""; 
            txtNumero.Text = ""; 
            txtBairro.Text = ""; 
            txtCidade.Text = "";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int Id = int.Parse(txtId.Text.Trim());
            Cliente clienteBuscar = new Cliente();

            clienteBuscar.Buscar(Id);

            string[] telefones = clienteBuscar.telefone;
            txtNome.Text = clienteBuscar.nome;
            txtDataNascimento.Text = clienteBuscar.dataNascimento;
            txtCpf.Text = clienteBuscar.cpf;
            txtEmail.Text = clienteBuscar.email;
            txtLogradouro.Text = clienteBuscar.logradouro;
            txtNumero.Text = clienteBuscar.numero;
            txtBairro.Text = clienteBuscar.bairro;
            txtCidade.Text = clienteBuscar.cidade;
        }
    }
}
