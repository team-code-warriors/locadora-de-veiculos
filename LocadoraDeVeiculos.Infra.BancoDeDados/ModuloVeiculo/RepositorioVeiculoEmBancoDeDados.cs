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
                    [ID],
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
	            FROM 
		            [TBVEICULO]
		        WHERE
                    [ID] = @ID";

        protected override string sqlSelecionarTodos =>
            @"SELECT 
                    [ID],
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
	            FROM 
		            [TBVEICULO]";

        private string sqlSelecionarPorPlaca =>
            @"SELECT
                    [ID],
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
	            FROM 
		            [TBVEICULO]
                WHERE 
                    [PLACA] = @PLACA";

        public Veiculo SelecionarVeiculoPorPlaca(string placa)
        {
            return SelecionarPorParametro(sqlSelecionarPorPlaca, new SqlParameter("PLACA", placa));
        }
    }
}
