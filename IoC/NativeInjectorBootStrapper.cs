using ConversorDeMoeda.Interfaces;
using ConversorDeMoeda.Services;
using Data;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {

            // domain
            services.AddScoped<IConversorMoeda, ConversorMoeda>();

            //repository
            services.AddSingleton<IMoedaRepository, MoedaRepository>();

        }
    }
}
