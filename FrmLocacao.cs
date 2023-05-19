using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TOP_Games
{
    public partial class FrmLocacao : Form
    {
        
        public double valorLocacao { get; set; }

        public FrmLocacao()
        {
            InitializeComponent();
        }

        private void FrmLocacao_Load(object sender, EventArgs e)
        {
            Locacao locacoes = new Locacao();
            List<Locacao> listaLocacoes = locacoes.listaLocacao();
            dgvLocacao.DataSource = listaLocacoes;
            txtIdJogo.Focus();
            PrecoLocacao preco = new PrecoLocacao();
            preco.buscarPreco();
            valorLocacao = preco.valorLocacao;


        }

        private void btnOkJogo_Click(object sender, EventArgs e)
        {
            int Id = int.Parse(txtIdJogo.Text);
            Jogo okJogo = new Jogo();

            okJogo.Buscar(Id);

            if (Convert.ToBoolean(okJogo.jogoId) && int.Parse(okJogo.quantidade) > 0)  //verifica se o jogo existe e disponibilidade
            {
                //MessageBox.Show("O jogo", okJogo.titulo, "existe");
                lblJogo.Text = okJogo.titulo;
                lblPlataforma.Text = okJogo.plataforma;
                
            }
            else
            {
                MessageBox.Show("Jogo não encontrado ou sem estoque disponível");
                txtIdJogo.Text = "";
                txtIdJogo.Focus();
            }
        }

        private void btnOkCliente_Click(object sender, EventArgs e)
        {
            int Id = int.Parse(txtIdCliente.Text);
            Cliente okCliente = new Cliente();

            okCliente.Buscar(Id);

            if (Convert.ToBoolean(okCliente.Id))
            {
                MessageBox.Show("Cliente encontrado!");
                lblCliente.Text = okCliente.nome;
            }
            else
            {
                MessageBox.Show("Cliente não encontrado");
                txtIdCliente.Text = "";
                txtIdCliente.Focus();
            }
        }

        private void btnAddProdutos_Click(object sender, EventArgs e)
        {
            string dataLocacao = DateTime.Now.ToString();
            int idJogo = int.Parse(txtIdJogo.Text);
            int idCliente = int.Parse(txtIdCliente.Text);
            Locacao addProduto = new Locacao();

            addProduto.adicionarLocacao(dataLocacao, txtDataRetorno.Text, idJogo, idCliente);

            Locacao locacoes = new Locacao();
            List<Locacao> listaLocacoes = locacoes.listaLocacao();
            dgvLocacao.DataSource = listaLocacoes;
            txtIdJogo.Focus();

            txtIdCliente.Text = "";
            txtIdJogo.Text = "";
            txtDataRetorno.Text = "";
            lblCliente.Text = "";
            lblJogo.Text = "";
            lblPlataforma.Text = "";

            if(lblSubtotal.Text == "")
            {
                lblSubtotal.Text = 0.ToString();
            }

            
            double precoTotal = Convert.ToDouble(lblSubtotal.Text) + valorLocacao;
            lblSubtotal.Text = conversaoDecimal(precoTotal.ToString());
            
        }

        private void btnFinalizarCompra_Click(object sender, EventArgs e)
        {
            
            if(Convert.ToBoolean(txtTotalRecebido.Text == ""))
            {
                MessageBox.Show("Insira o total recebido!");
            }
            else
            {
                string valorConvertido = lblSubtotal.Text.Replace(',', '.');
                double totalRecebido = Convert.ToDouble(valorConvertido);
                double valorTotal = Convert.ToDouble(lblSubtotal.Text);

                double total = totalRecebido - valorTotal;

                lblTroco.Text = conversaoDecimal(total.ToString());

            }
        }

        public string conversaoDecimal(string valorAntigo)
        {
            string valorNovo = valorAntigo.Replace('.', ',');

            return valorNovo;
        }
    }
}
