using FluentResults;
using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Infra.Orm.ModuloCondutor;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace LocadoraDeVeiculos.Aplicacao.ModuloCondutor
{
    public class ServicoCondutor
    {
        private IRepositorioCondutor repositorioCondutor;
        private IContextoPersistencia contextoPersistencia;

        public ServicoCondutor(IRepositorioCondutor repositorioCondutor, IContextoPersistencia contextoPersistencia)
        {
            this.repositorioCondutor = repositorioCondutor;
            this.contextoPersistencia = contextoPersistencia;
        }

        public Result<Condutor> Inserir(Condutor condutor)
        {
            Log.Logger.Debug("Tentando inserir condutor... {@c}", condutor);

            Result resultadoValidacao = ValidarCondutor(condutor);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir o condutor {CondutorId} - {Motivo}",
                       condutor.Id, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioCondutor.Inserir(condutor);
                contextoPersistencia.GravarDados();

                Log.Logger.Information("Condutor {CondutorId} inserido com sucesso", condutor.Id);

                return Result.Ok(condutor);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar inserir o condutor";

                Log.Logger.Error(ex, msgErro + "{CondutorId}", condutor.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<Condutor> Editar(Condutor condutor)
        {
            Log.Logger.Debug("Tentando editar condutor... {@c}", condutor);

            Result resultadoValidacao = ValidarCondutor(condutor);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar o Condutor {CondutorId} - {Motivo}",
                       condutor.Id, erro.Message);
                }
                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioCondutor.Editar(condutor);
                contextoPersistencia.GravarDados();

                Log.Logger.Information("Condutor {CondutorId} editado com sucesso", condutor.Id);

                return Result.Ok(condutor);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar editar o condutor";

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
                contextoPersistencia.GravarDados();

                Log.Logger.Information("Condutor {CondutorId} excluído com sucesso", condutor.Id);

                return Result.Ok();
            }
            catch (DbUpdateException ex)
            {
                string msgErro = $"O condutor {condutor.Id} está relacionado com outro registro e não pode ser excluído";

                contextoPersistencia.RollBack();

                Log.Logger.Error(ex, msgErro + "{CondutorId}", condutor.Id);

                return Result.Fail(msgErro);
            }
            catch (InvalidOperationException ex)
            {
                string msgErro = $"O condutor {condutor.Id} está relacionado com outro registro e não pode ser excluído";

                contextoPersistencia.RollBack();

                Log.Logger.Error(ex, msgErro + "{CondutorId}", condutor.Id);

                return Result.Fail(msgErro);
            }
            catch (NaoPodeExcluirEsteRegistroException ex)
            {
                string msgErro = $"O condutor {condutor.Id} está relacionado com um registro e não pode ser excluídol";

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
                    if (CpfDuplicado(condutor) && ClienteDuplicado(condutor))
                        errors.Add(new Error("CPF do Condutor já cadastrado para o Cliente"));
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
