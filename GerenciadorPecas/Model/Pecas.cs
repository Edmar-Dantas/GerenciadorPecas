using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorPecas.Model
{
    internal class Pecas
    {
        private static int codigo;
        private static string peca;
        private static string marca;
        private static string capacidade;

        public static int Codigo { get => codigo; set => codigo = value; }
        public static string Peca { get => peca; set => peca = value; }
        public static string Marca { get => marca; set => marca = value; }
        public static string Capacidade { get => capacidade; set => capacidade = value; }
    }
}
