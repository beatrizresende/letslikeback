using LetsLike.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LetsLike.Configurations;
using Microsoft.AspNetCore.Http;
using System.Reflection;
using System.IO;
using System.Text.Json.Serialization;

namespace LetsLike
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // TODO - Setar o nosso contexto quando a aplica??o for ao ar 
            services.AddDbContext<LetsLikeContext>(
              options => options.
              UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // TODO adicionar o contexto ao escopo inicial - adicionando o contexto ao startup (tem que estar setado aqui sen?o ele n vai ach?-lo
            services.AddDbContext<LetsLikeContext>();

            //TODO indicando acessos ao HTTP Context para trabalhar com os retornos http
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // TODO setando o mapper da aplica??o para indicar que vamos trabalhar com Automapper
            services.AddAutoMapper(typeof(Startup));

            // TODO adicionando o json, para serializar as AMARRA??ES entre as entidades
            // relacionamentos de FK'S 
            services.AddControllers().AddJsonOptions(x =>
            x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Gerador de Like de Projetos", Version = "v1" });
                //configurando a adi??o de coment?rios XML:
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            // TODO adicionando a Invers?o de controle criada na Classe Factory
            RegisterServicesPrivate(services);

        }    

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger(); //configura??o do swagger
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "LetsLike v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        // TODO m?todo criado para instanciar a factory
        //gerando um m?todo RegisterServices privado pq n ? boa pr?tica chamar uma classe dentro de outra, principalmente dentro de um m?todo void
        private void RegisterServicesPrivate(IServiceCollection services)
        {
            Factory.RegisterServices(services);
        }

    }
}
