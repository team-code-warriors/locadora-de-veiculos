using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Infra.BancoDeDados.ModuloCondutor;
using Serilog;
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
            Log.Logger.Debug("Tentando inserir condutor... {@c}", condutor);

            var resultadoValidacao = Validar(condutor);

            if (resultadoValidacao.IsValid)
            {
                repositorioCondutor.Inserir(condutor);
                Log.Logger.Debug("Condutor {CondutorNome} inserido com sucesso", condutor.Nome);
            }
            else
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir um Condutor {CondutorNome} - {Motivo}",
                        condutor.Nome, erro.ErrorMessage);
                }
            }

            return resultadoValidacao;
        }

        public ValidationResult Editar(Condutor condutor)
        {
            Log.Logger.Debug("Tentando editar condutor... {@c}", condutor);

            var resultadoValidacao = Validar(condutor);

            if (resultadoValidacao.IsValid)
            {
                repositorioCondutor.Editar(condutor);
                Log.Logger.Debug("Condutor {CondutorNome} editado com sucesso", condutor.Nome);
            }else
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar um Condutor {CondutorNome} - {Motivo}",
                        condutor.Nome, erro.ErrorMessage);
                }
            }

            return resultadoValidacao;
        }

        private ValidationResult Validar(Condutor condutor)
        {
            ValidadorCondutor validador = new ValidadorCondutor();

            var resultadoValidacao = validador.Validate(condutor);

            if(resultadoValidacao.IsValid)
                if (ClienteDuplicado(condutor) && CpfDuplicado(condutor))
                    resultadoValidacao.Errors.Add(new ValidationFailure("Condutor", "Este Condutor já esta cadastrado para este Cliente"));

            return resultadoValidacao;
        }

        private bool ClienteDuplicado(Condutor condutor)
        {
            var condutorEncontrado = repositorioCondutor.SelecionarCondutorPorCliente(condutor.Cliente.Id);

            return condutorEncontrado != null &&
                   condutorEncontrado.Cliente.Id == condutor.Cliente.Id &&
                   condutorEncontrado.Id != condutor.Id;
        }
        private bool CpfDuplicado(Condutor condutor)
        {
            var condutorEncontrado = repositorioCondutor.SelecionarCondutorPorCpf(condutor.Cpf);

            return condutorEncontrado != null &&
                   condutorEncontrado.Cpf == condutor.Cpf &&
                   condutorEncontrado.Id != condutor.Id;
        }

    }
}
