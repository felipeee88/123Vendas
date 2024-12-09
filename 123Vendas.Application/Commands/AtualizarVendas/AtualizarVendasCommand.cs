using _123Vendas.Domain.Entidades;
using MediatR;

namespace _123Vendas.Application.Commands.AtualizarVenda
{
    public class AtualizarVendasCommand : IRequest<bool>
    {
        public Venda Venda { get; set; }

        public AtualizarVendasCommand(Venda venda)
        {
            Venda = venda;
        }
    }
}
