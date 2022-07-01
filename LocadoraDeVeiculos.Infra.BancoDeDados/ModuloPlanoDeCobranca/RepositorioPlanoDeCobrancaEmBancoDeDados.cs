using LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.Infra.BancoDeDados.Compartilhado;
using System.Data.SqlClient;

namespace LocadoraDeVeiculos.Infra.BancoDeDados.ModuloPlanoDeCobranca
{
    public class RepositorioPlanoDeCobrancaEmBancoDeDados :
        RepositorioBase<PlanoDeCobranca, ValidadorPlanoDeCobranca, MapeadorPlanoDeCobranca>
    {
        protected override string sqlInserir =>
            @"INSERT INTO [TBPLANODECOBRANCA]
                (
                    [GRUPO_ID],       
                    [TIPOPLANO], 
                    [VALORDIARIA],
                    [KMINCLUSO],                    
                    [PRECOKM]         
                )
            VALUES
                (
                    @GRUPO_ID,
                    @TIPOPLANO,
                    @VALORDIARIA,
                    @KMINCLUSO,
                    @PRECOKM
                ); SELECT SCOPE_IDENTITY();";

        protected override string sqlEditar =>
            @"UPDATE [TBPLANODECOBRANCA]
                SET
                    [GRUPO_ID] = @GRUPO_ID,
                    [TIPOPLANO] = @TIPOPLANO,
                    [VALORDIARIA] = @VALORDIARIA,
                    [KMINCLUSO] = @KMINCLUSO,
                    [PRECOKM] = @PRECOKM
                WHERE
                    [ID] = @ID";

        protected override string sqlExcluir =>
            @"DELETE FROM [TBPLANODECOBRANCA]
                WHERE
                    [ID] = @ID";

        protected override string sqlSelecionarPorId =>
            @"SELECT 
                    [ID],
		            [GRUPO_ID],       
                    [TIPOPLANO], 
                    [VALORDIARIA],
                    [KMINCLUSO],                    
                    [PRECOKM]   
	            FROM 
		            [TBPLANODECOBRANCA]
		        WHERE
                    [ID] = @ID";
        protected override string sqlSelecionarTodos =>
            @"SELECT 
                    [ID],
		            [GRUPO_ID],       
                    [TIPOPLANO], 
                    [VALORDIARIA],
                    [KMINCLUSO],                    
                    [PRECOKM]   
	            FROM 
		            [TBPLANODECOBRANCA]";

        private string sqlSelecionarPorGrupo =>
            @"SELECT
                    [ID],
		            [GRUPO_ID],       
                    [TIPOPLANO], 
                    [VALORDIARIA],
                    [KMINCLUSO],                    
                    [PRECOKM]   
	            FROM 
		            [TBPLANODECOBRANCA]
                WHERE 
                    [GRUPO_ID] = @GRUPO_ID";

        private string sqlSelecionarPorTipoPlano =>
            @"SELECT
                    [ID],
		            [GRUPO_ID],       
                    [TIPOPLANO], 
                    [VALORDIARIA],
                    [KMINCLUSO],                    
                    [PRECOKM]   
	            FROM 
		            [TBPLANODECOBRANCA]
                WHERE 
                    [TIPOPLANO] = @TIPOPLANO";


        public PlanoDeCobranca SelecionarPlanoPorGrupo(int id)
        {
            return SelecionarPorParametro(sqlSelecionarPorGrupo, new SqlParameter("GRUPO_ID", id));
        }

        public PlanoDeCobranca SelecionarPlanoPorTipoPlano(string tipoPlano)
        {
            return SelecionarPorParametro(sqlSelecionarPorTipoPlano, new SqlParameter("TIPOPLANO", tipoPlano));
        }
    }
}
