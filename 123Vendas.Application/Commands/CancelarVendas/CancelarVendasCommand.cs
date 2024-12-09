using MediatR;

namespace _123Vendas.Application.Commands.CancelarVenda
{
    public class CancelarVendasCommand : IRequest<bool>
    {
        public int VendaId { get; set; }

        public CancelarVendasCommand(int vendaId)
        {
            VendaId = vendaId;
        }
    }
}
