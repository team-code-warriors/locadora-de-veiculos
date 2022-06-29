using FluentValidation;

namespace LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculos
{
    public class ValidadorGrupoDeVeiculos : AbstractValidator<GrupoDeVeiculos>
    {
        public ValidadorGrupoDeVeiculos()
        {
            RuleFor(x => x.Nome)
                .NotNull().NotEmpty().MinimumLength(2);
        }
    }
}
