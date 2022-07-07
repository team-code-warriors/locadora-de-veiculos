using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using LocadoraDeVeiculos.Infra.BancoDeDados.ModuloVeiculo;
using Serilog;

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
            Log.Logger.Debug("Tentando inserir veículo... {@v}", veiculo);

            ValidationResult resultadoValidacao = Validar(veiculo);

            if (resultadoValidacao.IsValid)
            {
                repositorioVeiculo.Inserir(veiculo);
                Log.Logger.Debug("Veículo {VeiculoPlaca} inserido com sucesso", veiculo.Placa);
            }
            else
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir um Veículo {VeiculoPlaca} - {Motivo}",
                        veiculo.Placa, erro.ErrorMessage);
                }
            }

            return resultadoValidacao;
        }

        public ValidationResult Editar(Veiculo veiculo)
        {
            Log.Logger.Debug("Tentando editar veículo... {@v}", veiculo);

            ValidationResult resultadoValidacao = Validar(veiculo);

            if (resultadoValidacao.IsValid)
            {
                repositorioVeiculo.Editar(veiculo);
                Log.Logger.Debug("Veículo {VeiculoPlaca} editado com sucesso", veiculo.Placa);
            }
            else
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar um Veículo {VeiculoPlaca} - {Motivo}",
                        veiculo.Placa, erro.ErrorMessage);
                }
            }

            return resultadoValidacao;
        }

        private ValidationResult Validar(Veiculo veiculo)
        {
            var validador = new ValidadorVeiculo();

            var resultadoValidacao = validador.Validate(veiculo);

            if(resultadoValidacao.IsValid)
                if (PlacaDuplicada(veiculo))
                    resultadoValidacao.Errors.Add(new ValidationFailure("Veículo", "Veículo já cadastrado"));

            return resultadoValidacao;
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
