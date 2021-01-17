using Alura.ListaLeitura.App.HTML;
using Alura.ListaLeitura.App.Negocio;
using Alura.ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.ListaLeitura.App.Logica
{
    public class CadastroLogica
    {
        public static Task ProcessaFormulario(HttpContext context)
        {
            /* PEGA DA QUERYSTRING
               Titulo = context.Request.Query["titulo"].First(),
               Autor = (string)context.Request.Query["autor"].First()*/

            var livro = new Livro()
            {
                Titulo = context.Request.Form["titulo"].First(),
                Autor = context.Request.Form["autor"].First()
            };

            var repo = new LivroRepositorioCSV();
            repo.Incluir(livro);
            return context.Response.WriteAsync("O Livro foi Adicionado com sucesso");
        }

        public static Task ExibeFormulario(HttpContext context)
        {
            var html = HTMLUtils.CarregaArquivoHTML("formulario");
            return context.Response.WriteAsync(html);
        }

        public static Task NovoLivroPraLer(HttpContext context)
        {
            var livro = new Livro()
            {
                Titulo = context.GetRouteValue("titulo").ToString(),
                Autor = (string)context.GetRouteValue("autor")
            };
            var repo = new LivroRepositorioCSV();

            repo.Incluir(livro);

            return context.Response.WriteAsync("O Livro foi Adicionado com sucesso");
        }
    }
}
