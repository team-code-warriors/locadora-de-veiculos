using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                .GreaterThan(0);
        }
    }
}
