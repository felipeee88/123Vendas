using _123Vendas.Domain.Entidades;
using MediatR;

namespace _123Vendas.Application.Queries
{
    public class ListarTodasVendasQuery : IRequest<IEnumerable<Venda>>
    {
    }
}
