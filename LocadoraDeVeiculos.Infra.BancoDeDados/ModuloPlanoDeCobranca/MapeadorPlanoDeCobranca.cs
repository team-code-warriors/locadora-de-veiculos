using LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.Infra.BancoDeDados.Compartilhado;
using LocadoraDeVeiculos.Infra.BancoDeDados.ModuloGrupoDeVeiculos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.BancoDeDados.ModuloPlanoDeCobranca
{
    public class MapeadorPlanoDeCobranca : MapeadorBase<PlanoDeCobranca>
    {
        RepositorioGrupoDeVeiculosEmBancoDeDados repositorioGrupo = new RepositorioGrupoDeVeiculosEmBancoDeDados();
        public override void ConfigurarParametros(PlanoDeCobranca registro, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("ID", registro.Id);
            comando.Parameters.AddWithValue("GRUPO_ID", registro.GrupoVeiculo.Id);
            comando.Parameters.AddWithValue("TIPOPLANO", registro.TipoPlano);
            comando.Parameters.AddWithValue("VALORDIARIA", registro.ValorDiaria);
            comando.Parameters.AddWithValue("KMINCLUSO", registro.KmIncluso);
            comando.Parameters.AddWithValue("PRECOKM", registro.PrecoKm);
        }

        public override PlanoDeCobranca ConverterRegistro(SqlDataReader leitorRegistro)
        {
            int id = Convert.ToInt32(leitorRegistro["ID"]);
            int idGrupo = Convert.ToInt32(leitorRegistro["GRUPO_ID"]);
            string tipoPlano = Convert.ToString(leitorRegistro["TIPOPLANO"]);
            Decimal valorDiaria = Convert.ToDecimal(leitorRegistro["VALORDIARIA"]);
            int kmIncluso = Convert.ToInt32(leitorRegistro["KMINCLUSO"]);
            Decimal precoKm = Convert.ToDecimal(leitorRegistro["PRECOKM"]);

            var plano = new PlanoDeCobranca
            {
                Id = id,
                TipoPlano = tipoPlano,
                ValorDiaria = valorDiaria,
                KmIncluso = kmIncluso,
                PrecoKm = precoKm,
                GrupoVeiculo = repositorioGrupo.SelecionarPorId(idGrupo)
            };

            return plano;

        }
    }
}
