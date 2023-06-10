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
    public partial class FrmCadastroArtigos : Form
    {
        public FrmCadastroArtigos()
        {
            InitializeComponent();
        }

        private void FrmCadastroArtigos_Load(object sender, EventArgs e)
        {
            Artigo artigos = new Artigo();
            List<Artigo> art = artigos.listaArtigos();
            dgvCadArtigos.DataSource = art;
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (verificaVazios())
            {
                Artigo cadArtigo = new Artigo();
                string precoVenda = txtPrecoVenda.Text.Replace(",", ".");

                if (cadArtigo.Cadastrar(txtNome.Text, txtQuantidade.Text, precoVenda, txtDescricao.Text))
                {
                    MessageBox.Show("Artigo cadastrado com sucesso!!");
                }
                else
                {
                    MessageBox.Show("Artigo já cadastrado!");
                }

                List<Artigo> art = cadArtigo.listaArtigos();
                dgvCadArtigos.DataSource = art;

                txtId.Text = "";
                txtNome.Text = "";
                txtQuantidade.Text = "";
                txtPrecoVenda.Text = "";
                txtDescricao.Text = "";
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            Artigo atualizarArtigo = new Artigo();
            int Id = int.Parse(txtId.Text);
            string precoVenda = txtPrecoVenda.Text.Replace(",", ".");

            atualizarArtigo.Atualizar(Id, txtNome.Text, txtQuantidade.Text, precoVenda, txtDescricao.Text);
            MessageBox.Show("Artigo atualizado com sucesso!!");
            List<Artigo> art = atualizarArtigo.listaArtigos();
            dgvCadArtigos.DataSource = art;

            txtId.Text = "";
            txtNome.Text = "";
            txtQuantidade.Text = "";
            txtPrecoVenda.Text = "";
            txtDescricao.Text = "";
        }

        private void btnApagar_Click(object sender, EventArgs e)
        {
            Artigo apagarArtigo = new Artigo();
            int Id = int.Parse(txtId.Text);
            apagarArtigo.Apagar(Id);

            MessageBox.Show("Artigo apagado com sucesso!!");
            List<Artigo> art = apagarArtigo.listaArtigos();
            dgvCadArtigos.DataSource = art;

            txtId.Text = "";
            txtNome.Text = "";
            txtQuantidade.Text = "";
            txtPrecoVenda.Text = "";
            txtDescricao.Text = "";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Artigo buscarArtigo = new Artigo();
            int Id = int.Parse(txtId.Text);
            buscarArtigo.Buscar(Id);

            txtNome.Text = buscarArtigo.nome;
            txtQuantidade.Text = buscarArtigo.quantidade;
            txtPrecoVenda.Text = buscarArtigo.precoVenda.Replace(".", ",");
            txtDescricao.Text = buscarArtigo.descricao;
        }

        public bool verificaVazios()
        {
            if(txtNome.Text == "" || txtQuantidade.Text == "" || txtPrecoVenda.Text == "" || txtDescricao.Text == "")
            {
                MessageBox.Show("Preencha todos os campos!");
                return false;
            }
            return true;
        }

        
    }
}
