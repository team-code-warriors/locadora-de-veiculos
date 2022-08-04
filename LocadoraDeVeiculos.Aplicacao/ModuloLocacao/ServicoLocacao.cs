using FluentResults;
using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloLocacao;
using LocadoraDeVeiculos.Infra.Orm.ModuloLocacao;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Xceed.Wpf.Toolkit;

namespace LocadoraDeVeiculos.Aplicacao.ModuloLocacao
{
    public class ServicoLocacao
    {
        private IRepositorioLocacao repositorioLocacao;
        private IContextoPersistencia contextoPersistencia;

        public ServicoLocacao(IRepositorioLocacao repositorioLocacao, IContextoPersistencia contextoPersistencia)
        {
            this.repositorioLocacao = repositorioLocacao;
            this.contextoPersistencia = contextoPersistencia;
        }

        public Result<Locacao> SelecionarPorId(Guid id)
        {
            try
            {
                return Result.Ok(repositorioLocacao.SelecionarPorId(id));
            }
            catch (Exception e)
            {
                string msgErro = "Falha no sistema ao tentar selecionar a locação";

                Log.Logger.Error(e, msgErro + "{LocacaoId}", id);

                return Result.Fail(msgErro);
            }
        }

        public Result Excluir(Locacao locacao)
        {
            Log.Logger.Debug("Tentando excluir locação... {@l}", locacao);

            Result resultadoValidacao = ValidarLocacao(locacao);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar excluír a Locação {LocacaoId} - {Motivo}",
                       locacao.Id, erro.Message);
                }
                return Result.Fail(resultadoValidacao.Errors);
            }
            try
            {
                if(locacao.Status == StatusLocacaoEnum.Inativa)
                {
                    locacao.Status = StatusLocacaoEnum.Fechada;
                    repositorioLocacao.Excluir(locacao);
                    contextoPersistencia.GravarDados();

                    Log.Logger.Information("Locação {LocacaoId} excluída com sucesso", locacao.Id);

                    return Result.Ok();
                }
                else { 
                    return Result.Fail("Locação deve ser inativa para excluír");
                }
            }
            catch (DbUpdateException ex)
            {
                string msgErro = $"A locação {locacao.Id} está relacionada com outro registro e não pode ser excluída";

                contextoPersistencia.RollBack();

                Log.Logger.Error(ex, msgErro + "{LocacaoId}", locacao.Id);

                return Result.Fail(msgErro);
            }
            catch (InvalidOperationException ex)
            {
                string msgErro = $"A locação {locacao.Id} está relacionada com outro registro e não pode ser excluída";

                contextoPersistencia.RollBack();

                Log.Logger.Error(ex, msgErro + "{LocacaoId}", locacao.Id);

                return Result.Fail(msgErro);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar excluír a locação";

                Log.Logger.Error(ex, msgErro + "{LocacaoId}", locacao.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<Locacao> Inserir(Locacao locacao)
        {
            Log.Logger.Debug("Tentando inserir locação... {@l}", locacao);

            Result resultadoValidacao = ValidarLocacao(locacao);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir a locação {LocaçãoId} - {Motivo}",
                       locacao.Id, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioLocacao.Inserir(locacao);
                contextoPersistencia.GravarDados();

                Log.Logger.Information("Locação {LocacaoId} inserida com sucesso", locacao.Id);

                return Result.Ok(locacao);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar inserir a locação";

                Log.Logger.Error(ex, msgErro + "{LocacaoId}", locacao.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<Locacao> Devolver(Locacao locacao)
        {
            Log.Logger.Debug("Tentando fazer uma devolução... {@l}", locacao);

            Result resultadoValidacao = ValidarLocacao(locacao);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar realizar a Devolucação {LocacaoId} - {Motivo}",
                       locacao.Id, erro.Message);
                }
                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                locacao.Status = StatusLocacaoEnum.Inativa;
                repositorioLocacao.Devolver(locacao);
                contextoPersistencia.GravarDados();

                Log.Logger.Information("Devolução {LocacaoId} realizada com sucesso", locacao.Id);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar devolver a locação";

                Log.Logger.Error(ex, msgErro + "{LocacaoId}", locacao.Id);

                return Result.Fail(msgErro);
            }
        }


        private Result ValidarLocacao(Locacao locacao)
        {
            ValidadorLocacao validador = new ValidadorLocacao();

            var resultadoValidacao = validador.Validate(locacao);

            List<Error> errors = new List<Error>();

            foreach (ValidationFailure r in resultadoValidacao.Errors)
            {
                errors.Add(new Error(r.ErrorMessage));
            }

            if (resultadoValidacao.IsValid)
            {
                if (VeiculoDuplicado(locacao))
                    errors.Add(new Error("Este veículo já está em uma locação ativa"));
            }
  
            if (errors.Any())
            {
                return Result.Fail(errors);
            }

            return Result.Ok();
        }

        private bool VeiculoDuplicado(Locacao locacao)
        {
            var veiculoEncontrado = repositorioLocacao.SelecionarLocacaoPorPlacaDoVeiculo(locacao.Veiculo.Placa);

            return veiculoEncontrado != null &&
                   veiculoEncontrado.Veiculo.Placa == locacao.Veiculo.Placa &&
                   veiculoEncontrado.Id != locacao.Id &&
                   veiculoEncontrado.Status == StatusLocacaoEnum.Ativa;
        }

        public Result<List<Locacao>> SelecionarTodos()
        {
            try
            {
                return Result.Ok(repositorioLocacao.SelecionarTodos());
            }
            catch (Exception e)
            {
                string msgErro = "Falha no sistema ao tentar selecionar todas as locações";

                Log.Logger.Error(e, msgErro);

                return Result.Fail(msgErro);
            }
        }

        public Result<List<Locacao>> SelecionarPorLocacaoAtivaEInativa()
        {
            try
            {
                return Result.Ok(repositorioLocacao.SelecionarPorLocacaoAtivaEInativa());
            }
            catch (Exception e)
            {
                string msgErro = "Falha no sistema ao tentar selecionar as locações ativas";

                Log.Logger.Error(e, msgErro);

                return Result.Fail(msgErro);
            }
        }
    }
}
