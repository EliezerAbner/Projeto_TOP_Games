﻿using System;
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
            //Locacao locacoes = new Locacao();
            //List<Locacao> listaLocacoes = locacoes.listaLocacao();
            //dgvLocacao.DataSource = listaLocacoes;
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
            dataLocacao = DateTime.Now.ToString();
            int idJogo = int.Parse(txtIdJogo.Text);
            int idCliente = int.Parse(txtIdCliente.Text);
            Locacao addProduto = new Locacao();

            addProduto.adicionarLocacao(dataLocacao, txtDataRetorno.Text, idJogo, idCliente);

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
                lblSubtotal.Text = conversaoDecimal(Convert.ToString(total));
            }
            else
            {
                total+= total;
                lblSubtotal.Text = conversaoDecimal(Convert.ToString(total));
            }
            
        }

        private void btnFinalizarCompra_Click(object sender, EventArgs e)
        {
            
            if(Convert.ToBoolean(txtTotalRecebido.Text == ""))
            {
                MessageBox.Show("Insira o total recebido!");
            }
            else
            {
                //consertar aq
                string valorConvertido = lblSubtotal.Text.Replace(',', '.');
                double totalRecebido = Convert.ToDouble(valorConvertido);
                double valorTotal = Convert.ToDouble(lblSubtotal.Text);

                double total = totalRecebido - valorTotal;

                lblTroco.Text = pastorSistemaMetrico(total.ToString());

            }
        }

        public string pastorSistemaMetrico(string valorAntigo)
        {
            string valorNovo = valorAntigo.Replace('.', ',');

            return valorNovo;
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
    }
}
