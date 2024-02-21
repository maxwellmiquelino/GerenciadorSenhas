using System;
using System.IO;
using System.Windows.Forms;

namespace GerenciadorSenhas
{
    public class GerarLog
    {
        string nomeArquivo = Application.StartupPath + "\\LOG\\" + DateTime.Now.ToString("yyyyMMdd") + "-APP.TXT";

        public void criaLog(string texto)
        {
            if (!Directory.Exists(Application.StartupPath + @"\LOG\"))
                Directory.CreateDirectory(Application.StartupPath + @"\LOG\");

            // Cria um novo arquivo e devolve um StreamWriter para ele
            StreamWriter writer = new StreamWriter(nomeArquivo, true);

            // Agora é só sair escrevendo
            writer.WriteLine(DateTime.Now.ToString() + " - " + texto);
            writer.WriteLine("");

            // Não esqueça de fechar o arquivo ao terminar
            writer.Close();
        }
    }
}