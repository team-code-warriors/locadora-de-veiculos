using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Infra.BancoDeDados.ModuloCondutor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Aplicacao.ModuloCondutor
{
    public class ServicoCondutor
    {
        private RepositorioCondutorEmBancoDeDados repositorioCondutor;

        public ServicoCondutor(RepositorioCondutorEmBancoDeDados repositorioCondutor)
        {
            this.repositorioCondutor = repositorioCondutor;
        }

        public ValidationResult Inserir(Condutor condutor)
        {
            var resultadoValidacao = ValidarCondutor(condutor);

            if (resultadoValidacao.IsValid)
                repositorioCondutor.Inserir(condutor);

            return resultadoValidacao;
        }

        public ValidationResult Editar(Condutor condutor)
        {
            var resultadoValidacao = ValidarCondutor(condutor);

            if (resultadoValidacao.IsValid)
                repositorioCondutor.Editar(condutor);

            return resultadoValidacao;
        }

        private ValidationResult ValidarCondutor(Condutor condutor)
        {
            ValidadorCondutor validador = new ValidadorCondutor();

            var resultadoValidacao = validador.Validate(condutor);

            if (CnhDuplicado(condutor))
                resultadoValidacao.Errors.Add(new ValidationFailure("CNH", "CNH já cadastrado"));

            return resultadoValidacao;
        }

        private bool CnhDuplicado(Condutor condutor)
        {
            var condutorEncontrado = repositorioCondutor.SelecionarCondutorPorCnh(condutor.Cnh);

            return condutorEncontrado != null &&
                   condutorEncontrado.Cnh == condutor.Cnh &&
                   condutorEncontrado.Id != condutor.Id;
        }
    }
}
