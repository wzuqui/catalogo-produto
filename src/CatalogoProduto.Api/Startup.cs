using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using CatalogoProduto.Api.Extensions;
using CatalogoProduto.Api.Filters;
using CatalogoProduto.Api.IoC;
using CatalogoProduto.Api.Produtos;
using CatalogoProduto.Infra;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace CatalogoProduto.Api
{
    public class Startup
    {
        public Startup(IConfiguration pConfiguration)
        {
            Configuration = pConfiguration;
        }

        [ExcludeFromCodeCoverage] private IConfiguration Configuration { get; }

        public void Configure(IApplicationBuilder pApp
            , IWebHostEnvironment pEnv)
        {
            if (pEnv.IsDevelopment())
                pApp.UseDeveloperExceptionPage();

            pApp.UseSwagger();
            pApp.UseSwaggerUI(p => p.SwaggerEndpoint("/swagger/v1/swagger.json", "Produto.Api v1"));
            pApp.UseRouting();
            pApp.UseEndpoints(p => p.MapControllers());
        }

        public void ConfigureServices(IServiceCollection pServices)
        {
            AdicionarDbContext(pServices);

            pServices
                .AddSwaggerGen(p => p.SwaggerDoc("v1", new OpenApiInfo { Title = "CatalogoProduto.Api", Version = "v1" }))
                .AdicionarIoC()
                .AddControllers(p => p.Filters.AddService<ModelStateFilter>())
                .AddFluentValidation(p => p.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()))
                ;
        }

        [ExcludeFromCodeCoverage]
        protected virtual void AdicionarDbContext(IServiceCollection pServices)
        {
            pServices.AddDbContext<CatalogoProdutoContext>(p => p.UsarSqlServer(Configuration));
        }
    }
}