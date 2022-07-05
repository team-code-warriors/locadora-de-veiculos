using FluentValidation;

namespace LocadoraDeVeiculos.Dominio.ModuloVeiculo
{
    public class ValidadorVeiculo : AbstractValidator<Veiculo>
    {
        public ValidadorVeiculo()
        {
            RuleFor(x => x.Modelo)
                .NotNull().NotEmpty().MinimumLength(2);

            RuleFor(x => x.Fabricante)
                .NotNull().NotEmpty().MinimumLength(2);

            RuleFor(x => x.Ano)
                .NotNull().NotEmpty();

            RuleFor(x => x.Cambio)
                .NotNull().NotEmpty();

            RuleFor(x => x.Cor)
                .NotNull().NotEmpty().MinimumLength(2);

            RuleFor(x => x.Placa)
                .NotNull().NotEmpty().Length(7);

            RuleFor(x => x.Kilometragem)
                .NotNull().NotEmpty().GreaterThan(0);

            RuleFor(x => x.TipoDeCombustivel)
                .NotNull().NotEmpty();

            RuleFor(x => x.CapacidadeDoTanque)
                .NotNull().NotEmpty().GreaterThan(0);

            RuleFor(x => x.GrupoDeVeiculos)
                .NotNull().NotEmpty();
        }
    }
}
