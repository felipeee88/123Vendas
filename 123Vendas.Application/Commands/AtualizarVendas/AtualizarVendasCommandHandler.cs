using _123Vendas.Domain.Interface.Service;
using MediatR;

namespace _123Vendas.Application.Commands.AtualizarVenda
{
    public class AtualizarVendasCommandHandler : IRequestHandler<AtualizarVendasCommand, bool>
    {
        private readonly IVendasService _vendaService;

        public AtualizarVendasCommandHandler(IVendasService vendaService)
        {
            _vendaService = vendaService;
        }

        public async Task<bool> Handle(AtualizarVendasCommand request, CancellationToken cancellationToken)
        {
            return await _vendaService.AtualizarVendaAsync(request.Venda);
        }
    }
}
