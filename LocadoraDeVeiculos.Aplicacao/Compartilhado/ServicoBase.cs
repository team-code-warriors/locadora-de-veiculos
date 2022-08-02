using FluentValidation;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Aplicacao.Compartilhado
{
    public class ServicoBase<T, TValidador>
        where T : EntidadeBase<T>
        where TValidador : AbstractValidator<T>
    {
    }
}
