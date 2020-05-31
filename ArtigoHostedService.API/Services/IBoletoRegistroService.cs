using ArtigoHostedService.API.Entities;
using System.Threading.Tasks;

namespace ArtigoHostedService.API.Services
{
    public interface IBoletoRegistroService
    {
        bool Registrar(Boleto boleto);
    }
}
