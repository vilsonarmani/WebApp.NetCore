using Alura.ListaLeitura.App.Negocio;
using Alura.ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace Alura.ListaLeitura.App.Logica
{
    public class CadastroController : Controller
    {

        public string Incluir(Livro livro)
        {
            var repo = new LivroRepositorioCSV();
            repo.Incluir(livro);
            return "O livro foi adicionado com sucesso";
        }

        public IActionResult ExibeFormulario()
        {
            //var html = HtmlUtils.CarregaArquivoHTML("formulario");
            //var html = new ViewResult { ViewName = "formulario" };

            return View("formulario");
        }
    }
}
