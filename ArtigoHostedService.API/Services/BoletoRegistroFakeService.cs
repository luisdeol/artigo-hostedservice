using ArtigoHostedService.API.Entities;

namespace ArtigoHostedService.API.Services
{
    public class BoletoRegistroFakeService : IBoletoRegistroService
    {
        public bool Registrar(Boleto boleto)
        {
            return true;
        }
    }
}
