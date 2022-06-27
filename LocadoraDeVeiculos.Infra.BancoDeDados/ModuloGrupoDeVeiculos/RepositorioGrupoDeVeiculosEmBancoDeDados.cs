using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculos;
using LocadoraDeVeiculos.Infra.BancoDeDados.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.BancoDeDados.ModuloGrupoDeVeiculos
{
    public class RepositorioGrupoDeVeiculosEmBancoDeDados :
        RepositorioBase<GrupoDeVeiculos, ValidadorGrupoDeVeiculos, MapeadorGrupoDeVeiculos>
    {
        protected override string sqlInserir =>
            @"INSERT INTO [TBGRUPODEVEICULOS]
                (
                    [NOME]
                )
                VALUES
                (
                    @NOME
                );SELECT SCOPE_IDENTITY();";
        protected override string sqlEditar =>
            @"UPDATE [TBGRUPODEVEICULOS]
                SET
                    [NOME] = @NOME

                WHERE
                    [ID] = @ID";

        protected override string sqlExcluir =>
            @"DELETE FROM [TBGRUPODEVEICULOS]
                WHERE
                    [ID] = @ID";

        protected override string sqlSelecionarPorId =>
            @"SELECT 
                    [ID],
		            [NOME]
	            FROM 
		            [TBGRUPODEVEICULOS]
		        WHERE
                    [ID] = @ID";

        protected override string sqlSelecionarTodos =>
            @"SELECT 
                    [ID],
		            [NOME]
	            FROM 
		            [TBGRUPODEVEICULOS]";

        public override ValidationResult Validar(GrupoDeVeiculos registro)
        {
            var validador = new ValidadorGrupoDeVeiculos();

            var resultadoValidacao = validador.Validate(registro);

            if (resultadoValidacao.IsValid == false)
                return resultadoValidacao;

            var registroEncontrado = SelecionarTodos()
                .Select(x => x.Nome.ToLower())
                .Contains(registro.Nome.ToLower());

            if (registroEncontrado)
            {
                if (registro.Id == 0)
                    resultadoValidacao.Errors.Add(new ValidationFailure("", "Grupo já cadastrado"));
                else if (registro.Id != 0)
                    resultadoValidacao.Errors.Add(new ValidationFailure("", "Grupo já cadastrado"));
            }

            return resultadoValidacao;
        }
    }
}
