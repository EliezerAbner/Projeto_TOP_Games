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

            if (verificaVazios())
            {
                clienteInserir.Cadastrar(txtNome.Text, txtDataNascimento.Text, txtCpf.Text, telefone, txtEmail.Text, txtLogradouro.Text, txtNumero.Text, txtBairro.Text, txtCidade.Text);
                MessageBox.Show("Cliente cadastrado com sucesso!");
                List<Cliente> cli = clienteInserir.listaCliente();
                dgvCadClientes.DataSource = cli;
                limpaCampos();
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            int Id = int.Parse(txtId.Text.Trim());
            string[] telefone = { txtCelular.Text, txtTelContato.Text };
            Cliente clienteAtualizar = new Cliente();
            DateTime dataNascimento = Convert.ToDateTime(txtDataNascimento.Text);

            if (verificaVazios())
            {
                clienteAtualizar.Atualizar(Id, txtNome.Text, converterDatas(dataNascimento), txtCpf.Text, telefone, txtEmail.Text, txtLogradouro.Text, txtNumero.Text, txtBairro.Text, txtCidade.Text);
                MessageBox.Show("Cliente atualizado com sucesso!");
                List<Cliente> cli = clienteAtualizar.listaCliente();
                dgvCadClientes.DataSource = cli;
                limpaCampos();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int Id = int.Parse(txtId.Text.Trim());
            Cliente clienteBuscar = new Cliente();

            clienteBuscar.Buscar(Id);

            txtNome.Text = clienteBuscar.nome;
            txtDataNascimento.Text = clienteBuscar.dataNascimento;
            txtCpf.Text = clienteBuscar.cpf;
            txtCelular.Text = clienteBuscar.celular;
            txtEmail.Text = clienteBuscar.email;
            txtTelContato.Text = clienteBuscar.telContato;
            txtLogradouro.Text = clienteBuscar.logradouro;
            txtNumero.Text = clienteBuscar.numero;
            txtBairro.Text = clienteBuscar.bairro;
            txtCidade.Text = clienteBuscar.cidade;
        }

        public bool verificaVazios() 
        {
            if (txtCelular.Text == "")
            {
                MessageBox.Show("O número de celular é obrigatório");
                limpaCampos();
                return false;
            }
            else
            {
                return true;
            }
        }

        public void limpaCampos()
        {
            txtId.Text = "";
            txtNome.Text = "";
            txtDataNascimento.Text = "";
            txtCpf.Text = "";
            txtCelular.Text = "";
            txtNumero.Text = "";
            txtTelContato.Text = "";
            txtEmail.Text = "";
            txtLogradouro.Text = "";
            txtNumero.Text = "";
            txtBairro.Text = "";
            txtCidade.Text = "";
        }

        public string converterDatas(DateTime valorAntigo) //recebe dd/mm/yyyy, sai yyyy-mm-dd
        {
            string inverterData = valorAntigo.ToString("yyyy-MM-dd");
            string valorNovo = inverterData.Replace("/", "-");

            return valorNovo;
        }
    }
}
