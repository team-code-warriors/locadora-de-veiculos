using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculos;
using LocadoraDeVeiculos.Infra.BancoDeDados.Compartilhado;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.BancoDeDados.ModuloGrupoDeVeiculos
{
    public class RepositorioGrupoDeVeiculosEmBancoDeDados :
        RepositorioBase<GrupoDeVeiculos, ValidadorGrupoDeVeiculos, MapeadorGrupoDeVeiculos>
    {
        protected override string sqlInserir =>
            @"INSERT INTO [TBGRUPODEVEICULOS]
                (
                    [NOME]
                )
                VALUES
                (
                    @NOME
                );SELECT SCOPE_IDENTITY();";
        protected override string sqlEditar =>
            @"UPDATE [TBGRUPODEVEICULOS]
                SET
                    [NOME] = @NOME

                WHERE
                    [ID] = @ID";

        protected override string sqlExcluir =>
            @"DELETE FROM [TBPLANODECOBRANCA]
                WHERE
                    [GRUPO_ID] = @ID

            DELETE FROM [TBGRUPODEVEICULOS]
                WHERE
                    [ID] = @ID";

        protected override string sqlSelecionarPorId =>
            @"SELECT 
                    [ID] AS GRUPO_ID,
		            [NOME] AS GRUPO_NOME
	            FROM 
		            [TBGRUPODEVEICULOS]
		        WHERE
                    [ID] = @ID";

        protected override string sqlSelecionarTodos =>
            @"SELECT 
                    [ID] AS GRUPO_ID,
		            [NOME] AS GRUPO_NOME
	            FROM 
		            [TBGRUPODEVEICULOS]";

        private string sqlSelecionarPorNome =>
            @"SELECT
                    [ID] AS GRUPO_ID,
		            [NOME] AS GRUPO_NOME
	            FROM 
		            [TBGRUPODEVEICULOS]
                WHERE 
                    [NOME] = @NOME";

        public GrupoDeVeiculos SelecionarGrupoPorNome(string nome)
        {
            return SelecionarPorParametro(sqlSelecionarPorNome, new SqlParameter("NOME", nome));
        }
    }
}
