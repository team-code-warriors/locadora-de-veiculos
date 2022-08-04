using FluentValidation;

namespace LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca
{
    public class ValidadorPlanoDeCobranca : AbstractValidator<PlanoDeCobranca>
    {
        public ValidadorPlanoDeCobranca()
        {
            RuleFor(x => x.GrupoVeiculo)
                .NotNull().NotEmpty();

            RuleFor(x => x.TipoPlano)
               .NotNull().NotEmpty();

            RuleFor(x => x.ValorDiaria)
                .NotNull().NotEmpty().GreaterThan(0);

            RuleFor(x => x.KmIncluso)
                .GreaterThanOrEqualTo(0);

            RuleFor(x => x.PrecoKm)
                .GreaterThanOrEqualTo(0);
        }
    }
}
