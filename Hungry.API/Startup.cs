using Hungry.Application.UseCases;
using Hungry.Domain.Interfaces;
using Hungry.Infra.Repositories;

namespace Hungry.API
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // Use Cases
            services.AddScoped<CriarPedidoUseCase>();
            services.AddScoped<AdicionarItemPedidoUseCase>();
            services.AddScoped<FinalizarPedidoUseCase>();
            services.AddScoped<ObterPedidoUseCase>();
            services.AddScoped<PagarPedidoUseCase>();

            // Repositórios e Gateways - InMemory Fake
            services.AddSingleton<IPedidoRepository, PedidoRepositoryFake>();
            services.AddSingleton<IPagamentoGateway, PagamentoGatewayFake>();

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
