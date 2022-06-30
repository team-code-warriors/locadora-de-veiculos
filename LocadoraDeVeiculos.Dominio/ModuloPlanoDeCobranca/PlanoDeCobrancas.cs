using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca
{
    public class PlanoDeCobrancas : EntidadeBase<PlanoDeCobrancas>
    {
        public PlanoDeCobrancas() { }

        public GrupoDeVeiculos GrupoVeiculo { get; set; }
        public string TipoPlano { get; set; }
        public Decimal ValorDiaria { get; set; }
        public int KmIncluso { get; set; }
        public Decimal PrecoKm { get; set; }

        public PlanoDeCobrancas(GrupoDeVeiculos grupoVeiculo, string tipoPlano, decimal valorDiaria, int kmIncluso, decimal precoKm)
        {
            GrupoVeiculo = grupoVeiculo;
            TipoPlano = tipoPlano;
            ValorDiaria = valorDiaria;
            KmIncluso = kmIncluso;
            PrecoKm = precoKm;
        }

        public override bool Equals(object? obj)
        {
            return obj is PlanoDeCobrancas cobrancas &&
                   Id == cobrancas.Id &&
                   EqualityComparer<GrupoDeVeiculos>.Default.Equals(GrupoVeiculo, cobrancas.GrupoVeiculo) &&
                   TipoPlano == cobrancas.TipoPlano &&
                   ValorDiaria == cobrancas.ValorDiaria &&
                   KmIncluso == cobrancas.KmIncluso &&
                   PrecoKm == cobrancas.PrecoKm;
        }

        public PlanoDeCobrancas Clonar()
        {
            return MemberwiseClone() as PlanoDeCobrancas;
        }

    }
}
