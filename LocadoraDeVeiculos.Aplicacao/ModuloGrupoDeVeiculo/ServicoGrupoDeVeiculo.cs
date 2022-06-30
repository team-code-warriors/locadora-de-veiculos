using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculos;
using LocadoraDeVeiculos.Infra.BancoDeDados.ModuloGrupoDeVeiculos;

namespace LocadoraDeVeiculos.Aplicacao.ModuloGrupoDeVeiculo
{
    public class ServicoGrupoDeVeiculo
    {
        private RepositorioGrupoDeVeiculosEmBancoDeDados repositorioDeGrupoVeiculos;

        public ServicoGrupoDeVeiculo(RepositorioGrupoDeVeiculosEmBancoDeDados repositorioGrupoVeiculos)
        {
            this.repositorioDeGrupoVeiculos = repositorioGrupoVeiculos;
        }

        public ValidationResult Inserir(GrupoDeVeiculos grupo)
        {
            ValidationResult resultadoValidacao = Validar(grupo);

            if (resultadoValidacao.IsValid)
                repositorioDeGrupoVeiculos.Inserir(grupo);

            return resultadoValidacao;
        }

        public ValidationResult Editar(GrupoDeVeiculos grupo)
        {
            ValidationResult resultadoValidacao = Validar(grupo);

            if (resultadoValidacao.IsValid)
                repositorioDeGrupoVeiculos.Editar(grupo);

            return resultadoValidacao;
        }

        private ValidationResult Validar(GrupoDeVeiculos grupo)
        {
            var validador = new ValidadorGrupoDeVeiculos();

            var resultadoValidacao = validador.Validate(grupo);

            if (NomeDuplicado(grupo))
                resultadoValidacao.Errors.Add(new ValidationFailure("Nome", "Grupo já cadastrado"));

            return resultadoValidacao;
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
