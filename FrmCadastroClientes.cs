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
        }
    }
}
