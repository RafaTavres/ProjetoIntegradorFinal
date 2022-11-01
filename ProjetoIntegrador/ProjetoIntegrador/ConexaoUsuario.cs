using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MySql.Data.MySqlClient;

namespace ProjetoIntegrador
{

    internal class ConexaoUsuario : Conexao
    {
        Thread t1;
        MySqlCommand coman = new MySqlCommand();
        MySqlConnection Conexao;

        public bool tem = false;
        public string mensagem;

        string origemCompleto = "";
        string foto = "";
        string pastaDestino = Globais.caminhoFoto;
        string destinoCompleto = "";
        byte[] imagem_byte = null;
        MySqlDataReader dr;

        public bool VerificarLogin(string NomeTxt, string CpfTxt, string SenhaTxt)
        {
            coman.CommandText = "select * from tabela1 where Nome = @NomeTxt and Cpf = @CpfTxt and Senha = @SenhaTxt";
            coman.Parameters.AddWithValue("@NomeTxt", NomeTxt);
            coman.Parameters.AddWithValue("@CpfTxt", CpfTxt);
            coman.Parameters.AddWithValue("@SenhaTxt", SenhaTxt);


            //Fazer a classe para a conexao
            try
            {
                string data_source = "datasource=localhost;username=root;password=mysql123!;database=ProjetoInt";
                Conexao = new MySqlConnection(data_source);

                Conexao conex = new Conexao();
                dr = coman.ExecuteReader();
                if (dr.HasRows)
                {
                    tem = true;
                }

            }
            catch (MySqlException)
            {
                this.mensagem = "Erro com banco de dados";
            }
            return tem;
        }
        public void Salvar(string NomeTxt, string CpfTxt, string SenhaTxt)
        {
            try
            {
                string data_source = "datasource=localhost;username=root;password=mysql123!;database=ProjetoInt";
                // Criar Conex
                Conexao = new MySqlConnection(data_source);
                string sql = "insert into tabela1 (nome,Cpf,senha) Values ('" + NomeTxt + "','" + CpfTxt + "','" + SenhaTxt + "')";

                //Executa Insert
                MySqlCommand comand = new MySqlCommand(sql, Conexao);

                Conexao.Open();

                comand.ExecuteReader();

                MessageBox.Show("Concluido!");


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Conexao.Close();
            }
        }

 

        public void SalvarFossil(string NomeFossil,string BoxRegioes,string DestinoCompleto,string DescricaoTex)
        {
           

            try
            {

                string data_source = "datasource=localhost;username=root;password=mysql123!;database=ProjetoInt";
                // Criar Conex                                                                                  
                Conexao = new MySqlConnection(data_source);
                string sql = "insert into tb_Fossil (Nome_Fossil,Regiao,fotoFossil,DescricaoFossil) Values ('" + NomeFossil + "','" + BoxRegioes + "','" + DestinoCompleto + "','" + DescricaoTex + "')";

                //Executa Insert
                MySqlCommand comand = new MySqlCommand(sql, Conexao);

                Conexao.Open();

                comand.ExecuteReader();

                MessageBox.Show("Concluido!");


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Conexao.Close();
            }


            if (destinoCompleto == "")
            {
                if (MessageBox.Show("Sem Foto Selecionada, deseja continuar?", "ERRO", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }
            }
            if (destinoCompleto != "")
            {

                System.IO.File.Copy(origemCompleto, destinoCompleto, true);
                if (File.Exists(destinoCompleto))
                {
                    //FotoFossilTxt.ImageLocation = destinoCompleto;

                    /*FileStream fstream = new FileStream(this.FotoFossilTxt.Text, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fstream);
                    imagem_byte = br.ReadBytes((int)fstream.Length);*/


                }
                else
                {
                    if (MessageBox.Show("Erro ao Selecionar Foto Selecionada, deseja continuar?", "ERRO", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        return;
                    }
                }
            }
        }

    }
}
