using _123Vendas.Domain.Entidades;
using MediatR;

namespace _123Vendas.Application.Queries
{
    public class ListarVendasPorClienteIdQuery : IRequest<IEnumerable<Venda>>
    {
        public string ClienteId { get; set; }

        public ListarVendasPorClienteIdQuery(string clienteId)
        {
            ClienteId = clienteId;
        }
    }
}
