using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TOP_Games
{
    public partial class FrmVenda : Form
    {
        public int qtdeDisponivel {  get; set; }
        public int qtdeCarrinho { get ; set; }
        public int vendaId { get; set; }
        public decimal precoProduto { get; set; }

        public FrmVenda()
        {
            InitializeComponent();
        }

        private void FrmVenda_Load(object sender, EventArgs e)
        {
            lblQuantidade.Text = "1";
            qtdeCarrinho = 1;
            vendaId = 0;
            btnSubtrair.Enabled = false;
            btnAdicionar.Enabled = false;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if(chbArtigo.Checked)
            {   
                btnAdicionar.Enabled = true;
                btnSubtrair.Enabled = true;

                Artigo artigo = new Artigo();
                artigo.Buscar(Convert.ToInt16(txtId.Text));

                lblProduto.Text = artigo.nome;
                
                if(lblProduto.Text == "")
                {
                    mensagem("ID não encontrado!");
                }
                else if(Convert.ToInt16(artigo.quantidade) == 0)
                {
                    mensagem("Não há estoque disponível para este produto.");
                }
                else
                {
                    qtdeDisponivel = Convert.ToInt16(artigo.quantidade);
                    precoProduto = Convert.ToDecimal(artigo.precoVenda);
                    lblValorUnitario.Text = pastorSistemaMetrico(artigo.precoVenda);
                }

            }
            else if(chbJogo.Checked) 
            {
                btnAdicionar.Enabled = true;
                btnSubtrair.Enabled = true;

                Jogo jogo = new Jogo();
                jogo.Buscar(Convert.ToInt16(txtId.Text));

                lblProduto.Text = ""+jogo.titulo+", "+jogo.plataforma+"";

                if (lblProduto.Text == "")
                {
                    MessageBox.Show("ID não encontrado!");
                }
                if(Convert.ToInt16(jogo.quantidade) == 0)
                {
                    mensagem("Não há estoque disponível para este produto.");
                }
                else
                {
                    qtdeDisponivel = Convert.ToInt16(jogo.quantidade);
                    precoProduto = Convert.ToDecimal(jogo.precoVenda);
                    lblValorUnitario.Text = pastorSistemaMetrico(jogo.precoVenda);
                }
            }
            else
            {
                MessageBox.Show("Selecione o tipo do produto!");
            }

            void mensagem(string msg)
            {
                MessageBox.Show(msg);
                txtId.Text = "";
                lblProduto.Text = "";
                lblValorUnitario.Text = "";
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            int qtde = Convert.ToInt16(lblQuantidade.Text);

            if(qtde == qtdeDisponivel)
            {
                btnAdicionar.Enabled=false;
                MessageBox.Show("Limite máximo de produtos!");
            }
            else
            {
                qtde = qtde + 1;

                qtdeCarrinho = qtde;
                lblQuantidade.Text = Convert.ToString(qtde);
                btnSubtrair.Enabled = true;
            }
        }

        private void btnSubtrair_Click(object sender, EventArgs e)
        {
            int qtde = Convert.ToInt16(lblQuantidade.Text);

            if (qtde == 1)
            {
                btnSubtrair.Enabled = false;
            }
            else
            {
                qtde = qtde - 1;

                qtdeCarrinho = qtde;
                lblQuantidade.Text = Convert.ToString(qtde);
                btnAdicionar.Enabled = true;
            }
        }

        private void btnAddProdutos_Click(object sender, EventArgs e)
        {
            DateTime dataVenda = DateTime.Now;
            string idProduto = txtId.Text.Trim();
            string tipoProduto = "";

            btnSubtrair.Enabled = false;
            btnAdicionar.Enabled = false;

            Venda realizarVenda = new Venda();

            if(vendaId == 0)
            {
                realizarVenda.CriarVenda(dataVenda);
                vendaId = realizarVenda.vendaId;
            }

            if (chbArtigo.Checked)
            {
                realizarVenda.InserirPedido(vendaId, idProduto, Convert.ToString(qtdeCarrinho), "", "");
                Venda vendas = new Venda();
                List<Venda> listaPedidos = vendas.listaPedidos("ARTIGO", vendaId);
                dgvVendas.DataSource = listaPedidos;
                dgvVendas.Columns["vendaId"].Visible = false;
                tipoProduto = "ARTIGO";

            }
            else if (chbJogo.Checked)
            {
                realizarVenda.InserirPedido(vendaId, "", "", idProduto, Convert.ToString(qtdeCarrinho));
                Venda vendas = new Venda();
                List<Venda> listaPedidos = vendas.listaPedidos("JOGO", vendaId);
                dgvVendas.DataSource = listaPedidos;
                dgvVendas.Columns["vendaId"].Visible = false;
                tipoProduto = "JOGO";

            }

            string[,] retirarDoEstoque = { { idProduto, Convert.ToString(qtdeCarrinho), tipoProduto } };

            if (lblSubtotal.Text == "")
            {
                lblSubtotal.Text = Convert.ToString(precoProduto);
            }
            else
            {
                decimal total = (precoProduto * qtdeCarrinho) + Convert.ToDecimal(lblSubtotal.Text);
                lblSubtotal.Text = total.ToString();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            var resposta = MessageBox.Show("Deseja cancelar venda?", "Cancelar venda", MessageBoxButtons.YesNo);

            if(resposta == DialogResult.Yes)
            {
                

                
            }
        }

        private void chbArtigo_CheckedChanged(object sender, EventArgs e)
        {
            if (chbArtigo.Checked)
            {
                chbJogo.Enabled = false;
            }
            else if (!chbArtigo.Checked)
            {
                chbJogo.Enabled = true;
            }
        }

        private void chbJogo_CheckedChanged(object sender, EventArgs e)
        {
            if (chbJogo.Checked)
            {
                chbArtigo.Enabled = false;
            }
            else if (!chbJogo.Checked)
            {
                chbArtigo.Enabled = true;
            }
        }

        public string pastorSistemaMetrico(string valorAntigo)
        {
            string valorNovo = valorAntigo.Replace('.', ',');

            return valorNovo;
        }
    }
}
