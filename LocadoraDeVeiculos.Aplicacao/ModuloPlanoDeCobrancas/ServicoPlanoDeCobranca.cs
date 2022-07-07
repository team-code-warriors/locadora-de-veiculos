using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.Infra.BancoDeDados.ModuloPlanoDeCobranca;
using Serilog;
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
            Log.Logger.Debug("Tentando inserir plano... {@p}", plano);

            ValidationResult resultadoValidacao = Validar(plano);

            if (resultadoValidacao.IsValid)
            {
                repositorioPlano.Inserir(plano);
                Log.Logger.Debug("Plano {PlanoNome} inserido com sucesso", plano.TipoPlano);
            }else
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir um Plano {PlanoNome} - {Motivo}",
                        plano.TipoPlano, erro.ErrorMessage);
                }
            }

            return resultadoValidacao;
        }

        public ValidationResult Editar(PlanoDeCobranca plano)
        {
            Log.Logger.Debug("Tentando editar plano... {@p}", plano);

            ValidationResult resultadoValidacao = Validar(plano);

            if (resultadoValidacao.IsValid)
            {
                repositorioPlano.Editar(plano);
                Log.Logger.Debug("Plano {PlanoNome} editado com sucesso", plano.TipoPlano);
            }else
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar um Plano {PlanoNome} - {Motivo}",
                        plano.TipoPlano, erro.ErrorMessage);
                }
            }

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
