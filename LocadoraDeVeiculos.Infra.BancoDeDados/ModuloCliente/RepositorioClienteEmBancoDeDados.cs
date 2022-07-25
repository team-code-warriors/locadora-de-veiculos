using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Infra.BancoDeDados.Compartilhado;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
                    [ID],
                    [NOME],
                    [EMAIL],
                    [ENDERECO],
                    [CPF],
                    [CNPJ],
                    [TELEFONE]
	            )
	            VALUES
                (
                    @ID,
                    @NOME,
                    @EMAIL,
                    @ENDERECO,
                    @CPF,
                    @CNPJ,
                    @TELEFONE

                )";

        protected override string sqlEditar =>
            @"UPDATE[TBCLIENTE]
                SET
                    [NOME] = @NOME,
                    [EMAIL] = @EMAIL,
                    [ENDERECO] = @ENDERECO,
                    [CPF] = @CPF,
                    [CNPJ] = @CNPJ,
                    [TELEFONE] = @TELEFONE

                WHERE
                    [ID] = @ID";

        protected override string sqlExcluir =>
            @"DELETE FROM [TBCLIENTE]			        
		        WHERE
			        [ID] = @ID";

        protected override string sqlSelecionarPorId =>
            @"SELECT 
                    [ID] AS CLIENTE_ID,
		            [NOME] AS CLIENTE_NOME,
                    [EMAIL] AS CLIENTE_EMAIL,
                    [ENDERECO] AS CLIENTE_ENDERECO,
                    [CPF] AS CLIENTE_CPF,
                    [CNPJ] AS CLIENTE_CNPJ,
                    [TELEFONE] AS CLIENTE_TELEFONE
	            FROM 
		            [TBCLIENTE]
		        WHERE
                    [ID] = @ID";

        protected override string sqlSelecionarTodos =>
            @"SELECT
                    [ID] AS CLIENTE_ID,
		            [NOME] AS CLIENTE_NOME,
                    [EMAIL] AS CLIENTE_EMAIL,
                    [ENDERECO] AS CLIENTE_ENDERECO,
                    [CPF] AS CLIENTE_CPF,
                    [CNPJ] AS CLIENTE_CNPJ,
                    [TELEFONE] AS CLIENTE_TELEFONE
	            FROM 
		            [TBCLIENTE]";

        private string sqlSelecionarPorCpf =>
            @"SELECT
                    [ID] AS CLIENTE_ID,
		            [NOME] AS CLIENTE_NOME,
                    [EMAIL] AS CLIENTE_EMAIL,
                    [ENDERECO] AS CLIENTE_ENDERECO,
                    [CPF] AS CLIENTE_CPF,
                    [CNPJ] AS CLIENTE_CNPJ,
                    [TELEFONE] AS CLIENTE_TELEFONE
	            FROM 
		            [TBCLIENTE]
                WHERE 
                    [CPF] = @CPF";

        private string sqlSelecionarPorCnpj =>
            @"SELECT
                    [ID] AS CLIENTE_ID,
		            [NOME] AS CLIENTE_NOME,
                    [EMAIL] AS CLIENTE_EMAIL,
                    [ENDERECO] AS CLIENTE_ENDERECO,
                    [CPF] AS CLIENTE_CPF,
                    [CNPJ] AS CLIENTE_CNPJ,
                    [TELEFONE] AS CLIENTE_TELEFONE
	            FROM 
		            [TBCLIENTE]
                WHERE 
                    [CNPJ] = @CNPJ";


        public Cliente SelecionarClientePorCpf(string cpf)
        {
            return SelecionarPorParametro(sqlSelecionarPorCpf, new SqlParameter("CPF", cpf));
        }

        public Cliente SelecionarClientePorCnpj(string cnpj)
        {
            return SelecionarPorParametro(sqlSelecionarPorCnpj, new SqlParameter("CNPJ", cnpj));
        }
    }
}
