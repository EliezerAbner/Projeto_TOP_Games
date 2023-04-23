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

            cadastroSubmenuDesign();
        }

        private void FrmMenu_Load(object sender, EventArgs e)
        {

        }

        private void cadastroSubmenuDesign() //o programa abrirá com o submenu fechado
        {
            panelCadastro.Visible = false;  

        }

        private void esconderCadastroSubmenu() // quando clicar em outros botões do painel lateral, o submenu será fechado 
        {
            if (panelCadastro.Visible == true) 
            {
            panelCadastro.Visible = false;
            }
        }

        private void mostrarCadastroSubmenu() //quando clicar em cadastro, o submenu abrirá
        {
            if(panelCadastro.Visible == false) 
            {
                panelCadastro.Visible = true;
            }
            else
            {
                panelCadastro.Visible=false;
            }
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

        private void btnVenda_Click(object sender, EventArgs e)
        {
            esconderCadastroSubmenu();
            panel1.Controls.Clear();
            FrmVenda venda = new FrmVenda();
            venda.TopLevel = false;
            panel1.Controls.Add(venda);
            venda.Show();
        }

        private void btnLocacao_Click(object sender, EventArgs e)
        {
            esconderCadastroSubmenu();
            panel1.Controls.Clear();
            FrmLocacao locacao = new FrmLocacao();
            locacao.TopLevel = false;
            panel1.Controls.Add(locacao);
            locacao.Show(); 
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCadastro_Click(object sender, EventArgs e)
        {
            mostrarCadastroSubmenu();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
