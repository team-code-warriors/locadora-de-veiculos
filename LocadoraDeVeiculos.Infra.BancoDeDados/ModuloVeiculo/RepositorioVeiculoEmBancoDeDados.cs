using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using LocadoraDeVeiculos.Infra.BancoDeDados.Compartilhado;
using System.Data.SqlClient;

namespace LocadoraDeVeiculos.Infra.BancoDeDados.ModuloVeiculo
{
    public class RepositorioVeiculoEmBancoDeDados :
        RepositorioBase<Veiculo, ValidadorVeiculo, MapeadorVeiculo>
    {
        protected override string sqlInserir =>
            @"INSERT INTO [TBVEICULO]
                (
                    [MODELO],
                    [FABRICANTE],
                    [ANO],
                    [CAMBIO],
                    [COR],
                    [PLACA],
                    [KILOMETRAGEM],
                    [TIPODECOMBUSTIVEL],
                    [CAPACIDADEDOTANQUE],
                    [GRUPO_ID],
                    [FOTO]
                )
                VALUES
                (
                    @MODELO,
                    @FABRICANTE,
                    @ANO,
                    @CAMBIO,
                    @COR,
                    @PLACA,
                    @KILOMETRAGEM,
                    @TIPODECOMBUSTIVEL,
                    @CAPACIDADEDOTANQUE,
                    @GRUPO_ID,
                    @FOTO

                );SELECT SCOPE_IDENTITY();";

        protected override string sqlEditar =>
            @"UPDATE [TBVEICULO]
                SET
                    [MODELO] = @MODELO,
                    [FABRICANTE] = @FABRICANTE,
                    [ANO] = @ANO,
                    [CAMBIO] = @CAMBIO,
                    [COR] = @COR,
                    [PLACA] = @PLACA,
                    [KILOMETRAGEM] = @KILOMETRAGEM,
                    [TIPODECOMBUSTIVEL] = @TIPODECOMBUSTIVEL,
                    [CAPACIDADEDOTANQUE] = @CAPACIDADEDOTANQUE,
                    [GRUPO_ID] = @GRUPO_ID,
                    [FOTO] = @FOTO

                WHERE
                    [ID] = @ID";

        protected override string sqlExcluir =>
            @"DELETE FROM [TBVEICULO]
                WHERE
                    [ID] = @ID";

        protected override string sqlSelecionarPorId =>
                @"SELECT 
                    VEICULO.[ID],
		            VEICULO.[MODELO],
                    VEICULO.[FABRICANTE],
                    VEICULO.[ANO],
                    VEICULO.[CAMBIO],
                    VEICULO.[COR],
                    VEICULO.[PLACA],
                    VEICULO.[KILOMETRAGEM],
                    VEICULO.[TIPODECOMBUSTIVEL],
                    VEICULO.[CAPACIDADEDOTANQUE],
                    VEICULO.[GRUPO_ID],
                    VEICULO.[FOTO],

                    GRUPO.[ID] AS GRUPO_ID,
                    GRUPO.[NOME] AS GRUPO_NOME
	            FROM 
		            [TBVEICULO] AS VEICULO INNER JOIN [TBGRUPODEVEICULOS] AS GRUPO
                ON GRUPO.ID = VEICULO.GRUPO_ID
		        WHERE
                    VEICULO.[ID] = @ID";

        protected override string sqlSelecionarTodos =>
                @"SELECT 
                    VEICULO.[ID],
		            VEICULO.[MODELO],
                    VEICULO.[FABRICANTE],
                    VEICULO.[ANO],
                    VEICULO.[CAMBIO],
                    VEICULO.[COR],
                    VEICULO.[PLACA],
                    VEICULO.[KILOMETRAGEM],
                    VEICULO.[TIPODECOMBUSTIVEL],
                    VEICULO.[CAPACIDADEDOTANQUE],
                    VEICULO.[GRUPO_ID],
                    VEICULO.[FOTO],

                    GRUPO.[ID] AS GRUPO_ID,
                    GRUPO.[NOME] AS GRUPO_NOME
	            FROM 
		            [TBVEICULO] AS VEICULO INNER JOIN [TBGRUPODEVEICULOS] AS GRUPO
                ON GRUPO.ID = VEICULO.GRUPO_ID";

        private string sqlSelecionarPorPlaca =>
                @"SELECT 
                    VEICULO.[ID],
		            VEICULO.[MODELO],
                    VEICULO.[FABRICANTE],
                    VEICULO.[ANO],
                    VEICULO.[CAMBIO],
                    VEICULO.[COR],
                    VEICULO.[PLACA],
                    VEICULO.[KILOMETRAGEM],
                    VEICULO.[TIPODECOMBUSTIVEL],
                    VEICULO.[CAPACIDADEDOTANQUE],
                    VEICULO.[GRUPO_ID],
                    VEICULO.[FOTO],

                    GRUPO.[ID] AS GRUPO_ID,
                    GRUPO.[NOME] AS GRUPO_NOME
	            FROM 
		            [TBVEICULO] AS VEICULO INNER JOIN [TBGRUPODEVEICULOS] AS GRUPO
                ON GRUPO.ID = VEICULO.GRUPO_ID
                WHERE 
                    VEICULO.[PLACA] = @PLACA";

        public Veiculo SelecionarVeiculoPorPlaca(string placa)
        {
            return SelecionarPorParametro(sqlSelecionarPorPlaca, new SqlParameter("PLACA", placa));
        }
    }
}
