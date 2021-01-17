using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace Alura.ListaLeitura.App
{
    public class Startup
    {
        /*INJETANDO O SERVIÇO DE ROTEAMENTO*/
        public void ConfigureServices(IServiceCollection services)
        {
            //injetando serviço de roteamento
            services.AddRouting();
        }

        /* MAPEAMENTO DAS ROTAS*/
        public void Configure(IApplicationBuilder app)
        {
            var builder = new RouteBuilder(app);
            //construindo as rotas
            builder.MapRoute("Livros/ParaLer", LivrosLogica.LivrosPraLer);
            builder.MapRoute("Livros/Lendo", LivrosLogica.LivrosLendo);
            builder.MapRoute("Livros/Lidos", LivrosLogica.LivrosLidos);
            builder.MapRoute("Cadastro/NovoLivro/{nome}/{autor}", CadastroLogica.NovoLivroPraLer);
            builder.MapRoute("Livros/Detalhes/{id:int}", LivrosLogica.ExibeDetalhes);
            builder.MapRoute("Cadastro/NovoLivro", CadastroLogica.ExibeFormulario);
            builder.MapRoute("Cadastro/Incluir", CadastroLogica.ProcessaFormulario);

            var rotas = builder.Build();

            app.UseRouter(rotas);

            //app.Run(Roteamento);
        }
        
/*
        public Task Roteamento(HttpContext context)
        { //roteamento rudimentar
            var _repo = new LivroRepositorioCSV();
            var caminhosAtendidos = new Dictionary<string, RequestDelegate>
            {
                { "/Livros/ParaLer", LivrosPraLer },
                { "/Livros/Lendo", LivrosLendo },
                { "/Livros/Lidos", LivrosLidos }
            };

            if (caminhosAtendidos.ContainsKey(context.Request.Path))
            {
                var metodo = caminhosAtendidos[context.Request.Path];
                return metodo.Invoke(context);
            }

            
            context.Response.StatusCode = 404;

            return context.Response.WriteAsync("Caminho inexistente!");

        }*/       
    }
}