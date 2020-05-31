using ArtigoHostedService.API.Entities;
using System.Collections.Generic;

namespace ArtigoHostedService.API.Persistence
{
    public interface IBoletoRepository
    {
        List<Boleto> ObterBoletosNaoRegistrados();
        void Salvar();
    }
}
