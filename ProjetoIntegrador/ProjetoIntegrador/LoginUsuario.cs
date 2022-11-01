using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ProjetoIntegrador
{

    public partial class LoginUsuario : Form
    {
        Thread t1;
        MySqlCommand coman = new MySqlCommand();
        MySqlConnection Conexao;
        public LoginUsuario()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void Nometxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Senhatxt2_TextChanged(object sender, EventArgs e)
        {

        }

        private void BotaoVoltarLogin_Click(object sender, EventArgs e)
        {

        }
        public void Login()
        {
            ConexaoUsuario conex = new ConexaoUsuario();
            conex.VerificarLogin(Nometxt.Text, Cpftxt2.Text, Senhatxt2.Text);
            Controle cn = new Controle();
            cn.Acessar(Nometxt.Text, Cpftxt2.Text, Senhatxt2.Text);
            if (cn.tem == true)
            {
                this.Close();
                t1 = new Thread(AbrirJanela);
                t1.SetApartmentState(ApartmentState.STA);
                t1.Start();
            }
        }
        private void AbrirJanela(object objeto)
        {
            Application.Run(new UsuarioJanela());
        }
    }

}
