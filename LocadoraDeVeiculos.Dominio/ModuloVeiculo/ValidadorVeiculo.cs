using FluentValidation;

namespace LocadoraDeVeiculos.Dominio.ModuloVeiculo
{
    public class ValidadorVeiculo : AbstractValidator<Veiculo>
    {
        public ValidadorVeiculo()
        {
            RuleFor(x => x.Modelo)
                .Null().NotEmpty().MinimumLength(2);

            RuleFor(x => x.Fabricante)
                .Null().NotEmpty().MinimumLength(2);

            RuleFor(x => x.Ano)
                .Null().NotEmpty().MinimumLength(3);

            RuleFor(x => x.Cor)
                .Null().NotEmpty().MinimumLength(3);

            RuleFor(x => x.Placa)
                .Null().NotEmpty().MinimumLength(7);

            RuleFor(x => x.Kilometragem)
                .Null().NotEmpty();

            RuleFor(x => x.CapacidadeDoTanque)
                .Null().NotEmpty();
        }
    }
}
