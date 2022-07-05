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
                    [GRUPOID]
                )
                VALUES
                (
                    @MODELO,
                    @FABRICANTE,
                    @ANO,
                    @CAMBIO,
                    @COR,
                    @PLACA,
                    @KILOMETRAGEM
                    @TIPODECOMBUSTIVEL,
                    @CAPACIDADEDOTANQUE,
                    @GRUPOID
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
                    [GRUPOID] = @GRUPOID

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
                    [GRUPOID]
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
                    [GRUPOID]
	            FROM 
		            [TBVEICULO]";

        private string sqlSelecionarPorModelo =>
            @"SELECT
                    [ID], 
		            [MODELO]
	            FROM 
		            [TBVEICULO]
                WHERE 
                    [NOME] = @NOME";

        public Veiculo SelecionarVeiculoPorModelo(string modelo)
        {
            return SelecionarPorParametro(sqlSelecionarPorModelo, new SqlParameter("MODELO", modelo));
        }
    }
}
