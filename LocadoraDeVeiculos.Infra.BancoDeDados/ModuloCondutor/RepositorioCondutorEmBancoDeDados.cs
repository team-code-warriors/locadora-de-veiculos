using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Infra.BancoDeDados.Compartilhado;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.BancoDeDados.ModuloCondutor
{
    public class RepositorioCondutorEmBancoDeDados :
        RepositorioBase<Condutor, ValidadorCondutor, MapeadorCondutor>
    {
        protected override string sqlInserir =>
            @"INSERT INTO [TBCONDUTOR]
                (
                    [ID],
                    [CLIENTE_ID],       
                    [NOME], 
                    [CPF],
                    [CNH],                    
                    [DATAVALIDADECNH],    
                    [EMAIL],
                    [TELEFONE],                    
                    [ENDERECO]
                )
            VALUES
                (
                    @ID,
                    @CLIENTE_ID,
                    @NOME,
                    @CPF,
                    @CNH,
                    @DATAVALIDADECNH,
                    @EMAIL,
                    @TELEFONE,
                    @ENDERECO
                )";

        protected override string sqlEditar =>
            @"UPDATE [TBCONDUTOR]
                SET
                    [CLIENTE_ID] = @CLIENTE_ID,
                    [NOME] = @NOME,
                    [CPF] = @CPF,
                    [CNH] = @CNH,
                    [DATAVALIDADECNH] = @DATAVALIDADECNH,
                    [EMAIL] = @EMAIL,
                    [TELEFONE] = @TELEFONE,
                    [ENDERECO] = @ENDERECO
                WHERE
                    [ID] = @ID";

        protected override string sqlExcluir =>
            @"DELETE FROM [TBCONDUTOR]
                WHERE
                    [ID] = @ID";

        protected override string sqlSelecionarPorId =>
            @"SELECT 
                    CONDUTOR.ID AS CONDUTOR_ID,
                    CONDUTOR.NOME AS CONDUTOR_NOME,
                    CONDUTOR.CPF AS CONDUTOR_CPF,
                    CONDUTOR.CNH AS CONDUTOR_CNH,
                    CONDUTOR.DATAVALIDADECNH AS CONDUTOR_DATAVALIDADECNH,
                    CONDUTOR.EMAIL AS CONDUTOR_EMAIL,
                    CONDUTOR.TELEFONE AS CONDUTOR_TELEFONE,
                    CONDUTOR.ENDERECO AS CONDUTOR_ENDERECO,

                    CLIENTE.ID AS CLIENTE_ID,
                    CLIENTE.NOME AS CLIENTE_NOME,
                    CLIENTE.EMAIL AS CLIENTE_EMAIL,
                    CLIENTE.ENDERECO AS CLIENTE_ENDERECO,
                    CLIENTE.CPF AS CLIENTE_CPF,
                    CLIENTE.CNPJ AS CLIENTE_CNPJ,
                    CLIENTE.TELEFONE AS CLIENTE_TELEFONE

	            FROM 
		            [TBCONDUTOR] AS CONDUTOR INNER JOIN [TBCLIENTE] AS CLIENTE
                ON 
                    CONDUTOR.[CLIENTE_ID] = CLIENTE.[ID]
		        WHERE
                    CONDUTOR.[ID] = @ID";

        protected override string sqlSelecionarTodos =>
            @"SELECT 
                    CONDUTOR.ID AS CONDUTOR_ID,
                    CONDUTOR.NOME AS CONDUTOR_NOME,
                    CONDUTOR.CPF AS CONDUTOR_CPF,
                    CONDUTOR.CNH AS CONDUTOR_CNH,
                    CONDUTOR.DATAVALIDADECNH AS CONDUTOR_DATAVALIDADECNH,
                    CONDUTOR.EMAIL AS CONDUTOR_EMAIL,
                    CONDUTOR.TELEFONE AS CONDUTOR_TELEFONE,
                    CONDUTOR.ENDERECO AS CONDUTOR_ENDERECO,

                    CLIENTE.ID AS CLIENTE_ID,
                    CLIENTE.NOME AS CLIENTE_NOME,
                    CLIENTE.EMAIL AS CLIENTE_EMAIL,
                    CLIENTE.ENDERECO AS CLIENTE_ENDERECO,
                    CLIENTE.CPF AS CLIENTE_CPF,
                    CLIENTE.CNPJ AS CLIENTE_CNPJ,
                    CLIENTE.TELEFONE AS CLIENTE_TELEFONE

	            FROM 
		            [TBCONDUTOR] AS CONDUTOR INNER JOIN [TBCLIENTE] AS CLIENTE
                ON 
                    CONDUTOR.[CLIENTE_ID] = CLIENTE.[ID]";

        private string sqlSelecionarPorCliente =>
            @"SELECT 
                    CONDUTOR.ID AS CONDUTOR_ID,
                    CONDUTOR.NOME AS CONDUTOR_NOME,
                    CONDUTOR.CPF AS CONDUTOR_CPF,
                    CONDUTOR.CNH AS CONDUTOR_CNH,
                    CONDUTOR.DATAVALIDADECNH AS CONDUTOR_DATAVALIDADECNH,
                    CONDUTOR.EMAIL AS CONDUTOR_EMAIL,
                    CONDUTOR.TELEFONE AS CONDUTOR_TELEFONE,
                    CONDUTOR.ENDERECO AS CONDUTOR_ENDERECO,

                    CLIENTE.ID AS CLIENTE_ID,
                    CLIENTE.NOME AS CLIENTE_NOME,
                    CLIENTE.EMAIL AS CLIENTE_EMAIL,
                    CLIENTE.ENDERECO AS CLIENTE_ENDERECO,
                    CLIENTE.CPF AS CLIENTE_CPF,
                    CLIENTE.CNPJ AS CLIENTE_CNPJ,
                    CLIENTE.TELEFONE AS CLIENTE_TELEFONE

	            FROM 
		            [TBCONDUTOR] AS CONDUTOR INNER JOIN [TBCLIENTE] AS CLIENTE
                ON 
                    CONDUTOR.[CLIENTE_ID] = CLIENTE.[ID]
		        WHERE
                    CONDUTOR.[CLIENTE_ID] = @CLIENTE_ID";

        private string sqlSelecionarCpf =>
            @"SELECT 
                    CONDUTOR.ID AS CONDUTOR_ID,
                    CONDUTOR.NOME AS CONDUTOR_NOME,
                    CONDUTOR.CPF AS CONDUTOR_CPF,
                    CONDUTOR.CNH AS CONDUTOR_CNH,
                    CONDUTOR.DATAVALIDADECNH AS CONDUTOR_DATAVALIDADECNH,
                    CONDUTOR.EMAIL AS CONDUTOR_EMAIL,
                    CONDUTOR.TELEFONE AS CONDUTOR_TELEFONE,
                    CONDUTOR.ENDERECO AS CONDUTOR_ENDERECO,

                    CLIENTE.ID AS CLIENTE_ID,
                    CLIENTE.NOME AS CLIENTE_NOME,
                    CLIENTE.EMAIL AS CLIENTE_EMAIL,
                    CLIENTE.ENDERECO AS CLIENTE_ENDERECO,
                    CLIENTE.CPF AS CLIENTE_CPF,
                    CLIENTE.CNPJ AS CLIENTE_CNPJ,
                    CLIENTE.TELEFONE AS CLIENTE_TELEFONE

	            FROM 
		            [TBCONDUTOR] AS CONDUTOR INNER JOIN [TBCLIENTE] AS CLIENTE
                ON 
                    CONDUTOR.[CLIENTE_ID] = CLIENTE.[ID]
		        WHERE
                    CONDUTOR.[CPF] = @CPF";


        public Condutor SelecionarCondutorPorCliente(Guid id)
        {
            return SelecionarPorParametro(sqlSelecionarPorCliente, new SqlParameter("CLIENTE_ID", id));
        }

        public Condutor SelecionarCondutorPorCpf(string cpf)
        {
            return SelecionarPorParametro(sqlSelecionarCpf, new SqlParameter("CPF", cpf));
        }
    }
}
