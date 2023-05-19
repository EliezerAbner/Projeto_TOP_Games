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
            txtValor.Text = listar.valorLocacao.ToString();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            PrecoLocacao cadPreco = new PrecoLocacao();
            cadPreco.buscarPreco();
  
            if (Convert.ToBoolean(cadPreco.valorLocacao))
            {
                cadPreco.atualizarPreco(Convert.ToDouble(txtValor.Text));
                MessageBox.Show("Preço atualizado com sucesso!");
                this.Close();
            }
            else
            {
                cadPreco.cadastrarPreco(Convert.ToDouble(txtValor.Text));
                MessageBox.Show("Preço cadastrado com sucesso!");
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
