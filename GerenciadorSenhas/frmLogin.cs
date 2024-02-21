using System;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;

namespace GerenciadorSenhas
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        private string strConnectionString = String.Format(@"Data Source={0}\{1};", Application.StartupPath, "BANCO.DB");

        private void txtSenha_TextChanged(object sender, EventArgs e)
        {
            if (txtSenha.Text.Length == 0)
            {
                lblMsg.Text = "";
            }
        }
        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtSenha.Text = string.Empty;
        }

        private void txtSenha_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtSenha.TextLength > 0 && e.KeyCode == Keys.Return)
            {
                try
                {
                    string senha = string.Empty;
                    // abre a conexão
                    using (var connection = new SqliteConnection(strConnectionString))
                    {
                        connection.Open();

                        var command = connection.CreateCommand();
                        command.CommandText = @"select valor from parametro where grupo = 'acesso' and nome = 'senha'";

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var valor = reader.GetString(0);

                                senha = valor;
                            }
                        }
                    }

                    if (txtSenha.Text == senha)
                    {
                        frmPrincipal frm = new frmPrincipal();
                        this.Hide();
                        frm.Show();
                    }
                    else
                    {
                        lblMsg.Text = "Senha não confere, favor verificar!";
                    }
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    GerarLog log = new GerarLog();
                    log.criaLog("[" + DateTime.Now.ToString("dd/MM/yyyy") + "] Erro => " + error.ToString());
                }
            }
        }
    }
}