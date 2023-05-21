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
    public partial class FrmLocacaoDevolucao : Form
    {
        public string dataLocacao { get; set; }
        public string dataHoje { get;set; }
        public FrmLocacaoDevolucao()
        {
            InitializeComponent();
        }

        private void FrmLocacaoDevolucao_Load(object sender, EventArgs e)
        {
            panelMulta.Visible = false;
            dataHoje = DateTime.Now.ToString();
        }

        private void btnDevolver_Click(object sender, EventArgs e)
        {
            if (verificaVazios(txtCliente.Text, txtJogo.Text))
            {
                Locacao encerrar = new Locacao();
                encerrar.buscarLocacao(int.Parse(txtCliente.Text), int.Parse(txtJogo.Text));
                string dataLocacao = encerrar.dataLocacao;
                if (calculoMulta())
                {
                    encerrar.excluirLocacao(int.Parse(txtCliente.Text), int.Parse(txtJogo.Text), dataLocacao);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private bool verificaVazios(string idCliente, string idJogo)
        {
            if(idCliente == null || idJogo == null)
            {
                MessageBox.Show("Preencha os campos!");
                txtCliente.Text = "";
                txtJogo.Text = "";
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool calculoMulta()
        {
            //comparar tempo para calculo de multa, que deve ser definido pelo usuario la no form de preços
            //boa sorte :)
        }
    }
}
