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
                .NotNull().NotEmpty().MinimumLength(2);

            RuleFor(x => x.Email)
                .EmailAddress(EmailValidationMode.AspNetCoreCompatible)
                .NotNull().NotEmpty().MinimumLength(5);

            RuleFor(x => x.Endereco)
                .NotNull().NotEmpty().MinimumLength(2);

            RuleFor(x => x.Cpf)
                .NotNull()
                .NotEmpty()
                .Length(14).WithMessage("'CPF' deve ter 14 caracteres.");

            RuleFor(x => x.Telefone)
                .NotNull().
                NotEmpty().
                Length(15).WithMessage("'Telefone' deve ter 15 caracteres.");

            RuleFor(x => x.Cnh)
                .NotNull().
                NotEmpty().
                Length(10).WithMessage("'CNH' deve ter 10 caracteres.");
        }
    }
}