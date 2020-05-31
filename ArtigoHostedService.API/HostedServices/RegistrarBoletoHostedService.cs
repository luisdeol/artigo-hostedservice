using ArtigoHostedService.API.Persistence;
using ArtigoHostedService.API.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ArtigoHostedService.API.HostedServices
{
    public class RegistrarBoletoHostedService : IHostedService, IDisposable
    {
        private Timer _timer;

        public IServiceProvider ServiceProvider { get; set; }

        public RegistrarBoletoHostedService(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(Registrar, null, 0, 100000);

            return Task.CompletedTask;
        }

        private void Registrar(object state)
        {
            using (var scope = ServiceProvider.CreateScope())
            {
                var boletoRepository = scope.ServiceProvider.GetRequiredService<IBoletoRepository>();
                var boletoRegistroService = scope.ServiceProvider.GetRequiredService<IBoletoRegistroService>();

                var boletos = boletoRepository.ObterBoletosNaoRegistrados();

                foreach (var boleto in boletos)
                {
                    boletoRegistroService.Registrar(boleto);

                    boleto.MarcarComoRegistrado();

                    boletoRepository.Salvar();
                }
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer.Dispose();
        }
    }
}
