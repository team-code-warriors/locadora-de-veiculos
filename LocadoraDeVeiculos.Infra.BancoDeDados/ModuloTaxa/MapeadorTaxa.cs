using LocadoraDeVeiculos.Dominio.ModuloTaxa;
using LocadoraDeVeiculos.Infra.BancoDeDados.Compartilhado;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.BancoDeDados.ModuloTaxa
{
    public class MapeadorTaxa : MapeadorBase<Taxa>
    {
        public override void ConfigurarParametros(Taxa taxa, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("ID", taxa.Id);
            comando.Parameters.AddWithValue("DESCRICAO", taxa.Descricao);
            comando.Parameters.AddWithValue("VALOR", taxa.Valor);
            comando.Parameters.AddWithValue("TIPOCALCULO", taxa.TipoCalculo);
        }

        public override Taxa ConverterRegistro(SqlDataReader leitorTaxa)
        {
            int id = Convert.ToInt32(leitorTaxa["ID"]);
            string descricao = Convert.ToString(leitorTaxa["DESCRICAO"]);
            Decimal valor = Convert.ToDecimal(leitorTaxa["VALOR"]);
            string tipoCalculo = Convert.ToString(leitorTaxa["TIPOCALCULO"]);

            return new Taxa()
            {
                Id = id,
                Descricao = descricao,
                Valor = valor,
                TipoCalculo = tipoCalculo
            };
        }
    }
}
