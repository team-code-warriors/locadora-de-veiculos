using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloCondutor
{
    public class ValidadorCondutor : AbstractValidator<Condutor>
    {
        public ValidadorCondutor()
        {
            RuleFor(x => x.Cnh)
                .NotNull().
                NotEmpty().
                Length(11).WithMessage("'CNH' deve ter 11 caracteres.");

            RuleFor(x => x.DataValidadeCnh)
                .NotNull().NotEmpty();
        }
    }
}
