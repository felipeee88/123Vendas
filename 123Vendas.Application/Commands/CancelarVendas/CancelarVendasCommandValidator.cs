using FluentValidation;

namespace _123Vendas.Application.Commands.CancelarVenda
{
    public class CancelarVendasCommandValidator : AbstractValidator<CancelarVendasCommand>
    {
        public CancelarVendasCommandValidator()
        {
            RuleFor(v => v.VendaId).GreaterThan(0).WithMessage("Venda Id obrigatório.");
        }
    }
}
