using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloTaxa;
using LocadoraDeVeiculos.Infra.BancoDeDados.ModuloCliente;
using LocadoraDeVeiculos.Infra.BancoDeDados.ModuloTaxa;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Aplicacao.ModuloTaxa
{
    public class ServicoTaxa
    {
        private RepositorioTaxaEmBancoDeDados repositorioTaxa;

        public ServicoTaxa(RepositorioTaxaEmBancoDeDados repositorioTaxa)
        {
            this.repositorioTaxa = repositorioTaxa;
        }

        public ValidationResult Inserir(Taxa taxa)
        {
            Log.Logger.Debug("Tentando inserir taxa... {@t}", taxa);

            ValidationResult resultadoValidacao = Validar(taxa);

            if (resultadoValidacao.IsValid)
            {
                repositorioTaxa.Inserir(taxa);
                Log.Logger.Debug("Taxa {TaxaNome} inserida com sucesso", taxa.Descricao);
            }else
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir uma Taxa {TaxaNome} - {Motivo}",
                        taxa.Descricao, erro.ErrorMessage);
                }
            }

            return resultadoValidacao;
        }

        public ValidationResult Editar(Taxa taxa)
        {
            Log.Logger.Debug("Tentando editar taxa... {@t}", taxa);

            ValidationResult resultadoValidacao = Validar(taxa);

            if (resultadoValidacao.IsValid)
            {
                repositorioTaxa.Editar(taxa);
                Log.Logger.Debug("Taxa {TaxaNome} editada com sucesso", taxa.Descricao);
            }
            else
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar uma Taxa {TaxaNome} - {Motivo}",
                        taxa.Descricao, erro.ErrorMessage);
                }
            }

            return resultadoValidacao;
        }

        private ValidationResult Validar(Taxa taxa)
        {
            var validador = new ValidadorTaxa();

            var resultadoValidacao = validador.Validate(taxa);

            if(resultadoValidacao.IsValid)
                if (DescricaoDuplicada(taxa))
                    resultadoValidacao.Errors.Add(new ValidationFailure("Taxa", "Taxa já cadastrada"));

            return resultadoValidacao;
        }

        private bool DescricaoDuplicada(Taxa taxa)
        {
            var taxaEncontrada = repositorioTaxa.SelecionarTaxaPorDescricao(taxa.Descricao);

            return taxaEncontrada != null &&
                   taxaEncontrada.Descricao == taxa.Descricao &&
                   taxaEncontrada.Id != taxa.Id;
        }
    }
}
