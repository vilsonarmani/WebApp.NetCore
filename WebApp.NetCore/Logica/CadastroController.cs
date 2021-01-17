﻿using Alura.ListaLeitura.App.HTML;
using Alura.ListaLeitura.App.Negocio;
using Alura.ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Alura.ListaLeitura.App.Logica
{
    public class CadastroController
    {
         public static Task ExibeFormulario(HttpContext context)
        {
            var html = HTMLUtils.CarregaArquivoHTML("formulario");
            return context.Response.WriteAsync(html);
        }

        public string Incluir(Livro livro)
        {
           
            var repo = new LivroRepositorioCSV();

            repo.Incluir(livro);

            return "O Livro foi Adicionado com sucesso";
        }
    }
}
