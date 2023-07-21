using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GerenciadorPecas.Controller;
using GerenciadorPecas.Model;

namespace GerenciadorPecas.View
{
    public partial class TelaPesquisaPecas : Form
    {
        public TelaPesquisaPecas()
        {
            InitializeComponent();
        }

        private void btnBuscarCod_Click(object sender, EventArgs e)
        {
            Pecas.Codigo = Convert.ToInt32(textBoxCodigo.Text);

            ManipulaPecas mpecas = new ManipulaPecas();
            mpecas.BuscaPecaCod();

            textBoxCodigo.Text = Convert.ToString(textBoxCodigo.Text);
            textBoxPeca.Text = Pecas.Peca;
            textBoxMarca.Text = Pecas.Marca;
            textBoxCapacidade.Text = Pecas.Capacidade;


        }
    }
}
