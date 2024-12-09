using _123Vendas.Domain.Entidades;
using _123Vendas.Domain.Interface.Service;
using MediatR;

namespace _123Vendas.Application.Queries
{
    public class ObterVendasPorIdQueryHandler : IRequestHandler<ObterVendasPorIdQuery, Venda>
    {
        private readonly IVendasService _vendaService;

        public ObterVendasPorIdQueryHandler(IVendasService vendaService)
        {
            _vendaService = vendaService;
        }

        public async Task<Venda> Handle(ObterVendasPorIdQuery request, CancellationToken cancellationToken)
        {
            return await _vendaService.ObterVendaPorIdAsync(request.VendaId);
        }
    }
}
