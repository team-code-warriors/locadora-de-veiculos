using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.Infra.BancoDeDados.ModuloPlanoDeCobranca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Aplicacao.ModuloPlanoDeCobrancas
{
    public class ServicoPlanoDeCobranca
    {
        private RepositorioPlanoDeCobrancaEmBancoDeDados repositorioPlano;

        public ServicoPlanoDeCobranca(RepositorioPlanoDeCobrancaEmBancoDeDados repositorioPlano)
        {
            this.repositorioPlano = repositorioPlano;
        }

        public ValidationResult Inserir(PlanoDeCobranca plano)
        {
            ValidationResult resultadoValidacao = Validar(plano);

            if (resultadoValidacao.IsValid)
                repositorioPlano.Inserir(plano);

            return resultadoValidacao;
        }

        public ValidationResult Editar(PlanoDeCobranca plano)
        {
            ValidationResult resultadoValidacao = Validar(plano);

            if (resultadoValidacao.IsValid)
                repositorioPlano.Editar(plano);

            return resultadoValidacao;
        }

        private ValidationResult Validar(PlanoDeCobranca plano)
        {
            var validador = new ValidadorPlanoDeCobranca();

            var resultadoValidacao = validador.Validate(plano);

            //if (NomeDuplicado(grupo))
            //    resultadoValidacao.Errors.Add(new ValidationFailure("Nome", "Grupo já cadastrado"));

            return resultadoValidacao;
        }

        //private bool NomeDuplicado(GrupoDeVeiculos grupo)
        //{
        //    var grupoEncontrado = repositorioDeGrupoVeiculos.SelecionarGrupoPorNome(grupo.Nome);

        //    return grupoEncontrado != null &&
        //           grupoEncontrado.Nome == grupo.Nome &&
        //           grupoEncontrado.Id != grupo.Id;
        //}
    }
}
