using FluentValidation.Results;
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
    public class RepositorioTaxaEmBancoDeDados :
        RepositorioBase<Taxa, MapeadorTaxa>, IRepositorioTaxa
    {
        protected override string sqlInserir =>
            @"INSERT INTO [TBTAXA] 
                (
                    [ID],
                    [DESCRICAO],
                    [VALOR],
                    [TIPOCALCULO]
	            )
	            VALUES
                (
                    @ID,
                    @DESCRICAO,
                    @VALOR,
                    @TIPOCALCULO
                )";

        protected override string sqlEditar =>
            @"UPDATE [TBTAXA]	
		        SET
			        [DESCRICAO] = @DESCRICAO,
			        [VALOR] = @VALOR,
                    [TIPOCALCULO] = @TIPOCALCULO

		        WHERE
			        [ID] = @ID";

        protected override string sqlExcluir =>
            @"DELETE FROM [TBTAXA]			        
		        WHERE
			        [ID] = @ID";

        protected override string sqlSelecionarPorId =>
            @"SELECT 
		            [ID], 
		            [DESCRICAO], 
		            [VALOR],
                    [TIPOCALCULO]
	            FROM 
		            [TBTAXA]
		        WHERE
                    [ID] = @ID";

        protected override string sqlSelecionarTodos =>
            @"SELECT 
		            [ID], 
		            [DESCRICAO], 
		            [VALOR],
                    [TIPOCALCULO]
	            FROM 
		            [TBTAXA]";

        private string sqlSelecionarPorDescricao =>
            @"SELECT
   		            [ID], 
		            [DESCRICAO], 
		            [VALOR],
                    [TIPOCALCULO]
	            FROM 
		            [TBTAXA]
                WHERE 
                    [DESCRICAO] = @DESCRICAO";


        public Taxa SelecionarTaxaPorDescricao(string descricao)
        {
            return SelecionarPorParametro(sqlSelecionarPorDescricao, new SqlParameter("DESCRICAO", descricao));
        }
    }
}

