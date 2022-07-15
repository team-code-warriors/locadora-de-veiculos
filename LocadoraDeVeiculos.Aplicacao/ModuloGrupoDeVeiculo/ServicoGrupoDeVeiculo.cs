using FluentResults;
using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculos;
using LocadoraDeVeiculos.Infra.BancoDeDados.ModuloGrupoDeVeiculos;
using Serilog;

namespace LocadoraDeVeiculos.Aplicacao.ModuloGrupoDeVeiculo
{
    public class ServicoGrupoDeVeiculo
    {
        private RepositorioGrupoDeVeiculosEmBancoDeDados repositorioDeGrupoVeiculos;

        public ServicoGrupoDeVeiculo(RepositorioGrupoDeVeiculosEmBancoDeDados repositorioGrupoVeiculos)
        {
            this.repositorioDeGrupoVeiculos = repositorioGrupoVeiculos;
        }

        public Result<GrupoDeVeiculos> Inserir(GrupoDeVeiculos grupo)
        {
            Log.Logger.Debug("Tentando inserir grupo... {@g}", grupo);

            Result resultadoValidacao = ValidarGrupo(grupo);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir o grupo de veículos {GrupoId} - {Motivo}",
                        grupo.Id, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioDeGrupoVeiculos.Inserir(grupo);

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
                    Log.Logger.Warning("Falha ao tentar editar o Grupo {GrupoId} - {Motivo}",
                        grupo.Id, erro.Message);
                }
            }
            return Result.Fail(resultadoValidacao.Errors);

            try
            {
                repositorioDeGrupoVeiculos.Excluir(grupo);

                Log.Logger.Information("Grupo {GrupoId} editado com sucesso", grupo.Id);

                return Result.Ok(grupo);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar editaro o grupo";

                Log.Logger.Error(ex, msgErro + "{GrupoId}", grupo.Id);

                return Result.Fail(msgErro);
            }
        }
        public Result Excluir(GrupoDeVeiculos grupo)
        {
            Log.Logger.Debug("Tentando excluir grupo... {@t}", grupo);

            try
            {
                repositorioDeGrupoVeiculos.Excluir(grupo);

                Log.Logger.Information("Grupo {GrupoId} excluído com sucesso", grupo.Id);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar excluir o grupo";

                Log.Logger.Error(ex, msgErro, "{GrupoId}", grupo.Id);

                return Result.Fail(msgErro);
            }
        }
        public Result<List<GrupoDeVeiculos>> SelecionarTodos()
        {
            try
            {
                return Result.Ok(repositorioDeGrupoVeiculos.SelecionarTodos());
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
                return Result.Ok(repositorioDeGrupoVeiculos.SelecionarPorId(id));
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
            var grupoEncontrado = repositorioDeGrupoVeiculos.SelecionarGrupoPorNome(grupo.Nome);

            return grupoEncontrado != null &&
                   grupoEncontrado.Nome == grupo.Nome &&
                   grupoEncontrado.Id != grupo.Id;
        }
    }
}
