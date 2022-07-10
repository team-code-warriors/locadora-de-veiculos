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
                    PLANO.ID AS PLANO_ID,
                    PLANO.TIPOPLANO AS PLANO_TIPOPLANO,
                    PLANO.VALORDIARIA AS PLANO_VALORDIARIA,
                    PLANO.KMINCLUSO AS PLANO_KMINCLUSO,
                    PLANO.PRECOKM AS PLANO_PRECOKM,

                    GRUPO.ID AS GRUPO_ID,
                    GRUPO.NOME AS GRUPO_NOME
	            FROM 
		            [TBPLANODECOBRANCA] AS PLANO INNER JOIN [TBGRUPODEVEICULOS] AS GRUPO
                ON 
                    PLANO.[GRUPO_ID] = GRUPO.[ID]
		        WHERE
                    PLANO.[ID] = @ID";
        protected override string sqlSelecionarTodos =>
            @"SELECT 
                    PLANO.ID AS PLANO_ID,
                    PLANO.TIPOPLANO AS PLANO_TIPOPLANO,
                    PLANO.VALORDIARIA AS PLANO_VALORDIARIA,
                    PLANO.KMINCLUSO AS PLANO_KMINCLUSO,
                    PLANO.PRECOKM AS PLANO_PRECOKM,

                    GRUPO.ID AS GRUPO_ID,
                    GRUPO.NOME AS GRUPO_NOME
	            FROM 
		            [TBPLANODECOBRANCA] AS PLANO INNER JOIN [TBGRUPODEVEICULOS] AS GRUPO
                ON 
                    PLANO.[GRUPO_ID] = GRUPO.[ID]";

        private string sqlSelecionarPorGrupo =>
            @"SELECT 
                    PLANO.ID AS PLANO_ID,
                    PLANO.TIPOPLANO AS PLANO_TIPOPLANO,
                    PLANO.VALORDIARIA AS PLANO_VALORDIARIA,
                    PLANO.KMINCLUSO AS PLANO_KMINCLUSO,
                    PLANO.PRECOKM AS PLANO_PRECOKM,

                    GRUPO.ID AS GRUPO_ID,
                    GRUPO.NOME AS GRUPO_NOME
	            FROM 
		            [TBPLANODECOBRANCA] AS PLANO INNER JOIN [TBGRUPODEVEICULOS] AS GRUPO
                ON 
                    PLANO.[GRUPO_ID] = GRUPO.[ID]
		        WHERE
                    PLANO.[GRUPO_ID] = @GRUPO_ID";

        private string sqlSelecionarPorTipoPlano =>
            @"SELECT 
                    PLANO.ID AS PLANO_ID,
                    PLANO.TIPOPLANO AS PLANO_TIPOPLANO,
                    PLANO.VALORDIARIA AS PLANO_VALORDIARIA,
                    PLANO.KMINCLUSO AS PLANO_KMINCLUSO,
                    PLANO.PRECOKM AS PLANO_PRECOKM,

                    GRUPO.ID AS GRUPO_ID,
                    GRUPO.NOME AS GRUPO_NOME
	            FROM 
		            [TBPLANODECOBRANCA] AS PLANO INNER JOIN [TBGRUPODEVEICULOS] AS GRUPO
                ON 
                    PLANO.[GRUPO_ID] = GRUPO.[ID]
		        WHERE
                    PLANO.[TIPOPLANO] = @TIPOPLANO";


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
