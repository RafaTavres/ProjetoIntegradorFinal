using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ProjetoIntegrador
{
    public partial class NovoUsuario : Form
    {
        Thread t1;
        MySqlConnection Conexao;

        public NovoUsuario()
        {
            InitializeComponent();
        }

        private void Janela2_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Save_Click(object sender, EventArgs e)
        {
            ConexaoUsuario conex = new ConexaoUsuario();
            conex.Salvar(NomeTxt.Text, CpfTxt.Text, SenhaTxt.Text);

        }

        private void Senha_Click(object sender, EventArgs e)
        {

        }

        private void CpfTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void VoltarBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            t1 = new Thread(AbrirJanela);
            t1.SetApartmentState(ApartmentState.STA);
            t1.Start();
        }
        private void AbrirJanela(object objeto)
        {
            Application.Run(new Form1());
        }

       
    }
}
