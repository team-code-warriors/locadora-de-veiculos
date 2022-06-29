using FluentValidation.Results;
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
                    [ENDERECO],
                    [CPF],
                    [TELEFONE],
                    [CNH]
	            )
	            VALUES
                (
                    @NOME,
                    @EMAIL,
                    @ENDERECO,
                    @CPF,
                    @TELEFONE,
                    @CNH

                );SELECT SCOPE_IDENTITY();";

        protected override string sqlEditar =>
            @"UPDATE[TBCLIENTE]
                SET
                    [NOME] = @NOME,
                    [EMAIL] = @EMAIL,
                    [ENDERECO] = @ENDERECO,
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
                    [ID],
		            [NOME],
                    [EMAIL],
                    [ENDERECO],
                    [CPF],
                    [TELEFONE],
                    [CNH]
	            FROM 
		            [TBCLIENTE]
		        WHERE
                    [ID] = @ID";

        protected override string sqlSelecionarTodos =>
            @"SELECT
                    [ID], 
		            [NOME],
                    [EMAIL],
                    [ENDERECO],
                    [CPF],
                    [TELEFONE],
                    [CNH]
	            FROM 
		            [TBCLIENTE]";

        public override ValidationResult Validar(Cliente registro)
        {
            var validador = new ValidadorCliente();

            var resultadoValidacao = validador.Validate(registro);

            if (resultadoValidacao.IsValid == false)
                return resultadoValidacao;

            var registroEncontrado = SelecionarTodos()
                .Select(x => x.Cpf.ToLower())
                .Contains(registro.Cpf.ToLower());

            if (registroEncontrado)
            {
                if (registro.Id == 0)
                    resultadoValidacao.Errors.Add(new ValidationFailure("", "CPF já cadastrado"));
                else if (registro.Id != 0)
                {
                    resultadoValidacao.Errors.Add(new ValidationFailure("", "CPF já cadastrado"));
                }
            }

            return resultadoValidacao;
        }
    }
}
