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
    public partial class FrmLocacaoPreco : Form
    {
        public FrmLocacaoPreco()
        {
            InitializeComponent();
        }

        private void FrmLocacaoPreco_Load(object sender, EventArgs e)
        {
            PrecoLocacao listar = new PrecoLocacao();
            listar.buscarPreco();
            txtLocacao.Text = listar.valorLocacao.ToString();
            txtMulta.Text = listar.valorMulta.ToString(); 
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            PrecoLocacao cadPreco = new PrecoLocacao();
            cadPreco.buscarPreco();
  
            if (Convert.ToBoolean(cadPreco.valorLocacao))
            {
                cadPreco.atualizarPreco(Convert.ToDouble(pastorSistemaMetrico(txtLocacao)), Convert.ToDouble(pastorSistemaMetrico(txtMulta)));
                MessageBox.Show("Preço atualizado com sucesso!");
                this.Close();
            }
            else
            {
                cadPreco.cadastrarPreco(Convert.ToDouble(txtLocacao.Text), Convert.ToDouble(txtMulta.Text));
                MessageBox.Show("Preço cadastrado com sucesso!");
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private string pastorSistemaMetrico(TextBox txt)
        {
            string valorNovo = txt.Text.Replace(",", ".");

            return valorNovo;
        }
    }
}
