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
                    @CLIENTE_ID,
                    @NOME,
                    @CPF,
                    @CNH,
                    @DATAVALIDADECNH,
                    @EMAIL,
                    @TELEFONE,
                    @ENDERECO
                ); SELECT SCOPE_IDENTITY();";

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
                    [ID],
		            [CLIENTE_ID],       
                    [NOME], 
                    [CPF],
                    [CNH],                    
                    [DATAVALIDADECNH],
                    [EMAIL],
                    [TELEFONE],                    
                    [ENDERECO] 
	            FROM 
		            [TBCONDUTOR]
		        WHERE
                    [ID] = @ID";

        protected override string sqlSelecionarTodos =>
            @"SELECT 
                    [ID],
		            [CLIENTE_ID],       
                    [NOME], 
                    [CPF],
                    [CNH],                    
                    [DATAVALIDADECNH],
                    [EMAIL],
                    [TELEFONE],                    
                    [ENDERECO] 
	            FROM 
		            [TBCONDUTOR]";

        private string sqlSelecionarPorCliente =>
            @"SELECT
                    [ID],
		            [CLIENTE_ID],       
                    [NOME], 
                    [CPF],
                    [CNH],                    
                    [DATAVALIDADECNH],
                    [EMAIL],
                    [TELEFONE],                    
                    [ENDERECO] 
	            FROM 
		            [TBCONDUTOR]
                WHERE 
                    [CLIENTE_ID] = @CLIENTE_ID";

        private string sqlSelecionarCpf =>
            @"SELECT
                    [ID],
		            [CLIENTE_ID],       
                    [NOME], 
                    [CPF],
                    [CNH],                    
                    [DATAVALIDADECNH],
                    [EMAIL],
                    [TELEFONE],                    
                    [ENDERECO] 
	            FROM 
		            [TBCONDUTOR]
                WHERE 
                    [CPF] = @CPF";


        public Condutor SelecionarCondutorPorCliente(int id)
        {
            return SelecionarPorParametro(sqlSelecionarPorCliente, new SqlParameter("CLIENTE_ID", id));
        }

        public Condutor SelecionarCondutorPorCpf(string cpf)
        {
            return SelecionarPorParametro(sqlSelecionarCpf, new SqlParameter("CPF", cpf));
        }
    }
}
