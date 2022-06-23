using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloCliente
{
    public class ValidadorCliente : AbstractValidator<Cliente>
    {
        public ValidadorCliente()
        {
            RuleFor(x => x.Nome)
                .NotNull().NotEmpty();

            RuleFor(x => x.Email)
                .EmailAddress(EmailValidationMode.AspNetCoreCompatible)
                .NotNull().NotEmpty();

            RuleFor(x => x.Cpf)
                .NotNull().NotEmpty();

            RuleFor(x => x.Telefone)
                .NotNull().NotEmpty();

            RuleFor(x => x.Cnh)
                .NotNull().NotEmpty();
        }
    }
}