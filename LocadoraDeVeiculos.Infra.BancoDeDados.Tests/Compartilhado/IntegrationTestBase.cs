using LocadoraDeVeiculos.Infra.BancoDeDados.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.BancoDeDados.Tests.Compartilhado
{
    public class IntegrationTestBase
    {
        public IntegrationTestBase()
        {
            Db.ExecutarSql("DELETE FROM TBLOCACAO;");

            Db.ExecutarSql("DELETE FROM TBTAXA;");

            Db.ExecutarSql("DELETE FROM TBCONDUTOR;");

            Db.ExecutarSql("DELETE FROM TBCLIENTE;");

            Db.ExecutarSql("DELETE FROM TBFUNCIONARIO;");
            
            Db.ExecutarSql("DELETE FROM TBPLANODECOBRANCA;");

            Db.ExecutarSql("DELETE FROM TBVEICULO;");

            Db.ExecutarSql("DELETE FROM TBGRUPODEVEICULOS;");
        }
    }
}
