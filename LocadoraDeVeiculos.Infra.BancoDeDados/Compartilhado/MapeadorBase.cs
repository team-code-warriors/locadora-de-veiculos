﻿using LocadoraDeVeiculos.Dominio.Compartilhado;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.BancoDeDados.Compartilhado
{
    public abstract class MapeadorBase<T> where T : EntidadeBase<T>
    {
        public abstract void ConfigurarParametros(T registro, SqlCommand comando);

        public abstract T ConverterRegistro(SqlDataReader leitorRegistro);
    }
}
