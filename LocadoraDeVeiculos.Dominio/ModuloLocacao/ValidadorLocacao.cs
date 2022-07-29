﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloLocacao
{
    public class ValidadorLocacao : AbstractValidator<Locacao>
    {
        public ValidadorLocacao()
        {
            RuleFor(x => x.Funcionario)
                .NotNull().NotEmpty();

            RuleFor(x => x.Condutor)
                .NotNull().NotEmpty();

            RuleFor(x => x.Veiculo)
                .NotNull().NotEmpty();

            RuleFor(x => x.Plano)
                .NotNull().NotEmpty();

            RuleFor(x => x.KmCarro)
                .NotNull().NotEmpty().GreaterThanOrEqualTo(0);

            RuleFor(x => x.Valor)
                .NotNull().NotEmpty().GreaterThan(0);

            RuleFor(x => x.Status)
                .NotNull().NotEmpty();
        }
    }
}
