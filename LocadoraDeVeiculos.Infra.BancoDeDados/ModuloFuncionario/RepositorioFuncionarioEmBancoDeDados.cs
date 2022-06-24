using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Infra.BancoDeDados.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.BancoDeDados.ModuloFuncionario
{
    public class RepositorioFuncionarioEmBancoDeDados :
        RepositorioBase<Funcionario, ValidadorFuncionario, MapeadorFuncionario>
    {
        protected override string sqlInserir =>
            @"INSERT INTO [TBFUNCIONARIO] 
                (
                    [NOME],
                    [SALARIO],
                    [DATAADMISSAO],
                    [LOGIN],
                    [SENHA],
                    [TIPOPERFIL]

	            )
	            VALUES
                (
                    @NOME,
                    @SALARIO,
                    @DATAADMISSAO,
                    @LOGIN,
                    @SENHA,
                    @TIPOPERFIL

                );SELECT SCOPE_IDENTITY();";

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

        public override ValidationResult Validar(Funcionario registro)
        {
            var validador = new ValidadorFuncionario();

            var resultadoValidacao = validador.Validate(registro);

            if (resultadoValidacao.IsValid == false)
                return resultadoValidacao;

            var registroEncontradoNome = SelecionarTodos()
                .Select(x => x.Nome.ToLower())
                .Contains(registro.Nome.ToLower());

            if (registroEncontradoNome)
            {
                if (registro.Id == 0)
                    resultadoValidacao.Errors.Add(new ValidationFailure("", "Funcionário já cadastrado"));
                else if (registro.Id != 0)
                {
                    resultadoValidacao.Errors.Add(new ValidationFailure("", "Funcionário já cadastrado"));
                }
            }

            var registroEncontradoLogin = SelecionarTodos()
                .Select(x => x.Login.ToLower())
                .Contains(registro.Login.ToLower());

            if (registroEncontradoLogin)
            {
                if (registro.Id == 0)
                    resultadoValidacao.Errors.Add(new ValidationFailure("", "Login já cadastrado"));
                else if (registro.Id != 0)
                {
                    resultadoValidacao.Errors.Add(new ValidationFailure("", "Login já cadastrado"));
                }
            }

            return resultadoValidacao;
        }
    }
}
