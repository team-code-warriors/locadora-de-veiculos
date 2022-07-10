using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using LocadoraDeVeiculos.Infra.BancoDeDados.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculos;
using LocadoraDeVeiculos.Infra.BancoDeDados.ModuloGrupoDeVeiculos;
using System.Data.SqlClient;

namespace LocadoraDeVeiculos.Infra.BancoDeDados.ModuloVeiculo
{
    public class MapeadorVeiculo : MapeadorBase<Veiculo>
    {
        private RepositorioGrupoDeVeiculosEmBancoDeDados repositorioGrupo = new RepositorioGrupoDeVeiculosEmBancoDeDados();
        public override void ConfigurarParametros(Veiculo registro, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("ID", registro.Id);
            comando.Parameters.AddWithValue("GRUPO_ID", registro.GrupoDeVeiculos.Id);
            comando.Parameters.AddWithValue("MODELO", registro.Modelo);
            comando.Parameters.AddWithValue("FABRICANTE", registro.Fabricante);
            comando.Parameters.AddWithValue("ANO", registro.Ano);
            comando.Parameters.AddWithValue("CAMBIO", registro.Cambio);
            comando.Parameters.AddWithValue("COR", registro.Cor);
            comando.Parameters.AddWithValue("PLACA", registro.Placa);
            comando.Parameters.AddWithValue("KILOMETRAGEM", registro.Kilometragem);
            comando.Parameters.AddWithValue("TIPODECOMBUSTIVEL", registro.TipoDeCombustivel);
            comando.Parameters.AddWithValue("CAPACIDADEDOTANQUE", registro.CapacidadeDoTanque);
            comando.Parameters.AddWithValue("FOTO", registro.Foto);
        }
        public override Veiculo ConverterRegistro(SqlDataReader leitorVeiculo)
        {
            int id = Convert.ToInt32(leitorVeiculo["ID"]);
            string modelo = Convert.ToString(leitorVeiculo["MODELO"]);
            string fabricante = Convert.ToString(leitorVeiculo["FABRICANTE"]);
            int ano = Convert.ToInt32(leitorVeiculo["ANO"]);
            string cambio = Convert.ToString(leitorVeiculo["CAMBIO"]);
            string cor = Convert.ToString(leitorVeiculo["COR"]);
            string placa = Convert.ToString(leitorVeiculo["PLACA"]);
            int kilometragem = Convert.ToInt32(leitorVeiculo["KILOMETRAGEM"]);
            string combustivel = Convert.ToString(leitorVeiculo["TIPODECOMBUSTIVEL"]);
            decimal capacidadeDoTanque = Convert.ToDecimal(leitorVeiculo["CAPACIDADEDOTANQUE"]);
            var imagem = (byte[])(leitorVeiculo["FOTO"]);

            return new Veiculo()
            {
                Id = id,
                Modelo = modelo,
                Fabricante = fabricante,
                Ano = ano,
                Cambio = cambio,
                Cor = cor,
                Placa = placa,
                Kilometragem = kilometragem,
                TipoDeCombustivel = combustivel,
                CapacidadeDoTanque = capacidadeDoTanque,
                GrupoDeVeiculos = new MapeadorGrupoDeVeiculos().ConverterRegistro(leitorVeiculo),
                Foto = imagem
            };

        }
    }
}
