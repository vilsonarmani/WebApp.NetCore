using System.IO;


namespace Alura.ListaLeitura.App.HTML
{
    public class HTMLUtils
    {
        public static string CarregaArquivoHTML(string nomeArquivo)
        {
            var nomeCompletoArquivo = $"HTML/{nomeArquivo}.html";

            if (File.Exists(nomeCompletoArquivo))
            {
                using (var arquivo = File.OpenText(nomeCompletoArquivo))
                {
                    return arquivo.ReadToEnd();// lê todo o conteúdo e coloca na string
                }
            }

            return "NAO EXISTE ESSA PORRA";
        }
    }
}
