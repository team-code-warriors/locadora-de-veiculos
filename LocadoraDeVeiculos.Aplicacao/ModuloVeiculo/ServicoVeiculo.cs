using FluentResults;
using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using LocadoraDeVeiculos.Infra.Orm.ModuloVeiculo;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace LocadoraDeVeiculos.Aplicacao.ModuloVeiculo
{
    public class ServicoVeiculo
    {
        private IRepositorioVeiculo repositorioVeiculo;
        private IContextoPersistencia contextoPersistencia;

        public ServicoVeiculo(IRepositorioVeiculo repositorioVeiculo1, IContextoPersistencia contextoPersistencia)
        {
            this.repositorioVeiculo = repositorioVeiculo1;
            this.contextoPersistencia = contextoPersistencia;
        }

        public Result<Veiculo> Inserir(Veiculo veiculo)
        {
            Log.Logger.Debug("Tentando inserir veículo... {@v}", veiculo);

            Result resultadoValidacao = ValidarVeiculo(veiculo);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir o veículo {VeiculoId} - {Motivo}",
                        veiculo.Id, erro.Message);
                }
                return Result.Fail(resultadoValidacao.Errors);
            }
            try
            {
                repositorioVeiculo.Inserir(veiculo);
                contextoPersistencia.GravarDados();

                Log.Logger.Information("Veículo {VeiculoId} inserido com sucesso", veiculo.Id);

                return Result.Ok(veiculo);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar inserir o veículo";

                Log.Logger.Error(ex, msgErro + "{VeiculoId}", veiculo.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<Veiculo> Editar(Veiculo veiculo)
        {
            Log.Logger.Debug("Tentando editar veículo... {@v}", veiculo);

            Result resultadoValidacao = ValidarVeiculo(veiculo);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar o veículo {VeiculoId} - {Motivo}",
                        veiculo.Id, erro.Message);
                }
                return Result.Fail(resultadoValidacao.Errors);
            }
            try
            {
                repositorioVeiculo.Editar(veiculo);
                contextoPersistencia.GravarDados();

                Log.Logger.Information("Veículo {VeiculoId} editado com sucesso", veiculo.Id);

                return Result.Ok(veiculo);
            }
            catch(Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar editar o veículo";

                Log.Logger.Error(ex, msgErro + "{VeiculoId}", veiculo.Id);

                return Result.Fail(msgErro);
            }
        }
        public Result Excluir(Veiculo veiculo)
        {
            Log.Logger.Debug("Tentando exlcuir veículo... {@f}", veiculo);

            try
            {
                repositorioVeiculo.Excluir(veiculo);
                contextoPersistencia.GravarDados();

                Log.Logger.Information("Veículo {VeiculoId} excluído com sucesso", veiculo.Id);

                return Result.Ok();
            }
            catch (DbUpdateException ex)
            {
                string msgErro = $"O veículo {veiculo.Id} está relacionado com outro registro e não pode ser excluído";

                contextoPersistencia.RollBack();

                Log.Logger.Error(ex, msgErro + "{VeiculoId}", veiculo.Id);

                return Result.Fail(msgErro);
            }
            catch (InvalidOperationException ex)
            {
                string msgErro = $"O veículo {veiculo.Id} está relacionado com outro registro e não pode ser excluído";

                contextoPersistencia.RollBack();

                Log.Logger.Error(ex, msgErro + "{VeiculoId}", veiculo.Id);

                return Result.Fail(msgErro);
            }
            catch (NaoPodeExcluirEsteRegistroException ex)
            {
                string msgErro = $"O veículo {veiculo.Modelo} está relacionado com um registro e não pode ser excluído";

                Log.Logger.Error(ex, msgErro + "{VeiculoId}", veiculo.Id);

                return Result.Fail(msgErro);
            }
            catch(Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar excluir o veículo";

                Log.Logger.Error(ex, msgErro + "{VeiculoID}", veiculo.Id);

                return Result.Fail(msgErro);
            }
        }
        public Result<List<Veiculo>> SelecionarTodos()
        {
            try
            {
                return Result.Ok(repositorioVeiculo.SelecionarTodos());
            }
            catch (Exception ex)
            {
                string msgErro  = "Falha no sistema ao tentar selecionar todos os veículos";

                Log.Logger.Error(ex, msgErro);

                return Result.Fail(msgErro);
            }
        }

        public Result<Veiculo> SelecionarPorId(Guid id)
        {
            try
            {
                return Result.Ok(repositorioVeiculo.SelecionarPorId(id));
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar o veículo";

                Log.Logger.Error(ex, msgErro + "{VeiculoId}", id);

                return Result.Fail(msgErro);
            }
        }

        private Result ValidarVeiculo(Veiculo veiculo)
        {
            ValidadorVeiculo validador = new ValidadorVeiculo();

            var resultadoValidacao = validador.Validate(veiculo);

            List<Error> erros = new List<Error>();

            foreach (ValidationFailure r in resultadoValidacao.Errors)
                erros.Add(new Error(r.ErrorMessage));

            if (PlacaDuplicada(veiculo))
                erros.Add(new Error("Placa duplicada"));

            if (erros.Any())
                return Result.Fail(erros);

            return Result.Ok();

        }

        private bool PlacaDuplicada(Veiculo veiculo)
        {
            var veiculoEncontrado = repositorioVeiculo.SelecionarVeiculoPorPlaca(veiculo.Placa);

            return veiculoEncontrado != null &&
                   veiculoEncontrado.Placa == veiculo.Placa &&
                   veiculoEncontrado.Id != veiculo.Id;
        }
    }
}
