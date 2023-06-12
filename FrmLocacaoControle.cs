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
    public partial class FrmLocacaoControle : Form
    {
        public int height {  get; set; }
        public FrmLocacaoControle()
        {
            InitializeComponent();
        }

        private void FrmLocacaoControle_Load(object sender, EventArgs e)
        {
            height = 250;
            Locacao controleLocacoes = new Locacao();
            List<Locacao> listaLocacoes = controleLocacoes.listaTodasLocacoes();

            foreach(var i in listaLocacoes)
            {
                DateTime dataFormatoUs = Convert.ToDateTime(i.dataRetorno);
                Cliente cliente = new Cliente();
                Jogo jogo = new Jogo();
                cliente.Buscar(i.clienteId);
                jogo.Buscar(i.jogoId);

                string nomeCliente = cliente.nome;
                string jogoAlugado = jogo.titulo;
                string dataRetorno = converterDatas(dataFormatoUs);

                criarLabel(nomeCliente, jogoAlugado, dataRetorno);
            }
        }

        private void criarLabel(string nomeCliente, string jogoAlugado, string dataRetorno)
        {
            Label lblClientesJogosRetorno = new Label();
            this.Controls.Add(lblClientesJogosRetorno);

            lblClientesJogosRetorno.AutoSize = false;
            lblClientesJogosRetorno.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblClientesJogosRetorno.Location = new System.Drawing.Point(3, height);
            lblClientesJogosRetorno.Name = "lblClientesJogosRetorno";
            lblClientesJogosRetorno.Size = new System.Drawing.Size(481, 30);
            lblClientesJogosRetorno.TabIndex = 0;
            lblClientesJogosRetorno.Text = ""+nomeCliente+"             "+jogoAlugado+"           "+dataRetorno+"";
            height += 50;
        }

        public string converterDatas(DateTime valorAntigo) //recebe yyyy-mm-dd , sai dd/mm/yyyy
        {
            string inverterData = valorAntigo.ToString("dd-MM-yyyy");
            string valorNovo = inverterData.Replace("-", "/");

            return valorNovo;
        }
    }
}
