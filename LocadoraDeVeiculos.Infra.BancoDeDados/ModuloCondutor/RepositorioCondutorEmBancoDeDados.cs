using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Infra.BancoDeDados.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.BancoDeDados.ModuloCondutor
{
    public class RepositorioCondutorEmBancoDeDados :
        RepositorioBase<Condutor, ValidadorCondutor, MapeadorCondutor>
    {
        protected override string sqlInserir => throw new NotImplementedException();

        protected override string sqlEditar => throw new NotImplementedException();

        protected override string sqlExcluir => throw new NotImplementedException();

        protected override string sqlSelecionarPorId => throw new NotImplementedException();

        protected override string sqlSelecionarTodos => throw new NotImplementedException();

        private string sqlSelecionarPorCnh => throw new NotImplementedException();


        //public Condutor SelecionarCondutorPorCnh(string cnh)
        //{
        //    return SelecionarPorParametro(sqlSelecionarPorCnh, new SqlParameter("CNH", cnh));
        //}
    }
}
