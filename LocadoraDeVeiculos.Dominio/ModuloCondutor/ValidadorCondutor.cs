﻿using FluentValidation;
using FluentValidation.Validators;
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
            RuleFor(x => x.Cliente)
                .NotNull().NotEmpty();

            RuleFor(x => x.Nome)
                .NotNull().NotEmpty().MinimumLength(2);

            RuleFor(x => x.Cpf)
                .NotNull()
                .Length(14).WithMessage("'CPF' deve ter 14 caracteres.");

            RuleFor(x => x.Cnh)
                .NotNull().
                NotEmpty().
                Length(11).WithMessage("'CNH' deve ter 11 caracteres.");

            RuleFor(x => x.Email)
                .EmailAddress(EmailValidationMode.AspNetCoreCompatible)
                .NotNull().NotEmpty().MinimumLength(5);

            RuleFor(x => x.Telefone)
                .NotNull().
                NotEmpty().
                Length(15).WithMessage("'Telefone' deve ter 15 caracteres.");

            RuleFor(x => x.Endereco)
                .NotNull().NotEmpty().MinimumLength(2);
        }
    }
}
