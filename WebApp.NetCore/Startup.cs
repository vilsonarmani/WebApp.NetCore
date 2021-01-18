using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Alura.ListaLeitura.App
{
    public class Startup
    {
        /*INJETANDO O SERVIÇO DE ROTEAMENTO*/
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        /* MAPEAMENTO DAS ROTAS*/
        public void Configure(IApplicationBuilder app)
        {
		    ///não utilizar em produção pois exibe o stack trace
            app.UseDeveloperExceptionPage();
            app.UseMvcWithDefaultRoute();
        }
    
    }
}