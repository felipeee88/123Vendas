using _123Vendas.Domain.Interface.Service;
using MediatR;

namespace _123Vendas.Application.Commands.CancelarVenda
{
    public class CancelarVendasCommandHandler : IRequestHandler<CancelarVendasCommand, bool>
    {
        private readonly IVendasService _vendaService;

        public CancelarVendasCommandHandler(IVendasService vendaService)
        {
            _vendaService = vendaService;
        }

        public async Task<bool> Handle(CancelarVendasCommand request, CancellationToken cancellationToken)
        {
            return await _vendaService.CancelarVendaAsync(request.VendaId);
        }
    }
}
