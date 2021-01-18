using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;


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
        //  public void Configure(IApplicationBuilder app)
        //  {
        /////não utilizar em produção pois exibe o stack trace
        //      app.UseDeveloperExceptionPage();
        //      app.UseMvcWithDefaultRoute();
        //  }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {

                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            //app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{Controller=Home}/{action=Index}/{id?}"); 
            });

        }


    }
}