using _123Vendas.Domain.Entidades;
using _123Vendas.Domain.Interface.Service;
using MediatR;

namespace _123Vendas.Application.Commands.CriarVenda
{
    public class CriarVendasCommandHandler : IRequestHandler<CriarVendasCommand, Venda>
    {
        private readonly IVendasService _vendaService;

        public CriarVendasCommandHandler(IVendasService vendaService)
        {
            _vendaService = vendaService;
        }

        public async Task<Venda> Handle(CriarVendasCommand request, CancellationToken cancellationToken)
        {
            return await _vendaService.CriarVendaAsync(request.Venda);
        }
    }
}
