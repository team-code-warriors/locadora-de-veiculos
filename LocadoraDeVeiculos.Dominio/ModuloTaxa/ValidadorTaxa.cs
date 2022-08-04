using FluentValidation;

namespace LocadoraDeVeiculos.Dominio.ModuloTaxa
{
    public class ValidadorTaxa : AbstractValidator<Taxa>
    {
        public ValidadorTaxa()
        {
            RuleFor(x => x.Descricao)
                .NotNull().NotEmpty().MinimumLength(2);

            RuleFor(x => x.Valor)
                .NotNull().NotEmpty().GreaterThan(0);

            RuleFor(x => x.TipoCalculo)
                .NotNull().NotEmpty();
        }
    }
}
