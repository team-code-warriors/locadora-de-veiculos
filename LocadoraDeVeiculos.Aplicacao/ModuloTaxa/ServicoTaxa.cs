using FluentResults;
using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloTaxa;
using LocadoraDeVeiculos.Infra.Orm.ModuloTaxa;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace LocadoraDeVeiculos.Aplicacao.ModuloTaxa
{
    public class ServicoTaxa
    {
        private IRepositorioTaxa repositorioTaxa;
        private IContextoPersistencia contextoPersistencia;

        public ServicoTaxa(IRepositorioTaxa repositorioTaxa, IContextoPersistencia contextoPersistencia)
        {
            this.repositorioTaxa = repositorioTaxa;
            this.contextoPersistencia = contextoPersistencia;
        }

        public Result<Taxa> Inserir(Taxa taxa)
        {
            Log.Logger.Debug("Tentando inserir taxa... {@t}", taxa);

            Result resultadoValidacao = ValidarTaxa(taxa);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir a Taxa {TaxaId} - {Motivo}",
                       taxa.Id, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioTaxa.Inserir(taxa);
                contextoPersistencia.GravarDados();

                Log.Logger.Information("Taxa {TaxaId} inserida com sucesso", taxa.Id);

                return Result.Ok(taxa);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar inserir a taxa";

                Log.Logger.Error(ex, msgErro + "{TaxaId}", taxa.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<Taxa> Editar(Taxa taxa)
        {
            Log.Logger.Debug("Tentando editar taxa... {@t}", taxa);

            Result resultadoValidacao = ValidarTaxa(taxa);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar a Taxa {TaxaId} - {Motivo}",
                       taxa.Id, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioTaxa.Editar(taxa);
                contextoPersistencia.GravarDados();

                Log.Logger.Information("Taxa {TaxaId} editada com sucesso", taxa.Id);

                return Result.Ok(taxa);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar editar a taxa";

                Log.Logger.Error(ex, msgErro + "{TaxaId}", taxa.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result Excluir(Taxa taxa)
        {
            Log.Logger.Debug("Tentando excluir taxa... {@t}", taxa);

            try
            {
                repositorioTaxa.Excluir(taxa);
                contextoPersistencia.GravarDados();

                Log.Logger.Information("Taxa {TaxaId} excluída com sucesso", taxa.Id);

                return Result.Ok();
            }
            catch (DbUpdateException ex)
            {
                string msgErro = $"A taxa {taxa.Id} está relacionada com outro registro e não pode ser excluída";

                contextoPersistencia.RollBack();

                Log.Logger.Error(ex, msgErro + "{TaxaId}", taxa.Id);

                return Result.Fail(msgErro);
            }
            catch (InvalidOperationException ex)
            {
                string msgErro = $"A taxa {taxa.Id} está relacionada com outro registro e não pode ser excluída";

                contextoPersistencia.RollBack();

                Log.Logger.Error(ex, msgErro + "{TaxaId}", taxa.Id);

                return Result.Fail(msgErro);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar excluir a taxa";

                Log.Logger.Error(ex, msgErro + "{TaxaId}", taxa.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<List<Taxa>> SelecionarTodos()
        {
            try
            {
                return Result.Ok(repositorioTaxa.SelecionarTodos());
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar todas as taxas";

                Log.Logger.Error(ex, msgErro);

                return Result.Fail(msgErro);
            }
        }

        public Result<Taxa> SelecionarPorId(Guid id)
        {
            try
            {
                return Result.Ok(repositorioTaxa.SelecionarPorId(id));
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar a taxa";

                Log.Logger.Error(ex, msgErro + "{TaxaId}", id);

                return Result.Fail(msgErro);
            }
        }

        private Result ValidarTaxa(Taxa taxa)
        {
            var validador = new ValidadorTaxa();

            var resultadoValidacao = validador.Validate(taxa);

            List<Error> erros = new List<Error>(); //FluentResult

            foreach (ValidationFailure item in resultadoValidacao.Errors) //FluentValidation            
                erros.Add(new Error(item.ErrorMessage));

            var validaDescricao = DescricaoDuplicada(taxa);

            if (validaDescricao.IsSuccess)
            {
                if (validaDescricao.Value == true)
                {
                    erros.Add(new Error("Descrição já cadastrada"));
                }
            }
            else
            {
                erros.Add(new Error(validaDescricao.Errors[0].Message));
            }

            if (erros.Any())
                return Result.Fail(erros);

            return Result.Ok();
        }

        private Result<bool> DescricaoDuplicada(Taxa taxa)
        {
            try
            {
                var taxaEncontrada = repositorioTaxa.SelecionarTaxaPorDescricao(taxa.Descricao);

                bool resultadoValidacao = taxaEncontrada != null &&
                       taxaEncontrada.Descricao == taxa.Descricao &&
                       taxaEncontrada.Id != taxa.Id;

                return Result.Ok(resultadoValidacao);
            }
            catch (NaoPodeInserirEsteRegistroException ex)
            {
                string msgErro = "Falha no sistema ao tentar validar a Descrição da taxa";

                Log.Logger.Error(ex, msgErro + "{TaxaId}", taxa.Id);

                return Result.Fail(msgErro);
            }

        }
    }
}
