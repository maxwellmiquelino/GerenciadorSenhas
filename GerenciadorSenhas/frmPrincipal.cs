using Microsoft.Data.Sqlite;
using System;
using System.Windows.Forms;

namespace GerenciadorSenhas
{
    public partial class frmPrincipal : Form
    {
        private string strConnectionString = String.Format(@"Data Source={0}\{1};", Application.StartupPath, "BANCO.DB");

        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void LimparCampos()
        {
            txtCodigo.Text = null;
            txtTitulo.Text = null;
            txtPassword.Text = null;
            txtDescricao.Text = null;
        }

        private void PesquisaCadastro(string filtro)
        {
            try
            {
                string senha = string.Empty;
                // abre a conexão
                using (var connection = new SqliteConnection(strConnectionString))
                {
                    connection.Open();

                    var command = connection.CreateCommand();
                    command.CommandText = String.Format("select codigo, titulo from senha {0} order by 1", filtro);

                    using (var reader = command.ExecuteReader())
                    {
                        dgvDados.Rows.Clear();
                        while (reader.Read())
                        {
                            dgvDados.Rows.Add(reader.GetString(0), reader.GetString(1));
                        }
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                GerarLog log = new GerarLog();
                log.criaLog("[" + DateTime.Now.ToString("dd/MM/yyyy") + "] Erro => " + error.ToString());
            }
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            PesquisaCadastro("");
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            SqliteConnection oConn = new SqliteConnection(strConnectionString);
            oConn.Open();
            try
            {
                if (txtCodigo.Text.Length == 0 && txtTitulo.Text.Length > 0)
                {
                    SqliteCommand cmd = new SqliteCommand();
                    cmd.CommandText = "insert into senha(titulo,senha,descricao) values(@titulo,@senha,@descricao)";
                    cmd.Parameters.AddWithValue("@titulo", txtTitulo.Text);
                    cmd.Parameters.AddWithValue("@senha", txtPassword.Text);
                    cmd.Parameters.AddWithValue("@descricao", txtDescricao.Text);
                    cmd.Connection = oConn;
                    cmd.ExecuteNonQuery();
                }
                else if (txtCodigo.Text.Length > 0 && txtTitulo.Text.Length > 0)
                {
                    SqliteCommand cmd = new SqliteCommand();
                    cmd.CommandText = "update senha set titulo=@titulo, senha=@senha, descricao=@descricao where codigo=@codigo";
                    cmd.Parameters.AddWithValue("@titulo", txtTitulo.Text);
                    cmd.Parameters.AddWithValue("@senha", txtPassword.Text);
                    cmd.Parameters.AddWithValue("@descricao", txtDescricao.Text);
                    cmd.Parameters.AddWithValue("@codigo", txtCodigo.Text);
                    cmd.Connection = oConn;
                    cmd.ExecuteNonQuery();
                }
                else
                    MessageBox.Show("Favor preencher os campos em branco!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception error)
            {
                MessageBox.Show("Erro ao gravar na tabela SENHA\n\n" + error.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                GerarLog log = new GerarLog();
                log.criaLog("[" + DateTime.Now.ToString("dd/MM/yyyy") + "] Erro => " + error.ToString());
            }
            finally
            {
                PesquisaCadastro("");
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text.Length > 0)
            {
                PesquisaCadastro("where codigo = " + txtCodigo.Text);
            }
            else if (txtTitulo.Text.Length > 0)
            {
                PesquisaCadastro("where titulo like '" + txtTitulo.Text + "'");
            }
            else
            {
                PesquisaCadastro("");
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
            PesquisaCadastro("");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txtPassword.PasswordChar = '\0';
        }

        private void txtPassword_Click(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '*';
        }

        private void dgvDados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string filtro = "where codigo = " + dgvDados.CurrentRow.Cells[0].Value.ToString();
                // abre a conexão
                using (var connection = new SqliteConnection(strConnectionString))
                {
                    connection.Open();

                    var command = connection.CreateCommand();
                    command.CommandText = String.Format("select * from senha {0} order by 1", filtro);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            txtCodigo.Text = reader.GetString(0);
                            txtTitulo.Text = reader.GetString(1);
                            txtPassword.Text = reader.GetString(2);
                            txtDescricao.Text = reader.GetString(3);
                        }
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Erro ao criar a tabela PARAMETRO\n\n" + error.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                GerarLog log = new GerarLog();
                log.criaLog("[" + DateTime.Now.ToString("dd/MM/yyyy") + "] Erro => " + error.ToString());
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmPrincipal_MouseMove(object sender, MouseEventArgs e)
        {
            txtPassword.PasswordChar = '*';
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dgvDados.Rows.Count > 0)
            {
                if (MessageBox.Show("Deseja excluir o código " + dgvDados.CurrentRow.Cells[0].Value.ToString(), "Gerenciador de Senhas",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;

                try
                {
                    SqliteConnection objConn = new SqliteConnection(strConnectionString);
                    objConn.Open();
                    SqliteCommand cmd = new SqliteCommand();
                    cmd.CommandText = "delete from senha where codigo = " + dgvDados.CurrentRow.Cells[0].Value.ToString();
                    cmd.Connection = objConn;
                    cmd.ExecuteNonQuery();
                    LimparCampos();
                }
                catch (Exception error)
                {
                    MessageBox.Show("Erro ao excluir tabela SENHA\n\n" + error.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    GerarLog log = new GerarLog();
                    log.criaLog("[" + DateTime.Now.ToString("dd/MM/yyyy") + "] Erro => " + error.ToString());
                }
                finally
                {
                    PesquisaCadastro("");
                }
            }
        }

        private void frmPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.ExitThread();
        }
    }
}