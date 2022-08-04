using FluentValidation;
using FluentValidation.Validators;
using System.Text.RegularExpressions;

namespace LocadoraDeVeiculos.Dominio.ModuloCliente
{
    public class ValidadorCliente : AbstractValidator<Cliente>
    {
        public ValidadorCliente()
        {
            RuleFor(x => x.Nome)
                .NotNull().NotEmpty().MinimumLength(2).Matches(new Regex (@"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ ]*$"));

            RuleFor(x => x.Email)
                .EmailAddress(EmailValidationMode.AspNetCoreCompatible)
                .NotNull().NotEmpty().MinimumLength(5);

            RuleFor(x => x.Endereco)
                .NotNull().NotEmpty().MinimumLength(2);

            RuleFor(x => x.Cpf)
                .NotNull()
                .Length(14).WithMessage("'CPF' deve ter 14 caracteres.");

            RuleFor(x => x.Cnpj)
                .NotNull()
                .Length(18).WithMessage("'CNPJ' deve ter 18 caracteres.");

            RuleFor(x => x.Telefone)
                .NotNull().
                NotEmpty().
                Length(15).WithMessage("'Telefone' deve ter 15 caracteres.");
        }
    }
}