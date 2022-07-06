using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloFuncionario
{
    public class ValidadorFuncionario : AbstractValidator<Funcionario>
    {
        public ValidadorFuncionario()
        {
            RuleFor(x => x.Nome)
                .NotNull().NotEmpty().MinimumLength(2).Matches(new Regex (@"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ ]*$"));

            RuleFor(x => x.Salario)
                .NotNull().NotEmpty().GreaterThan(0);

            RuleFor(x => x.DataAdmissao)
                .NotNull().NotEmpty();

            RuleFor(x => x.Login)
                .NotNull().NotEmpty().MinimumLength(3);

            RuleFor(x => x.Senha)
                .NotNull().NotEmpty().MinimumLength(3);

            RuleFor(x => x.TipoPerfil)
                .NotNull().NotEmpty();
        }
    }
}
