using _123Vendas.Domain.Entidades;
using _123Vendas.Domain.Interface.Service;
using MediatR;

namespace _123Vendas.Application.Queries
{
    public class ListarTodasVendasQueryHandler : IRequestHandler<ListarTodasVendasQuery, IEnumerable<Venda>>
    {
        private readonly IVendasService _vendaService;

        public ListarTodasVendasQueryHandler(IVendasService vendaService)
        {
            _vendaService = vendaService;
        }

        public async Task<IEnumerable<Venda>> Handle(ListarTodasVendasQuery request, CancellationToken cancellationToken)
        {
            return await _vendaService.ListarTodasVendasAsync();
        }
    }
}
