using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Infra.BancoDeDados.Compartilhado;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.BancoDeDados.ModuloFuncionario
{
    public class RepositorioFuncionarioEmBancoDeDados :
        RepositorioBase<Funcionario, MapeadorFuncionario>, IRepositorioFuncionario
    {
        protected override string sqlInserir =>
            @"INSERT INTO [TBFUNCIONARIO] 
                (
                    [ID],
                    [NOME],
                    [SALARIO],
                    [DATAADMISSAO],
                    [LOGIN],
                    [SENHA],
                    [TIPOPERFIL]

	            )
	            VALUES
                (
                    @ID,
                    @NOME,
                    @SALARIO,
                    @DATAADMISSAO,
                    @LOGIN,
                    @SENHA,
                    @TIPOPERFIL

                )";

        protected override string sqlEditar =>
            @"UPDATE [TBFUNCIONARIO]	
		        SET
			        [NOME] = @NOME,
			        [SALARIO] = @SALARIO,
                    [DATAADMISSAO] = @DATAADMISSAO,
                    [LOGIN] = @LOGIN,
                    [SENHA] = @SENHA,
                    [TIPOPERFIL] = @TIPOPERFIL

		        WHERE
			        [ID] = @ID";

        protected override string sqlExcluir =>
            @"DELETE FROM [TBFUNCIONARIO]			        
		        WHERE
			        [ID] = @ID";

        protected override string sqlSelecionarPorId =>
            @"SELECT 
		            [ID], 
		            [NOME], 
		            [SALARIO],
                    [DATAADMISSAO],
                    [LOGIN],
                    [SENHA],
                    [TIPOPERFIL]
	            FROM 
		            [TBFUNCIONARIO]
		        WHERE
                    [ID] = @ID";

        protected override string sqlSelecionarTodos =>
            @"SELECT 
		            [ID], 
		            [NOME], 
		            [SALARIO],
                    [DATAADMISSAO],
                    [LOGIN],
                    [SENHA],
                    [TIPOPERFIL]
	            FROM 
		            [TBFUNCIONARIO]";

        private string sqlSelecionarPorNome =>
            @"SELECT 
                   [ID],       
                   [NOME],
                   [SALARIO],
                   [DATAADMISSAO],
                   [LOGIN],
                   [SENHA],
                   [TIPOPERFIL]
            FROM
                [TBFUNCIONARIO]
            WHERE 
                [NOME] = @NOME";


        private string sqlSelecionarPorLogin =>
            @"SELECT 
                   [ID],       
                   [NOME],
                   [SALARIO],
                   [DATAADMISSAO],
                   [LOGIN],
                   [SENHA],
                   [TIPOPERFIL]
            FROM
                [TBFUNCIONARIO]
            WHERE 
                [LOGIN] = @LOGIN";

        public Funcionario SelecionarFuncionarioPorLogin(string login)
        {
            return SelecionarPorParametro(sqlSelecionarPorLogin, new SqlParameter("LOGIN", login));
        }

        public Funcionario SelecionarFuncionarioPorNome(string nome)
        {
            return SelecionarPorParametro(sqlSelecionarPorNome, new SqlParameter("NOME", nome));
        }

    }
}
