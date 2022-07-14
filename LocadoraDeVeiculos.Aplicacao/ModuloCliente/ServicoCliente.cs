using FluentResults;
using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Infra.BancoDeDados.ModuloCliente;
using Serilog;

namespace LocadoraDeVeiculos.Aplicacao.ModuloCliente
{
    public class ServicoCliente
    {
        private RepositorioClienteEmBancoDeDados repositorioCliente;

        public ServicoCliente(RepositorioClienteEmBancoDeDados repositorioCliente)
        {
            this.repositorioCliente = repositorioCliente;
        }

        public Result<Cliente> Inserir(Cliente cliente)
        {
            Log.Logger.Debug("Tentando inserir cliente... {@c}", cliente);

            Result resultadoValidacao = ValidarCliente(cliente);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir o cliente {ClienteId} - {Motivo}",
                       cliente.Id, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioCliente.Inserir(cliente);

                Log.Logger.Information("Cliente {ClienteId} inserido com sucesso", cliente.Id);

                return Result.Ok(cliente);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar inserir o cliente";

                Log.Logger.Error(ex, msgErro + "{ClienteId}", cliente.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<Cliente> Editar(Cliente cliente)
        {
            Log.Logger.Debug("Tentando editar cliente... {@c}", cliente);

            Result resultadoValidacao = ValidarCliente(cliente);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar o Cliente {ClienteId} - {Motivo}",
                       cliente.Id, erro.Message);
                }
                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioCliente.Editar(cliente);

                Log.Logger.Information("Cliente {ClienteId} editado com sucesso", cliente.Id);

                return Result.Ok(cliente);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar editar o cliente";

                Log.Logger.Error(ex, msgErro + "{ClienteId}", cliente.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result Excluir(Cliente cliente)
        {
            Log.Logger.Debug("Tentando excluir cliente... {@f}", cliente);

            try
            {
                repositorioCliente.Excluir(cliente);

                Log.Logger.Information("Cliente {ClienteId} excluído com sucesso", cliente.Id);

                return Result.Ok();
            }
            catch (NaoPodeExcluirEsteRegistroException ex)
            {
                string msgErro = $"O cliente {cliente.Nome} está relacionado com um condutor e não pode ser excluído";

                Log.Logger.Error(ex, msgErro + "{ClienteId}", cliente.Id);

                return Result.Fail(msgErro);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar excluir o cliente";

                Log.Logger.Error(ex, msgErro + "{ClienteId}", cliente.Id);

                return Result.Fail(msgErro);
            }
        }

        private Result ValidarCliente(Cliente cliente)
        {
            ValidadorCliente validador = new ValidadorCliente();

            var resultadoValidacao = validador.Validate(cliente);

            List<Error> errors = new List<Error>();

            foreach(ValidationFailure r in resultadoValidacao.Errors)
            {
                errors.Add(new Error(r.ErrorMessage));
            }

            if(resultadoValidacao.IsValid)
            {
                if(cliente.Cpf != "              ")
                    if (CpfDuplicado(cliente))
                        errors.Add(new Error("CPF já cadastrado"));

                if(cliente.Cnpj != "                  ")
                    if (CnpjDuplicado(cliente))
                        errors.Add(new Error("CNPJ já cadastrado"));
            }

            if (errors.Any())
            {
                return Result.Fail(errors);
            }

            return Result.Ok();
        }

        public Result< List<Cliente> > SelecionarTodos()
        {
            try
            {
                return Result.Ok(repositorioCliente.SelecionarTodos());
            }
            catch(Exception e)
            {
                string msgErro = "Falha no sistema ao tentar selecionar todos os clientes";

                Log.Logger.Error(e, msgErro);

                return Result.Fail(msgErro);
            }
        }

        public Result<Cliente> SelecionarPorId(Guid id)
        {
            try
            {
                return Result.Ok(repositorioCliente.SelecionarPorId(id));
            }
            catch (Exception e)
            {
                string msgErro = "Falha no sistema ao tentar selecionar o cliente";

                Log.Logger.Error(e, msgErro + "{ClienteId}", id);

                return Result.Fail(msgErro);
            }
        }

        private bool CpfDuplicado(Cliente cliente)
        {
            var clienteEncontrado = repositorioCliente.SelecionarClientePorCpf(cliente.Cpf);

            return clienteEncontrado != null &&
                   clienteEncontrado.Cpf == cliente.Cpf &&
                   clienteEncontrado.Id != cliente.Id;
        }

        private bool CnpjDuplicado(Cliente cliente)
        {
            var clienteEncontrado = repositorioCliente.SelecionarClientePorCnpj(cliente.Cnpj);

            return clienteEncontrado != null &&
                   clienteEncontrado.Cnpj == cliente.Cnpj &&
                   clienteEncontrado.Id != cliente.Id;
        }
    }
}
