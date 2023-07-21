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
    public partial class TelaDeletaPecas : Form
    {
        public TelaDeletaPecas()
        {
            InitializeComponent();
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            Pecas.Codigo = Convert.ToInt32(textBoxCodigo.Text);
            ManipulaPecas mPecas = new ManipulaPecas();
            mPecas.DeletarPeca();
        }
    }
}
