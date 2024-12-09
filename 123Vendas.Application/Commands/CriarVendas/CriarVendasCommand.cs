using _123Vendas.Domain.Entidades;
using MediatR;

namespace _123Vendas.Application.Commands.CriarVenda
{
    public class CriarVendasCommand : IRequest<Venda>
    {
        public Venda Venda { get; set; }

        public CriarVendasCommand(Venda venda)
        {
            Venda = venda;
        }
    }
}
