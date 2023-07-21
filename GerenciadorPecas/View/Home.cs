using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GerenciadorPecas.View
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cadastrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TelaCadastrarPeca telaCadastrar = new TelaCadastrarPeca();
            telaCadastrar.Show();
        }

        private void buscarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TelaPesquisaPecas telaPesquisaPecas = new TelaPesquisaPecas();
            telaPesquisaPecas.Show();
        }

        private void alterarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TelaAlterarPecas telaAlterarPecas = new TelaAlterarPecas();
            telaAlterarPecas.Show();
        }

        private void deletarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TelaDeletaPecas telaDeletaPecas = new TelaDeletaPecas();
            telaDeletaPecas.Show();
        }
    }
}
