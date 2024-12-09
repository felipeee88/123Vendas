using FluentValidation;

namespace _123Vendas.Application.Commands.AtualizarVenda
{
    public class AtualizarVendasCommandValidator : AbstractValidator<AtualizarVendasCommand>
    {
        public AtualizarVendasCommandValidator()
        {
            RuleFor(v => v.Venda.Id).GreaterThan(0).WithMessage("Venda Id obrigatório.");
        }
    }
}
