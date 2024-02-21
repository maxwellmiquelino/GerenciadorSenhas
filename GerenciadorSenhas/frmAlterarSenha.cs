using GerenciadorSenhas.Properties;
using Microsoft.Data.Sqlite;
using System;
using System.Data;
using System.Windows.Forms;

namespace GerenciadorSenhas
{
    public partial class frmAlterarSenha : Form
    {
        public frmAlterarSenha()
        {
            InitializeComponent();
        }

        private string strConnectionString = String.Format(@"Data Source={0}\{1};", Application.StartupPath, "BANCO.DB");

        private void btnSenhaNova_Click(object sender, EventArgs e)
        {
            SqliteConnection oConn = new SqliteConnection(strConnectionString);
            oConn.Open();
            try
            {
                if (txtNovaSenha.Text == txtNovaSenhaConf.Text && txtSenhaAnterior.Text.Length > 0)
                {
                    SqliteCommand cmd = new SqliteCommand();
                    cmd.CommandText = "update parametro set valor=@senha where grupo = 'acesso' and nome = 'senha' and valor = '" +
                        txtSenhaAnterior.Text + "'";
                    cmd.Parameters.AddWithValue("@senha", txtNovaSenha.Text);
                    cmd.Connection = oConn;
                    cmd.ExecuteNonQuery();
                    pnlAlterarSenha.Visible = false;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
                GerarLog log = new GerarLog();
                log.criaLog("[" + DateTime.Now.ToString("dd/MM/yyyy") + "] Erro => " + error.ToString());
            }
        }

        private void txtSenhaAnterior_Validated(object sender, EventArgs e)
        {
            if (txtSenhaAnterior.Text.Length > 0)
            {
                try
                {
                    // abre a conexão
                    SqliteConnection oConn = new SqliteConnection(strConnectionString);
                    oConn.Open();
                    // define o comando SQL para retornar todos os dados da tabela Cadastro
                    //SQLiteDataAdapter daCadastro = new SQLiteDataAdapter("select count(*) qtde from parametro where valor = '" +
                    //    txtSenhaAnterior.Text + "' and grupo = 'acesso' and nome = 'senha'", oConn);
                    // define o dataset
                    DataSet ds = new DataSet();
                    // preenche o dataset
                    //daCadastro.Fill(ds);
                    // exibe os dados no datagridview
                    //dgvDados.DataSource = ds.Tables[0];
                    // fecha a conexao
                    oConn.Close();
                    if (Int32.Parse(ds.Tables[0].Rows[0].ItemArray[0].ToString()) == 0)
                    {
                        MessageBox.Show("Senha não confere, favor verificar para continuar!");
                        txtSenhaAnterior.Focus();
                    }
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                    GerarLog log = new GerarLog();
                    log.criaLog("[" + DateTime.Now.ToString("dd/MM/yyyy") + "] Erro => " + error.ToString());
                }
            }
        }

        private void txtSenhaAnterior_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtSenhaAnterior.Text.Length > 0 && e.KeyCode == Keys.Return)
            {
                try
                {
                    // abre a conexão
                    SqliteConnection oConn = new SqliteConnection(strConnectionString);
                    oConn.Open();
                    // define o comando SQL para retornar todos os dados da tabela Cadastro
                    //SQLiteDataAdapter daCadastro = new SQLiteDataAdapter("select count(*) qtde from parametro where valor = '" + txtSenhaAnterior.Text + "' and grupo = 'acesso' and nome = 'senha'", oConn);
                    // define o dataset
                    DataSet ds = new DataSet();
                    // preenche o dataset
                    //daCadastro.Fill(ds);
                    // exibe os dados no datagridview
                    //dgvDados.DataSource = ds.Tables[0];
                    // fecha a conexao
                    oConn.Close();
                    if (Int32.Parse(ds.Tables[0].Rows[0].ItemArray[0].ToString()) == 0)
                    {
                        MessageBox.Show("Senha não confere, favor verificar para continuar!");
                        txtSenhaAnterior.Focus();
                    }
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                    GerarLog log = new GerarLog();
                    log.criaLog("[" + DateTime.Now.ToString("dd/MM/yyyy") + "] Erro => " + error.ToString());
                }
            }
        }
    }
}
