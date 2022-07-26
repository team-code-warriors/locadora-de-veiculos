using FluentResults;
using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculos;
using LocadoraDeVeiculos.Infra.BancoDeDados.ModuloGrupoDeVeiculos;
using LocadoraDeVeiculos.Infra.Orm.ModuloGrupoDeVeiculo;
using Serilog;

namespace LocadoraDeVeiculos.Aplicacao.ModuloGrupoDeVeiculo
{
    public class ServicoGrupoDeVeiculo
    {
        private RepositorioGrupoDeVeiculoOrm repositorioGrupo;
        private IContextoPersistencia contextoPersistencia;

        public ServicoGrupoDeVeiculo(RepositorioGrupoDeVeiculoOrm repositorioGrupoVeiculos, IContextoPersistencia contextoPersistencia)
        {
            this.repositorioGrupo = repositorioGrupoVeiculos;
            this.contextoPersistencia = contextoPersistencia;
        }

        public Result<GrupoDeVeiculos> Inserir(GrupoDeVeiculos grupo)
        {
            Log.Logger.Debug("Tentando inserir grupo... {@g}", grupo);

            Result resultadoValidacao = ValidarGrupo(grupo);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir o grupo {GrupoId} - {Motivo}",
                        grupo.Id, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioGrupo.Inserir(grupo);
                contextoPersistencia.GravarDados();

                Log.Logger.Information("Grupo {GrupoId} inserido com sucesso", grupo.Id);

                return Result.Ok(grupo);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar inserir o grupo";

                Log.Logger.Error(ex, msgErro + "{GrupoId}", grupo.Id);

                return Result.Fail(msgErro);
            }
        }
        public Result<GrupoDeVeiculos> Editar(GrupoDeVeiculos grupo)
        {
            Log.Logger.Debug("Tentando editar grupo... {@g}", grupo);

            Result resultadoValidacao = ValidarGrupo(grupo);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar o grupo {GrupoId} - {Motivo}",
                        grupo.Id, erro.Message);
                }
            }
            return Result.Fail(resultadoValidacao.Errors);

            try
            {
                repositorioGrupo.Editar(grupo);
                contextoPersistencia.GravarDados();

                Log.Logger.Information("Grupo {GrupoId} editado com sucesso", grupo.Id);

                return Result.Ok(grupo);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar editar o grupo";

                Log.Logger.Error(ex, msgErro + "{GrupoId}", grupo.Id);

                return Result.Fail(msgErro);
            }
        }
        public Result Excluir(GrupoDeVeiculos grupo)
        {
            Log.Logger.Debug("Tentando excluir grupo... {@g}", grupo);

            try
            {
                repositorioGrupo.Excluir(grupo);
                contextoPersistencia.GravarDados();

                Log.Logger.Information("Grupo {GrupoId} excluído com sucesso", grupo.Id);

                return Result.Ok();
            }
            catch (NaoPodeExcluirEsteRegistroException ex)
            {
                string msgErro = $"O grupo {grupo.Nome} está relacionado com um registro e não pode ser excluído";

                Log.Logger.Error(ex, msgErro + "{GrupoId}", grupo.Id);

                return Result.Fail(msgErro);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar excluir o grupo";

                Log.Logger.Error(ex, msgErro + "{GrupoId}", grupo.Id);

                return Result.Fail(msgErro);
            }
        }
        public Result<List<GrupoDeVeiculos>> SelecionarTodos()
        {
            try
            {
                return Result.Ok(repositorioGrupo.SelecionarTodos());
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar todos os grupos de veículos";

                Log.Logger.Error(ex, msgErro);

                return Result.Fail(msgErro);
            }
        }

        public Result<GrupoDeVeiculos> SelecionarPorId(Guid id)
        {
            try
            {
                return Result.Ok(repositorioGrupo.SelecionarPorId(id));
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar o grupo";

                Log.Logger.Error(ex, msgErro + "{GrupoId}", id);

                return Result.Fail(msgErro);
            }
        }

        private Result ValidarGrupo(GrupoDeVeiculos grupo)
        {
            var validador = new ValidadorGrupoDeVeiculos();

            var resultadoValidacao = validador.Validate(grupo);

            List<Error> erros = new List<Error>();

            foreach (ValidationFailure item in resultadoValidacao.Errors)
                erros.Add(new Error(item.ErrorMessage));

            if (NomeDuplicado(grupo))
                erros.Add(new Error("Nome duplicado"));

            if (erros.Any())
                return Result.Fail(erros);

            return Result.Ok();
        }

        private bool NomeDuplicado(GrupoDeVeiculos grupo)
        {
            var grupoEncontrado = repositorioGrupo.SelecionarGrupoPorNome(grupo.Nome);

            return grupoEncontrado != null &&
                   grupoEncontrado.Nome == grupo.Nome &&
                   grupoEncontrado.Id != grupo.Id;
        }
    }
}
