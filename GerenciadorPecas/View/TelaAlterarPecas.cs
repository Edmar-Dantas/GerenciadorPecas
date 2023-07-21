using GerenciadorPecas.Controller;
using GerenciadorPecas.Model;
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
    public partial class TelaAlterarPecas : Form
    {
        public TelaAlterarPecas()
        {
            InitializeComponent();
        }
        //Possibilidade de Chabu
        private void TelaAlterarPecas_Load(object sender, EventArgs e)
        {

        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            Pecas.Codigo = Convert.ToInt32(textBoxCodigo.Text);
            Pecas.Marca = textBoxMarca.Text;
            Pecas.Peca= textBoxPeca.Text;
            Pecas.Capacidade= textBoxCapacidade.Text;

            //Chama o controle e instacia
            ManipulaPecas mpecas = new ManipulaPecas();
            mpecas.AlterarPeca();
        }
    }
}
