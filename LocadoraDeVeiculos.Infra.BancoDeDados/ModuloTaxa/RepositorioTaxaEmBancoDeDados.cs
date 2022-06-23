using LocadoraDeVeiculos.Dominio.ModuloTaxa;
using LocadoraDeVeiculos.Infra.BancoDeDados.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.BancoDeDados.ModuloTaxa
{
    public class RepositorioTaxaEmBancoDeDados :
        RepositorioBase<Taxa, ValidadorTaxa, MapeadorTaxa>
    {
        protected override string sqlInserir =>
            @"INSERT INTO [TBTAXA] 
                (
                    [DESCRICAO],
                    [VALOR],
                    [TIPOCALCULO]
	            )
	            VALUES
                (
                    @DESCRICAO,
                    @VALOR,
                    @TIPOCALCULO

                );SELECT SCOPE_IDENTITY();";

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

    }
}

