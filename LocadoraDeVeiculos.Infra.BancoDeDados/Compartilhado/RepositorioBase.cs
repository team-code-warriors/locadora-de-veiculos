using FluentValidation;
using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.BancoDeDados.Compartilhado
{
    public abstract class RepositorioBase<T, TValidador, TMapeador>
        where T : EntidadeBase<T>
        where TValidador : AbstractValidator<T>, new()
        where TMapeador : MapeadorBase<T>, new()
    { 
        private readonly string enderecoBanco;

        public RepositorioBase()
        {
            var configuracao = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("ConfiguracaoAplicacao.json")
                .Build();

            enderecoBanco = configuracao.GetConnectionString("SqlServer");
        }

        protected abstract string sqlInserir { get; }

        protected abstract string sqlEditar { get; }

        protected abstract string sqlExcluir { get; }

        protected abstract string sqlSelecionarPorId { get; }

        protected abstract string sqlSelecionarTodos { get; }

        public ValidationResult Inserir(T registro)
        {
            var resultadoValidacao = Validar(registro);

            if (resultadoValidacao.IsValid == false)
                return resultadoValidacao;

            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoInsercao = new SqlCommand(sqlInserir, conexaoComBanco);

            var mapeador = new TMapeador();

            mapeador.ConfigurarParametros(registro, comandoInsercao);

            conexaoComBanco.Open();
            var id = comandoInsercao.ExecuteNonQuery();

            conexaoComBanco.Close();

            return resultadoValidacao;
        }

        public ValidationResult Editar(T registro)
        {
            var validador = new TValidador();

            var resultadoValidacao = validador.Validate(registro);

            if (resultadoValidacao.IsValid == false)
                return resultadoValidacao;

            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoEdicao = new SqlCommand(sqlEditar, conexaoComBanco);

            var mapeador = new TMapeador();

            mapeador.ConfigurarParametros(registro, comandoEdicao);

            conexaoComBanco.Open();
            comandoEdicao.ExecuteNonQuery();
            conexaoComBanco.Close();

            return resultadoValidacao;
        }

        public void Excluir(T registro)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoExclusao = new SqlCommand(sqlExcluir, conexaoComBanco);

            comandoExclusao.Parameters.AddWithValue("ID", registro.Id);

            try
            {
                conexaoComBanco.Open();
                comandoExclusao.ExecuteNonQuery();
                conexaoComBanco.Close();
            }
            catch (Exception ex)
            {
                if (ex != null && ex.Message.Contains("The DELETE statement conflicted with the REFERENCE constraint"))
                    throw new NaoPodeExcluirEsteRegistroException(ex);

                throw;
            }
        }

        public T SelecionarPorId(Guid id)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoSelecao = new SqlCommand(sqlSelecionarPorId, conexaoComBanco);

            comandoSelecao.Parameters.AddWithValue("ID", id);

            conexaoComBanco.Open();
            SqlDataReader leitorRegistro = comandoSelecao.ExecuteReader();

            var mapeador = new TMapeador();
            T registro = null;
            if (leitorRegistro.Read())
                registro = mapeador.ConverterRegistro(leitorRegistro);

            conexaoComBanco.Close();

            return registro;
        }

        public List<T> SelecionarTodos()
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoSelecao = new SqlCommand(sqlSelecionarTodos, conexaoComBanco);

            conexaoComBanco.Open();

            SqlDataReader leitorRegistro = comandoSelecao.ExecuteReader();

            var mapeador = new TMapeador();

            List<T> registros = new List<T>();

            while (leitorRegistro.Read())
                registros.Add(mapeador.ConverterRegistro(leitorRegistro));

            conexaoComBanco.Close();

            return registros;
        }

        public virtual ValidationResult Validar(T registro)
        {
            var validator = new TValidador();

            var resultadoValidacao = validator.Validate(registro);

            if (resultadoValidacao.IsValid == false)
                return resultadoValidacao;

            return resultadoValidacao;
        }

        public virtual T SelecionarPorParametro(string sqlSelecionarPorParametro, SqlParameter parametro)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoSelecao = new SqlCommand(sqlSelecionarPorParametro, conexaoComBanco);

            comandoSelecao.Parameters.Add(parametro);

            T registro = null;

            try
            {
                conexaoComBanco.Open();
                SqlDataReader leitorRegistro = comandoSelecao.ExecuteReader();

                var mapeador = new TMapeador();

                if (leitorRegistro.Read())
                    registro = mapeador.ConverterRegistro(leitorRegistro);

                conexaoComBanco.Close();
            }
            catch (Exception ex)
            {
                if (ex != null && ex.Message.Contains("Cannot open database"))
                    throw new NaoPodeInserirEsteRegistroException(ex);

                throw;
            }

            return registro;
        }
    }
}
