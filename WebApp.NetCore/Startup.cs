using Microsoft.AspNetCore.Builder;
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
            services.AddMvc();//adicionar o MVC
        }

        /* MAPEAMENTO DAS ROTAS*/
        public void Configure(IApplicationBuilder app)
        {
            app.UseMvcWithDefaultRoute();
        }
    
    }
}