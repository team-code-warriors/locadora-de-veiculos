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

            if (resultadoValidacao.IsValid)
                if (GrupoDuplicado(plano) && TipoPlanoDuplicado(plano))
                    resultadoValidacao.Errors.Add(new ValidationFailure("Plano", "Plano para este Grupo já cadastrado"));

            return resultadoValidacao;
        }

        private bool GrupoDuplicado(PlanoDeCobranca plano)
        {
            var planoEncontrado = repositorioPlano.SelecionarPlanoPorGrupo(plano.GrupoVeiculo.Id);

            return planoEncontrado != null &&
                   planoEncontrado.GrupoVeiculo.Id == plano.GrupoVeiculo.Id &&
                   planoEncontrado.Id != plano.Id;
        }

        private bool TipoPlanoDuplicado(PlanoDeCobranca plano)
        {
            var planoEncontrado = repositorioPlano.SelecionarPlanoPorTipoPlano(plano.TipoPlano);

            return planoEncontrado != null &&
                   planoEncontrado.TipoPlano == plano.TipoPlano &&
                   planoEncontrado.Id != plano.Id;
        }

    }
}
