using _123Vendas.Domain.Entidades;
using MediatR;

namespace _123Vendas.Application.Queries
{
    public class ObterVendasPorIdQuery : IRequest<Venda>
    {
        public int VendaId { get; set; }

        public ObterVendasPorIdQuery(int vendaId)
        {
            VendaId = vendaId;
        }
    }
}
