﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TOP_Games
{
    public partial class FrmLocacao : Form
    {
        
        public string idJogoTxt { get; set; }
        public double valorLocacao { get; set; }
        public string dataLocacao { get; set; }
        public double total { get; set; }
        public string calendario { get; set; }

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
            calendario = "";
            idJogoTxt = "";
        }

        private void btnOkJogo_Click(object sender, EventArgs e)
        {
            int Id = int.Parse(txtIdJogo.Text);
            Jogo okJogo = new Jogo();

            okJogo.Buscar(Id);

            if (Convert.ToBoolean(okJogo.jogoId) && int.Parse(okJogo.quantidade) > 0)  //verifica se o jogo existe e disponibilidade
            {
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
            if(verificaVazio(txtIdCliente.Text, txtIdJogo.Text, calendario)) 
            {
                Jogo AddNoCarrinho = new Jogo();
                AddNoCarrinho.Quantidade(int.Parse(txtIdJogo.Text), 1, false);

                dataLocacao = DateTime.Now.ToString("yyyy-MM-dd");
                int idJogo = int.Parse(txtIdJogo.Text);
                int idCliente = int.Parse(txtIdCliente.Text);
                
                Locacao addProduto = new Locacao();
                addProduto.adicionarLocacao(dataLocacao, calendario, idJogo, idCliente);

                Locacao locacoes = new Locacao();
                dataLocacao = DateTime.Now.ToString("yyyy-MM-dd");
                
                List<Locacao> listaLocacoes = locacoes.listaLocacao(int.Parse(txtIdCliente.Text), dataLocacao);
                dgvLocacao.DataSource = listaLocacoes;
                txtIdJogo.Focus();
                idJogoTxt = txtIdJogo.Text;
                txtIdJogo.Text = "";
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
            dataLocacao = DateTime.Now.ToString("yyyy-MM-dd");
            var resposta = MessageBox.Show("Deseja cancelar locação?", "Cancelar locação", MessageBoxButtons.YesNo);

            if(resposta == DialogResult.Yes)
            {
                Jogo devolver = new Jogo();
                devolver.Quantidade(int.Parse(idJogoTxt), 1, true);

                Locacao apagarLocacao = new Locacao();
                apagarLocacao.excluirLocacao(int.Parse(txtIdCliente.Text), int.Parse(idJogoTxt));
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

        public bool verificaVazio(string idCliente, string idJogo, string calendario)
        {
            if(idCliente=="" || idJogo=="" || calendario=="")
            {
                MessageBox.Show("Preencha os campos!");
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

        public string converterDatas(DateTime valorAntigo) //recebe dd/mm/yyyy, sai yyyy-mm-dd
        {
            string inverterData = valorAntigo.ToString("yyyy-MM-dd");
            string valorNovo = inverterData.Replace("/", "-");

            return valorNovo;
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            DateTime formatoBr = e.Start;
            calendario = formatoBr.ToString("yyyy-MM-dd");
        }
    }
}

/*
private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
{
    this.label2.Text = e.Start.ToShortDateString();
}

public void InserirData(DateTime data)
{
    string format = "yyyy-MM-dd HH:mm:ss";
    string sql = "INSERT INTO Data(dataatual) VALUES ('" + data.ToString(format) + "')";
    if (con.State == ConnectionState.Open)
    {
        con.Close();
    }
    con.Open();
    SqlCommand cmd = new SqlCommand(sql, con);
    cmd.ExecuteNonQuery();
    con.Close();
}
*/
