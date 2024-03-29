﻿using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculos;
using LocadoraDeVeiculos.Infra.BancoDeDados.Compartilhado;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.BancoDeDados.ModuloGrupoDeVeiculos
{
    public class MapeadorGrupoDeVeiculos : MapeadorBase<GrupoDeVeiculos>
    {
        public override void ConfigurarParametros(GrupoDeVeiculos grupo, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("ID", grupo.Id);
            comando.Parameters.AddWithValue("NOME", grupo.Nome);
        }

        public override GrupoDeVeiculos ConverterRegistro(SqlDataReader leitorGrupo)
        {
            var id = Guid.Parse(leitorGrupo["GRUPO_ID"].ToString());
            string nome = Convert.ToString(leitorGrupo["GRUPO_NOME"]);

            return new GrupoDeVeiculos()
            {
                Id = id,
                Nome = nome
            };
        }
        
    }
}
