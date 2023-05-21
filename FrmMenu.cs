using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TOP_Games
{
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();
            FrmSplash abertura = new FrmSplash();
            abertura.Show();
            Application.DoEvents();
            Thread.Sleep(3000);
            abertura.Close();

            cadastroSubmenuDesign(panelCadastro);
            cadastroSubmenuDesign(panelLocacao);
        }

        private void FrmMenu_Load(object sender, EventArgs e)
        {

        }

        private void cadastroSubmenuDesign(Panel panel) //o programa abrirá com o submenu fechado
        {
            panel.Visible = false;

        }

        private void esconderCadastroSubmenu(Panel panel) // quando clicar em outros botões do painel lateral, o submenu será fechado 
        {
            if (panel.Visible == true) 
            {
                panel.Visible = false;
            }
        }

        private void mostrarCadastroSubmenu(Panel panel) //quando clicar em cadastro, o submenu abrirá
        {
            if(panel.Visible == false) 
            {
                panel.Visible = true;
            }
            else
            {
                panel.Visible=false;
            }
        }

        //PAINEL CADASTRO
        private void btnCadastro_Click(object sender, EventArgs e)
        {
            mostrarCadastroSubmenu(panelCadastro);
            esconderCadastroSubmenu(panelLocacao);
        }

        private void btnCadastroClientes_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            FrmCadastroClientes cadastroClientes = new FrmCadastroClientes();
            cadastroClientes.TopLevel = false;
            panel1.Controls.Add(cadastroClientes);
            cadastroClientes.Show();
        }

        private void btnCadastroArtigos_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            FrmCadastroArtigos cadastroArtigos = new FrmCadastroArtigos();
            cadastroArtigos.TopLevel = false;
            panel1.Controls.Add(cadastroArtigos);
            cadastroArtigos.Show();
        }

        private void btnCadastroJogos_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            FrmCadastroJogos cadastroJogos = new FrmCadastroJogos();
            cadastroJogos.TopLevel = false;
            panel1.Controls.Add(cadastroJogos);
            cadastroJogos.Show();
        }

        //PAINEL LOCAÇÃO
        private void btnLocacao_Click(object sender, EventArgs e)
        {
            mostrarCadastroSubmenu(panelLocacao);
            esconderCadastroSubmenu(panelCadastro);
        }

        private void btnRealizarLocacao_Click(object sender, EventArgs e)
        {
            esconderCadastroSubmenu(panelCadastro);
            panel1.Controls.Clear();
            FrmLocacao locacao = new FrmLocacao();
            locacao.TopLevel = false;
            panel1.Controls.Add(locacao);
            locacao.Show();
        }

        private void btnDevolucao_Click(object sender, EventArgs e)
        {
            FrmLocacaoDevolucao devolucao = new FrmLocacaoDevolucao();
            devolucao.Show();
        }

        private void btnControleMultas_Click(object sender, EventArgs e)
        {
            FrmLocacaoControle controle = new FrmLocacaoControle();
            panel1.Controls.Clear();
            controle.TopLevel = false;
            panel1.Controls.Add(controle);
            controle.Show();
        }

        private void btnVenda_Click(object sender, EventArgs e)
        {
            esconderCadastroSubmenu(panelCadastro);
            esconderCadastroSubmenu(panelLocacao);
            panel1.Controls.Clear();
            FrmVenda venda = new FrmVenda();
            venda.TopLevel = false;
            panel1.Controls.Add(venda);
            venda.Show();
        }

        //PAINEL SUPERIOR
        private void btnConfig_Click(object sender, EventArgs e)
        {
            FrmLocacaoPreco locacaoPreco = new FrmLocacaoPreco();
            locacaoPreco.Show();
        }

        private void btnSairIcone_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
