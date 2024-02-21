using Microsoft.Data.Sqlite;
using System;
using System.IO;
using System.Windows.Forms;

namespace GerenciadorSenhas
{
    static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string strConnectionString = String.Format(@"Data Source={0}\{1};", Application.StartupPath, "BANCO.DB");
            bool runner = true;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (!File.Exists("BANCO.DB"))
            {
                File.Create(Application.StartupPath + "BANCO.DB");
                // Cria a tabela parametro
                try
                {
                    using (var connection = new SqliteConnection(strConnectionString))
                    {
                        connection.Open();

                        var command = connection.CreateCommand();
                        string query = "create table if not exists parametro(";
                        query = query + "grupo text not null,";
                        query = query + "nome text not null,";
                        query = query + "valor text not null,";
                        query = query + "unique(grupo,nome));";

                        command.CommandText = query;
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception error)
                {
                    runner = false;
                    MessageBox.Show("Erro ao criar a tabela PARAMETRO\n\n" + error.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    GerarLog log = new GerarLog();
                    log.criaLog("["+ DateTime.Now.ToString("dd/MM/yyyy") + "] => " + error.ToString());
                }

                // Cria a tabela senha
                try
                {
                    using (var connection = new SqliteConnection(strConnectionString))
                    {
                        connection.Open();

                        var command = connection.CreateCommand();
                        string query = "create table if not exists senha(";
                        query = query + "codigo integer primary key autoincrement,";
                        query = query + "titulo text not null,";
                        query = query + "senha text not null,";
                        query = query + "descricao text not null);";

                        command.CommandText = query;
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception error)
                {
                    runner = false;
                    MessageBox.Show("Erro ao criar a tabela SENHA\n\n" + error.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    GerarLog log = new GerarLog();
                    log.criaLog("[" + DateTime.Now.ToString("dd/MM/yyyy") + "] => " + error.ToString());
                }

                // Adicionar dados na tabela PARAMETRO
                try
                {
                    using (var connection = new SqliteConnection(strConnectionString))
                    {
                        connection.Open();

                        var command = connection.CreateCommand();
                        string query = "insert or replace into parametro values ('acesso', 'senha', '1234');";

                        command.CommandText = query;
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception error)
                {
                    runner = false;
                    MessageBox.Show("Erro ao inserir dados na tabela PARAMETRO\n\n" + error.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    GerarLog log = new GerarLog();
                    log.criaLog("[" + DateTime.Now.ToString("dd/MM/yyyy") + "] => " + error.ToString());
                }
            }

            if (runner)
            {
                Application.Run(new frmLogin());
            }
            else
            {
                MessageBox.Show("Ocorreu um erro interno, favor verificar", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
