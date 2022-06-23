using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Infra.BancoDeDados.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.BancoDeDados.ModuloCliente
{
    public class RepositorioClienteEmBancoDeDados :
        RepositorioBase<Cliente, ValidadorCliente, MapeadorCliente>
    {
        protected override string sqlInserir =>
            @"INSERT INTO [TBCLIENTE] 
                (
                    [NOME],
                    [EMAIL],
                    [CPF],
                    [TELEFONE],
                    [CNH]
	            )
	            VALUES
                (
                    @NOME,
                    @EMAIL,
                    @CPF,
                    @TELEFONE,
                    @CNH

                );SELECT SCOPE_IDENTITY();";

        protected override string sqlEditar =>
            @"UPDATE[TBCLIENTE]
                SET
                    [NOME] = @NOME,
                    [EMAIL] = @EMAIL,
                    [CPF] = @CPF,
                    [TELEFONE] = @TELEFONE,
                    [CNH] = @CNH

                WHERE
                    [ID] = @ID";

        protected override string sqlExcluir =>
            @"DELETE FROM [TBCLIENTE]			        
		        WHERE
			        [ID] = @ID";

        protected override string sqlSelecionarPorId =>
            @"SELECT 
		            [NOME],
                    [EMAIL],
                    [CPF],
                    [TELEFONE],
                    [CNH]
	            FROM 
		            [TBCLIENTE]
		        WHERE
                    [ID] = @ID";

        protected override string sqlSelecionarTodos =>
            @"SELECT 
		            [NOME],
                    [EMAIL],
                    [CPF],
                    [TELEFONE],
                    [CNH]
	            FROM 
		            [TBCLIENTE]";
    }
}
