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
    public partial class FrmCadastroJogos : Form
    {
        public FrmCadastroJogos()
        {
            InitializeComponent();
        }

        private void FrmCadastroJogos_Load(object sender, EventArgs e)
        {
            Jogo jogos = new Jogo();
            List<Jogo> listaJogos = jogos.listaJogos();
            dgvCadJogos.DataSource = listaJogos;
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            Jogo cadJogos = new Jogo();
            cadJogos.Cadastrar(txtTitulo.Text, txtPlataforma.Text, txtGenero.Text, txtDesenvolvedora.Text, txtAnoLancamento.Text, txtQuantidade.Text, txtPrecoVenda.Text);
            MessageBox.Show("Jogo Cadastrado com sucesso!!");
            List<Jogo> listaJogos = cadJogos.listaJogos();
            dgvCadJogos.DataSource = listaJogos;

            txtTitulo.Text = "";
            txtPlataforma.Text = "";
            txtGenero.Text = "";
            txtDesenvolvedora.Text = "";
            txtAnoLancamento.Text = "";
            txtQuantidade.Text = "";
            txtPrecoVenda.Text = "";
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            int Id = int.Parse(txtId.Text.Trim());
            Jogo atualizarJogos = new Jogo();
            atualizarJogos.Atualizar(Id, txtTitulo.Text, txtPlataforma.Text, txtGenero.Text, txtDesenvolvedora.Text, txtAnoLancamento.Text, txtQuantidade.Text, txtPrecoVenda.Text);
            MessageBox.Show("Jogo atualizado com sucesso!!");
            List<Jogo> listaJogos = atualizarJogos.listaJogos();
            dgvCadJogos.DataSource = listaJogos;

            txtTitulo.Text = "";
            txtPlataforma.Text = "";
            txtGenero.Text = "";
            txtDesenvolvedora.Text = "";
            txtAnoLancamento.Text = "";
            txtQuantidade.Text = "";
            txtPrecoVenda.Text = "";
        }

        private void btnApagar_Click(object sender, EventArgs e)
        {
            int Id = int.Parse(txtId.Text.Trim());
            Jogo apagarJogos = new Jogo();
            apagarJogos.Apagar(Id);
            MessageBox.Show("Jogo apagado com sucesso!!");
            List<Jogo> listaJogos = apagarJogos.listaJogos();
            dgvCadJogos.DataSource = listaJogos;

            txtTitulo.Text = "";
            txtPlataforma.Text = "";
            txtGenero.Text = "";
            txtDesenvolvedora.Text = "";
            txtAnoLancamento.Text = "";
            txtQuantidade.Text = "";
            txtPrecoVenda.Text = "";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int Id = int.Parse(txtId.Text.Trim());
            Jogo buscaJogo = new Jogo();
            buscaJogo.Buscar(Id);
            List<Jogo> listaJogos = buscaJogo.listaJogos();
            dgvCadJogos.DataSource = listaJogos;

            txtTitulo.Text = buscaJogo.titulo;
            txtPlataforma.Text = buscaJogo.plataforma;
            txtGenero.Text = buscaJogo.genero;
            txtDesenvolvedora.Text = buscaJogo.desenvolvedora;
            txtAnoLancamento.Text = buscaJogo.anoLancamento;
            txtQuantidade.Text = buscaJogo.quantidade;
            txtPrecoVenda.Text = buscaJogo.precoVenda;
        }
    }
}

/*
 * falta tratar: preço, inserção/atualizacao com valores faltando
*/
