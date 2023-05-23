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
        public DateTime dataRetorno { get; set; }
        public DateTime dataHoje { get;set; }
        public double valorMulta { get;set; }
        public FrmLocacaoDevolucao()
        {
            InitializeComponent();
        }

        private void FrmLocacaoDevolucao_Load(object sender, EventArgs e)
        {
            panelMulta.Visible = false;
            string hoje = DateTime.Now.ToString();
            dataHoje = Convert.ToDateTime(hoje);
        }

        private void btnDevolver_Click(object sender, EventArgs e)
        {
            int tBCliente = int.Parse(txtCliente.Text.Trim());
            int tBJogo = int.Parse(txtJogo.Text.Trim());

            if (verificaVazios(txtCliente.Text, txtJogo.Text))
            {
                Locacao encerrar = new Locacao();
                encerrar.buscarLocacao(tBCliente, tBJogo);
                dataRetorno = Convert.ToDateTime(encerrar.dataRetorno);
                
                if (calculoMulta())
                {
                    lblMulta.Text = Convert.ToString(valorMulta).Replace(".",",");
                    panelMulta.Visible = true;
                    encerrar.excluirLocacao(tBCliente, tBJogo);
                    MessageBox.Show("Jogo devolvido com sucesso!");
                }
                else
                {
                    encerrar.excluirLocacao(tBCliente, tBJogo);
                    MessageBox.Show("Jogo devolvido com sucesso!");

                    txtCliente.Text = "";
                    txtJogo.Text = "";
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
            if (dataRetorno < dataHoje) //data de entrega for menor que a de hoje
            {
                PrecoLocacao multa = new PrecoLocacao();
                multa.buscarPreco();
                double taxa = multa.valorMulta;

                int dias = (dataHoje - dataRetorno).Days;
                valorMulta = dias * taxa;
                //conte os dias passados
                //e calcule a multa

                return true;
            }
            else
            {
                return false;
            }
        }
        
    }
}
