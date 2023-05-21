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
        public string dataLocacao { get; set; }
        public double total { get; set; }

        public FrmLocacao()
        {
            InitializeComponent();
        }

        private void FrmLocacao_Load(object sender, EventArgs e)
        {
            txtIdJogo.Focus();
            PrecoLocacao preco = new PrecoLocacao();
            preco.buscarPreco();
            valorLocacao = preco.valorLocacao;
            total = 0;


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
            if(verificaVazio(txtIdCliente.Text, txtIdJogo.Text, txtDataRetorno.Text))
            {
                dataLocacao = DateTime.Now.ToString();
                int idJogo = int.Parse(txtIdJogo.Text);
                int idCliente = int.Parse(txtIdCliente.Text);
                string dataRetorno = txtDataRetorno.Text;
                dataRetorno = td.To
                Locacao addProduto = new Locacao();

                addProduto.adicionarLocacao(dataLocacao, dataRetorno, idJogo, idCliente);

                Locacao locacoes = new Locacao();
                dataLocacao = DateTime.Now.ToString();
                List<Locacao> listaLocacoes = locacoes.listaLocacao(int.Parse(txtIdCliente.Text), dataLocacao);
                dgvLocacao.DataSource = listaLocacoes;
                txtIdJogo.Focus();

                txtIdJogo.Text = "";
                txtDataRetorno.Text = "";
                lblJogo.Text = "";
                lblPlataforma.Text = "";

                if (lblSubtotal.Text == "")
                {
                    total = valorLocacao;
                    lblSubtotal.Text = pastorSistemaMetrico(Convert.ToString(total));
                }
                else
                {
                    total += total;
                    lblSubtotal.Text = pastorSistemaMetrico(Convert.ToString(total));
                }
            }
        }

        private void btnFinalizarCompra_Click(object sender, EventArgs e)
        {
            
            if(Convert.ToBoolean(txtTotalRecebido.Text == ""))
            {
                MessageBox.Show("Insira o total recebido!");
            }
            else if(int.Parse(txtTotalRecebido.Text) < total)
            {
                MessageBox.Show("Valor recebido abaixo do valor total!");
            }
            else
            {
                double valorRecebido = Convert.ToDouble(txtTotalRecebido.Text);
                double troco = valorRecebido - total;
                lblTroco.Text = pastorSistemaMetrico(Convert.ToString(troco));

                MessageBox.Show("Locação concluida com sucesso");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            dataLocacao = DateTime.Now.ToString();
            var resposta = MessageBox.Show("Deseja cancelar locação?", "Cancelar locação", MessageBoxButtons.YesNo);

            if(resposta == DialogResult.Yes)
            {
                Locacao apagarLocacao = new Locacao();
                dataLocacao = DateTime.Now.ToString();
                apagarLocacao.excluirLocacao(int.Parse(txtIdCliente.Text), Convert.ToString(dataLocacao));
                Locacao locacoes = new Locacao();
                List<Locacao> listaLocacoes = locacoes.listaLocacao(int.Parse(txtIdCliente.Text),dataLocacao);
                dgvLocacao.DataSource = listaLocacoes;

                txtIdCliente.Text = "";
                txtIdJogo.Text = "";
                lblSubtotal.Text = "";
                lblCliente.Text = "";
                lblJogo.Text = "";
                total = 0;
            }

            
        }

        //TRATAMENTO DE DADOS :)

        public bool verificaVazio(string idCliente, string idJogo, string dataRetorno)
        {
            if(idCliente=="" || idJogo=="" || dataRetorno == "")
            {
                MessageBox.Show("Preencha os campos!");
                txtDataRetorno.Text = "";
                txtIdJogo.Text = "";
                txtIdCliente.Text = "";
                txtIdJogo.Focus();
                lblCliente.Text = "";
                lblJogo.Text = "";
                lblPlataforma.Text = "";

                return false;
            }
            else
            {
                return true;
            }
        }

        public string pastorSistemaMetrico(string valorAntigo)
        {
            string valorNovo = valorAntigo.Replace('.', ',');

            return valorNovo;
        }
    }
}
