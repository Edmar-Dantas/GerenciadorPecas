using GerenciadorPecas.Controller;
using GerenciadorPecas.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GerenciadorPecas.View
{
    public partial class TelaCadastrarPeca : Form
    {
        public TelaCadastrarPeca()
        {
            InitializeComponent();
        }

        private void btnCadastrarPecas_Click(object sender, EventArgs e)
        {
            Pecas.Peca = textBoxPecas.Text;
            Pecas.Marca = textBoxMarcas.Text;
            Pecas.Capacidade = textBoxCapacidades.Text;

            ManipulaPecas mPeca = new ManipulaPecas();
            mPeca.CadPecas();
        }

        public void AbrirCadastro()
        {
            this.ShowDialog();
        }
    }
}
