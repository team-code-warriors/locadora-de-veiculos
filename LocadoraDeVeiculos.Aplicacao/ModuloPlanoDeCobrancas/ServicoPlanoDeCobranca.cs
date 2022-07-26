using FluentResults;
using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.Infra.BancoDeDados.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.Infra.Orm.ModuloPlanoDeCobranca;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Aplicacao.ModuloPlanoDeCobrancas
{
    public class ServicoPlanoDeCobranca
    {
        private RepositorioPlanoDeCobrancaOrm repositorioPlano;
        private IContextoPersistencia contextoPersistencia;

        public ServicoPlanoDeCobranca(RepositorioPlanoDeCobrancaOrm repositorioPlano, IContextoPersistencia contextoPersistencia)
        {
            this.repositorioPlano = repositorioPlano;
            this.contextoPersistencia = contextoPersistencia;
        }

        public Result<PlanoDeCobranca> Inserir(PlanoDeCobranca plano)
        {
            Log.Logger.Debug("Tentando inserir plano... {@p}", plano);

            Result resultadoValidacao = ValidarPlano(plano);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir o plano {PlanoId} - {Motivo}",
                       plano.Id, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioPlano.Inserir(plano);
                contextoPersistencia.GravarDados();

                Log.Logger.Information("Plano {PlanoId} inserido com sucesso", plano.Id);

                return Result.Ok(plano);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar inserir o plano";

                Log.Logger.Error(ex, msgErro + "{PlanoId}", plano.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<PlanoDeCobranca> Editar(PlanoDeCobranca plano)
        {
            Log.Logger.Debug("Tentando editar plano... {@p}", plano);

            Result resultadoValidacao = ValidarPlano(plano);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar o Plano {PlanoId} - {Motivo}",
                       plano.Id, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioPlano.Editar(plano);
                contextoPersistencia.GravarDados();

                Log.Logger.Information("Plano {PlanoId} editado com sucesso", plano.Id);

                return Result.Ok(plano);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar editar o plano";

                Log.Logger.Error(ex, msgErro + "{PlanoId}", plano.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result Excluir(PlanoDeCobranca plano)
        {
            Log.Logger.Debug("Tentando excluir plano... {@p}", plano);

            try
            {
                repositorioPlano.Excluir(plano);
                contextoPersistencia.GravarDados();

                Log.Logger.Information("Plano {PlanoId} excluído com sucesso", plano.Id);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar excluir o plano";

                Log.Logger.Error(ex, msgErro + "{PlanoId}", plano.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<List<PlanoDeCobranca>> SelecionarTodos()
        {
            try
            {
                return Result.Ok(repositorioPlano.SelecionarTodos());
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar todos os planos";

                Log.Logger.Error(ex, msgErro);

                return Result.Fail(msgErro);
            }
        }

        public Result<PlanoDeCobranca> SelecionarPorId(Guid id)
        {
            try
            {
                return Result.Ok(repositorioPlano.SelecionarPorId(id));
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar o plano";

                Log.Logger.Error(ex, msgErro + "{PlanoId}", id);

                return Result.Fail(msgErro);
            }
        }

        private Result ValidarPlano(PlanoDeCobranca plano)
        {
            var validador = new ValidadorPlanoDeCobranca();

            var resultadoValidacao = validador.Validate(plano);

            List<Error> erros = new List<Error>(); //FluentResult

            foreach (ValidationFailure item in resultadoValidacao.Errors) //FluentValidation            
                erros.Add(new Error(item.ErrorMessage));

            Result<bool> validaGrupoETipoPlano = GrupoDuplicado(plano).Value && TipoPlanoDuplicado(plano).Value;

            if (validaGrupoETipoPlano.IsSuccess)
            {
                if (validaGrupoETipoPlano.Value == true)
                {
                    erros.Add(new Error("Grupo já cadastrado com o Plano selecionado"));
                }
            }
            else
            {
                erros.Add(new Error(validaGrupoETipoPlano.Errors[0].Message));
            }

            if (erros.Any())
                return Result.Fail(erros);

            return Result.Ok();
        }

        private Result<bool> GrupoDuplicado(PlanoDeCobranca plano)
        {
            try
            {
                var planoEncontrado = repositorioPlano.SelecionarPlanoPorGrupo(plano.GrupoVeiculo.Id);

                bool resultadoValidacao = planoEncontrado != null &&
                       planoEncontrado.GrupoVeiculo.Id == plano.GrupoVeiculo.Id &&
                       planoEncontrado.Id != plano.Id;

                return Result.Ok(resultadoValidacao);
            }
            catch (NaoPodeInserirEsteRegistroException ex)
            {
                string msgErro = "Falha no sistema ao tentar validar o Grupo do plano";

                Log.Logger.Error(ex, msgErro + "{PlanoId}", plano.Id);

                return Result.Fail(msgErro);
            }
        }

        private Result<bool> TipoPlanoDuplicado(PlanoDeCobranca plano)
        {
            try
            {
                var planoEncontrado = repositorioPlano.SelecionarPlanoPorTipoPlano(plano.TipoPlano);

                bool resultadoValidacao = planoEncontrado != null &&
                       planoEncontrado.TipoPlano == plano.TipoPlano &&
                       planoEncontrado.Id != plano.Id;

                return Result.Ok(resultadoValidacao);
            }
            catch (NaoPodeInserirEsteRegistroException ex)
            {
                string msgErro = "Falha no sistema ao tentar validar o Grupo do plano";

                Log.Logger.Error(ex, msgErro + "{PlanoId}", plano.Id);

                return Result.Fail(msgErro);
            }
        }

    }
}
