using FluentValidation;

namespace _123Vendas.Application.Commands.CriarVenda
{
    public class CriarVendasCommandValidator : AbstractValidator<CriarVendasCommand>
    {
        public CriarVendasCommandValidator()
        {
            RuleFor(v => v.Venda.ClienteId).NotEmpty().WithMessage("Cliente ID é obrigatório");
            RuleFor(v => v.Venda.Itens).NotEmpty().WithMessage("A venda deve conter pelo menos 1 item.");
        }
    }
}
