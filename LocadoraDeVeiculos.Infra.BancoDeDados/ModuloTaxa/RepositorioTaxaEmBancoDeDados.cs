﻿using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloTaxa;
using LocadoraDeVeiculos.Infra.BancoDeDados.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.BancoDeDados.ModuloTaxa
{
    public class RepositorioTaxaEmBancoDeDados :
        RepositorioBase<Taxa, ValidadorTaxa, MapeadorTaxa>
    {
        protected override string sqlInserir =>
            @"INSERT INTO [TBTAXA] 
                (
                    [DESCRICAO],
                    [VALOR],
                    [TIPOCALCULO]
	            )
	            VALUES
                (
                    @DESCRICAO,
                    @VALOR,
                    @TIPOCALCULO

                );SELECT SCOPE_IDENTITY();";

        protected override string sqlEditar =>
            @"UPDATE [TBTAXA]	
		        SET
			        [DESCRICAO] = @DESCRICAO,
			        [VALOR] = @VALOR,
                    [TIPOCALCULO] = @TIPOCALCULO

		        WHERE
			        [ID] = @ID";

        protected override string sqlExcluir =>
            @"DELETE FROM [TBTAXA]			        
		        WHERE
			        [ID] = @ID";

        protected override string sqlSelecionarPorId =>
            @"SELECT 
		            [ID], 
		            [DESCRICAO], 
		            [VALOR],
                    [TIPOCALCULO]
	            FROM 
		            [TBTAXA]
		        WHERE
                    [ID] = @ID";

        protected override string sqlSelecionarTodos =>
            @"SELECT 
		            [ID], 
		            [DESCRICAO], 
		            [VALOR],
                    [TIPOCALCULO]
	            FROM 
		            [TBTAXA]";

        public override ValidationResult Validar(Taxa registro)
        {
            var validador = new ValidadorTaxa();

            var resultadoValidacao = validador.Validate(registro);

            if (resultadoValidacao.IsValid == false)
                return resultadoValidacao;

            var registroEncontrado = SelecionarTodos()
                .Select(x => x.Descricao.ToLower())
                .Contains(registro.Descricao.ToLower());

            if (registroEncontrado)
            {
                if (registro.Id == 0)
                    resultadoValidacao.Errors.Add(new ValidationFailure("", "Taxa já cadastrado"));
                else if (registro.Id != 0)
                {
                    resultadoValidacao.Errors.Add(new ValidationFailure("", "Taxa já cadastrado"));
                }
            }

            return resultadoValidacao;
        }
    }
}
