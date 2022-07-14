﻿using FluentResults;
using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.Compartilhado;
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

        public Result<Condutor> Inserir(Condutor condutor)
        {
            Log.Logger.Debug("Tentando inserir cliente... {@c}", condutor);

            Result resultadoValidacao = ValidarCondutor(condutor);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir o cliente {ClienteId} - {Motivo}",
                       condutor.Id, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioCondutor.Inserir(condutor);

                Log.Logger.Information("Cliente {ClienteId} inserido com sucesso", condutor.Id);

                return Result.Ok(condutor);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar inserir o cliente";

                Log.Logger.Error(ex, msgErro + "{ClienteId}", condutor.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<Condutor> Editar(Condutor condutor)
        {
            Log.Logger.Debug("Tentando editar cliente... {@c}", condutor);

            Result resultadoValidacao = ValidarCondutor(condutor);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar o Cliente {ClienteId} - {Motivo}",
                       condutor.Id, erro.Message);
                }
                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioCondutor.Editar(condutor);

                Log.Logger.Information("Cliente {ClienteId} editado com sucesso", condutor.Id);

                return Result.Ok(condutor);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar editar o cliente";

                Log.Logger.Error(ex, msgErro + "{ClienteId}", condutor.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result Excluir(Condutor condutor)
        {
            Log.Logger.Debug("Tentando excluir condutor... {@c}", condutor);

            try
            {
                repositorioCondutor.Excluir(condutor);

                Log.Logger.Information("Condutor {CondutorId} excluído com sucesso", condutor.Id);

                return Result.Ok();
            }
            catch (NaoPodeExcluirEsteRegistroException ex)
            {
                string msgErro = $"O condutor {condutor.Nome} está relacionado com um condutor e não pode ser excluídol";

                Log.Logger.Error(ex, msgErro + "{CondutorId}", condutor.Id);

                return Result.Fail(msgErro);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar excluir o condutor";

                Log.Logger.Error(ex, msgErro + "{CondutorId}", condutor.Id);

                return Result.Fail(msgErro);
            }
        }

        private Result ValidarCondutor(Condutor condutor)
        {
            ValidadorCondutor validador = new ValidadorCondutor();

            var resultadoValidacao = validador.Validate(condutor);

            List<Error> errors = new List<Error>();

            foreach (ValidationFailure r in resultadoValidacao.Errors)
            {
                errors.Add(new Error(r.ErrorMessage));
            }

            if (resultadoValidacao.IsValid)
            {
                if (condutor.Cpf != "              ")
                    if (CpfDuplicado(condutor))
                        errors.Add(new Error("CPF já cadastrado"));
            }

            if (errors.Any())
            {
                return Result.Fail(errors);
            }

            return Result.Ok();
        }

        public Result<List<Condutor>> SelecionarTodos()
        {
            try
            {
                return Result.Ok(repositorioCondutor.SelecionarTodos());
            }
            catch (Exception e)
            {
                string msgErro = "Falha no sistema ao tentar selecionar todos os condutores";

                Log.Logger.Error(e, msgErro);

                return Result.Fail(msgErro);
            }
        }

        public Result<Condutor> SelecionarPorId(Guid id)
        {
            try
            {
                return Result.Ok(repositorioCondutor.SelecionarPorId(id));
            }
            catch (Exception e)
            {
                string msgErro = "Falha no sistema ao tentar selecionar o condutor";

                Log.Logger.Error(e, msgErro + "{CondutorId}", id);

                return Result.Fail(msgErro);
            }
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
