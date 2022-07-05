using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using LocadoraDeVeiculos.Infra.BancoDeDados.ModuloVeiculo;

namespace LocadoraDeVeiculos.Aplicacao.ModuloVeiculo
{
    public class ServicoVeiculo
    {
        private RepositorioVeiculoEmBancoDeDados repositorioVeiculo;

        public ServicoVeiculo(RepositorioVeiculoEmBancoDeDados repositorioVeiculo)
        {
            this.repositorioVeiculo = repositorioVeiculo;
        }

        public ValidationResult Inserir(Veiculo veiculo)
        {
            ValidationResult resultadoValidacao = Validar(veiculo);

            if (resultadoValidacao.IsValid)
                repositorioVeiculo.Inserir(veiculo);

            return resultadoValidacao;
        }

        public ValidationResult Editar(Veiculo veiculo)
        {
            ValidationResult resultadoValidacao = Validar(veiculo);

            if (resultadoValidacao.IsValid)
                repositorioVeiculo.Editar(veiculo);

            return resultadoValidacao;
        }

        private ValidationResult Validar(Veiculo veiculo)
        {
            var validador = new ValidadorVeiculo();

            var resultadoValidacao = validador.Validate(veiculo);

            if (DescricaoDuplicada(veiculo))
                resultadoValidacao.Errors.Add(new ValidationFailure("Veículo", "Veículo já cadastrado"));

            return resultadoValidacao;
        }

        private bool DescricaoDuplicada(Veiculo veiculo)
        {
            var veiculoEncontrado = repositorioVeiculo.SelecionarVeiculoPorModelo(veiculo.Modelo);

            return veiculoEncontrado != null &&
                   veiculoEncontrado.Modelo == veiculo.Modelo &&
                   veiculoEncontrado.Id != veiculo.Id;
        }
    }
}
