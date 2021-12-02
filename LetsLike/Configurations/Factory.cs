using LetsLike.Interfaces;
using LetsLike.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetsLike.Configurations
{
    public class Factory
    {
        public static void RegisterServices(IServiceCollection services) //ao invés de fzr a config. dos serviços no startup, faço isolado na Factory
        {

            //setando a interface da service c/ a service
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IProjetoService, ProjetoService>();
            services.AddScoped<IUsuarioLikeProjetoService, UsuarioLikeProjetoService>();

        }
    }
}
