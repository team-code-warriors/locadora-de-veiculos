using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Infra.BancoDeDados.ModuloCliente;

namespace LocadoraDeVeiculos.Aplicacao.ModuloCliente
{
    public class ServicoCliente
    {
        private RepositorioClienteEmBancoDeDados repositorioCliente;

        public ServicoCliente(RepositorioClienteEmBancoDeDados repositorioCliente)
        {
            this.repositorioCliente = repositorioCliente;
        }

        public ValidationResult Inserir(Cliente cliente)
        {
            var resultadoValidacao = ValidarCliente(cliente);

            if (resultadoValidacao.IsValid)
                repositorioCliente.Inserir(cliente);

            return resultadoValidacao;
        }

        public ValidationResult Editar(Cliente cliente)
        {
            var resultadoValidacao = ValidarCliente(cliente);

            if (resultadoValidacao.IsValid)
                repositorioCliente.Editar(cliente);

            return resultadoValidacao;
        }

        private ValidationResult ValidarCliente(Cliente cliente)
        {
            ValidadorCliente validador = new ValidadorCliente();

            var resultadoValidacao = validador.Validate(cliente);

            if(resultadoValidacao.IsValid)
            {
                if(cliente.Cpf != " ")
                    if (CpfDuplicado(cliente))
                        resultadoValidacao.Errors.Add(new ValidationFailure("CPF", "CPF já cadastrado"));

                if(cliente.Cnpj != " ")
                    if (CnpjDuplicado(cliente))
                        resultadoValidacao.Errors.Add(new ValidationFailure("CNJP", "CNPJ já cadastrado"));
            }

            return resultadoValidacao;
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
