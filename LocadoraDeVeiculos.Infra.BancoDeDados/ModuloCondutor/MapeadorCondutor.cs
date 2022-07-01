using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Infra.BancoDeDados.Compartilhado;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.BancoDeDados.ModuloCondutor
{
    public class MapeadorCondutor : MapeadorBase<Condutor>
    {
        RepositorioCondutorEmBancoDeDados repositorioCondutor = new RepositorioCondutorEmBancoDeDados();

        public override void ConfigurarParametros(Condutor registro, SqlCommand comando)
        {
            throw new NotImplementedException();
        }

        public override Condutor ConverterRegistro(SqlDataReader leitorRegistro)
        {
            throw new NotImplementedException();
        }
    }
}