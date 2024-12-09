using _123Vendas.Domain.Entidades;
using _123Vendas.Domain.Interface.Service;
using MediatR;

namespace _123Vendas.Application.Queries
{
    public class ListarVendasPorClienteIdQueryHandler : IRequestHandler<ListarVendasPorClienteIdQuery, IEnumerable<Venda>>
    {
        private readonly IVendasService _vendaService;

        public ListarVendasPorClienteIdQueryHandler(IVendasService vendaService)
        {
            _vendaService = vendaService;
        }

        public async Task<IEnumerable<Venda>> Handle(ListarVendasPorClienteIdQuery request, CancellationToken cancellationToken)
        {
            return await _vendaService.ListarVendasPorClienteIdAsync(request.ClienteId);
        }
    }
}
