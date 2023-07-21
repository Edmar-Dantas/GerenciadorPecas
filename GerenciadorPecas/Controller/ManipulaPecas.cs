using GerenciadorPecas.Model;
using GerenciadorPecas.View;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorPecas.Controller
{
    internal class ManipulaPecas
    {
        public void CadPecas()
        {
            SqlConnection cn = new SqlConnection(Conexao.Conectar());
            SqlCommand cmd = new SqlCommand("pcadastrarPecas", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            //AddWithValue(Variavel procedure, model.variavel)
            try
            {
                cmd.Parameters.AddWithValue("Pecas", Pecas.Peca);
                cmd.Parameters.AddWithValue("Marcas", Pecas.Marca);
                cmd.Parameters.AddWithValue("Capacidades", Pecas.Capacidade);

                //Lidar com id auto increment
                SqlParameter nv = cmd.Parameters.Add("IdPeca", SqlDbType.Int);
                nv.Direction = ParameterDirection.Output;
                cn.Open();
                //Para colocar no banco
                cmd.ExecuteNonQuery();

                var resposta = MessageBox.Show("Peça cadastrada com sucesso\nDeseja cadastrar outra peça?","Novo Registro",MessageBoxButtons.YesNo,MessageBoxIcon.Exclamation);
                if (resposta == DialogResult.Yes)
                {
                    TelaCadastrarPeca telaCadastrarPeca = new TelaCadastrarPeca();
                    telaCadastrarPeca.AbrirCadastro();
                }
                else
                {
                    return;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void BuscaPecaCod()
        {
            SqlConnection cn = new SqlConnection(Conexao.Conectar());
            SqlCommand cmd = new SqlCommand("pbuscaPecaId", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            //@ Tanto faz
            try
            {
                cmd.Parameters.AddWithValue("@IdPeca", Pecas.Codigo);
                cn.Open();
                //Para ler os registros e guardar em objeto
                var registros = cmd.ExecuteReader();
                //Model - Procedure
                if (registros.Read())
                {
                    Pecas.Codigo = Convert.ToInt32(registros["IdPeca"]);
                    Pecas.Peca = (string)registros["Pecas"];
                    Pecas.Marca = (string)registros["Marcas"];
                    Pecas.Capacidade = (string)registros["Capacidades"];
                }
                else
                {
                    Pecas.Codigo = 0;
                    Pecas.Peca = "";
                    Pecas.Marca = "";
                    Pecas.Capacidade = "";
                    MessageBox.Show("Peça não encontrada", "Pesquisa Código");

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void BuscaPecaNome()
        {
            SqlConnection cn = new SqlConnection(Conexao.Conectar());
            //Diz qual procedure vai ser usada
            SqlCommand cmd = new SqlCommand("pbuscaPecaNome", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            //@ Tanto faz
            try
            {
                //Setar quais parametros vao ser usados
                cmd.Parameters.AddWithValue("Pecas", Pecas.Peca);
                cmd.Parameters.AddWithValue("Marcas", Pecas.Marca);
                cmd.Parameters.AddWithValue("Capacidades", Pecas.Capacidade);
                //Abrir conexao com o banco de ddos
                cn.Open();
                //Prepara um objeto para guardar os registros
                var registros = cmd.ExecuteReader();
                //Model - Procedure
                if (registros.Read()) //Se ouver registros e depois a view vai "Extrair" os dados daqui dps que a função for executada
                {
                    Pecas.Peca = (string)registros["Pecas"];
                    Pecas.Marca = (string)registros["Marcas"];
                    Pecas.Capacidade = (string)registros["Capacidades"];
                }
                else
                {
                    Pecas.Peca = "";
                    Pecas.Marca = "";
                    Pecas.Capacidade = "";
                    MessageBox.Show("Peça não encontrada", "Pesquisa Código");

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void DeletarPeca()
        {
            SqlConnection cn = new SqlConnection(Conexao.Conectar());
            //Diz qual procedure vai ser usada
            SqlCommand cmd = new SqlCommand("pdeletaId", cn);
            //Variavel do tipo Procedure
            cmd.CommandType = CommandType.StoredProcedure;

            //@ Tanto faz
            try
            {
                //Abrir conexao com o banco de dados
                cn.Open();
                //Setar quais parametros vao ser usados - Model Parametros
                //O model ja vai ter sido carregado pela view com dados que eu preciso, so preciso mandar isso para uma procedure especifica
                cmd.Parameters.AddWithValue("@IdPeca", Pecas.Codigo);
                
                //Executa o a procedure com parametros passados
                cmd.ExecuteNonQuery();
                //Model - Procedure
            }
            catch (Exception)
            {
                MessageBox.Show("Não foi possivel deletar");
                throw;
            }
        }

        public void AlterarPeca()
        {

            {
                SqlConnection cn = new SqlConnection(Conexao.Conectar());
                //Diz qual procedure vai ser usada
                SqlCommand cmd = new SqlCommand("pAlterarPecas", cn);
                //Variavel do tipo Procedure
                cmd.CommandType = CommandType.StoredProcedure;

                //@ Tanto faz
                try
                {
                    //Lembrar que os dados sao da procedure e do Model
                    cmd.Parameters.AddWithValue("Pecas", Pecas.Peca);
                    cmd.Parameters.AddWithValue("Marcas", Pecas.Marca);
                    cmd.Parameters.AddWithValue("Capacidades", Pecas.Capacidade);
                    //Setar quais parametros vao ser usados - Model Parametros
                    //O model ja vai ter sido carregado pela view com dados que eu preciso, so preciso mandar isso para uma procedure especifica
                    cmd.Parameters.AddWithValue("@IdPeca", Pecas.Codigo);
                    //Abrir conexao com o banco de dados
                    cn.Open();
                    //Executa o a procedure com parametros passados
                    cmd.ExecuteNonQuery();
                    //Model - Procedure
                }
                catch (Exception)
                {
                    MessageBox.Show("Não foi possivel Alterar");
                    throw;
                }
            }
        }
    }
}
