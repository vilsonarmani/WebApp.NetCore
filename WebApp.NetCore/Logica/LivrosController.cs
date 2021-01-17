using Alura.ListaLeitura.App.HTML;
using Alura.ListaLeitura.App.Negocio;
using Alura.ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alura.ListaLeitura.App.Logica
{
    public class LivrosController
    {      

        public string Detalhes(int id)
        {
            var repo = new LivroRepositorioCSV();
            var livro = repo.Todos.First(l => l.Id == id);

            return livro.Detalhes();
        }

        public static Task ParaLer(HttpContext context)
        {
            var _repo = new LivroRepositorioCSV();
            //var conteudoArquivo = HTMLUtils.CarregaArquivoHTML("para-ler");

            return context.Response.WriteAsync(CarregaLivrosHTML(_repo.ParaLer.Livros, "#LISTADELIVROS#", HTMLUtils.CarregaArquivoHTML("para-ler")));

            //return context.Response.WriteAsync(_repo.ParaLer.ToString());
        }

        public static Task Lendo(HttpContext context)
        {
            var _repo = new LivroRepositorioCSV();
            // var conteudoArquivo = HTMLUtils.CarregaArquivoHTML("lendo");            

            return context.Response.WriteAsync(text: CarregaLivrosHTML(_repo.Lendo.Livros, "#LISTADELIVROS#", HTMLUtils.CarregaArquivoHTML("lendo")));
        }        

        public static Task Lidos(HttpContext context)
        {
            var _repo = new LivroRepositorioCSV();
            //var conteudoArquivo = HTMLUtils.CarregaArquivoHTML("lidos");

            return context.Response.WriteAsync(CarregaLivrosHTML(_repo.Lidos.Livros, "#LISTADELIVROS#", HTMLUtils.CarregaArquivoHTML("lidos")));
        }

        private static string CarregaLivrosHTML(IEnumerable<Livro> listaDeLeitura,
            string a_TAG,
            string conteudoHTML)
        {
            if (listaDeLeitura.Count() > 0)
            {
                conteudoHTML = conteudoHTML
                                    .Replace(a_TAG, $"<ul>#LISTADELIVROS#");
                foreach (var livro in listaDeLeitura)
                {
                    conteudoHTML = conteudoHTML
                        .Replace(a_TAG, $"<li>{livro.Titulo} - {livro.Autor}</li>#LISTADELIVROS#");
                }
                conteudoHTML = conteudoHTML
                    .Replace(a_TAG, "</ul");
            }
            else
            {
                conteudoHTML = conteudoHTML
                                    .Replace(a_TAG, "Não há livros para ser exibidos!");
            }

            return conteudoHTML;
        }
        public string Teste()
        {
            return "Nova funcionalidade implementada!";
        }
    }
}
