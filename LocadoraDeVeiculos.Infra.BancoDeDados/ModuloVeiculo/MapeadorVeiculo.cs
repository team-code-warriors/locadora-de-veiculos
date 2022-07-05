using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using LocadoraDeVeiculos.Infra.BancoDeDados.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculos;
using LocadoraDeVeiculos.Infra.BancoDeDados.ModuloGrupoDeVeiculos;
using System.Data.SqlClient;

namespace LocadoraDeVeiculos.Infra.BancoDeDados.ModuloVeiculo
{
    public class MapeadorVeiculo : MapeadorBase<Veiculo>
    {
        private RepositorioGrupoDeVeiculosEmBancoDeDados repositorioGrupo;
        public override void ConfigurarParametros(Veiculo veiculo, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("ID", veiculo.Id);
            comando.Parameters.AddWithValue("GRUPOID", veiculo.GrupoDeVeiculos);
            comando.Parameters.AddWithValue("MODELO", veiculo.Modelo);
            comando.Parameters.AddWithValue("FABRICANTE", veiculo.Fabricante);
            comando.Parameters.AddWithValue("ANO", veiculo.Ano);
            comando.Parameters.AddWithValue("CAMBIO", veiculo.Cambio);
            comando.Parameters.AddWithValue("COR", veiculo.Cor);
            comando.Parameters.AddWithValue("PLACA", veiculo.Placa);
            comando.Parameters.AddWithValue("KILOMETRAGEM", veiculo.Kilometragem);
            comando.Parameters.AddWithValue("COMBUSTIVEL", veiculo.TipoDeCombustivel);
            comando.Parameters.AddWithValue("CAPACIDADETANQUE", veiculo.CapacidadeDoTanque);
        }
        public override Veiculo ConverterRegistro(SqlDataReader leitorVeiculo)
        {
            int id = Convert.ToInt32(leitorVeiculo["ID"]);
            int idGrupo = Convert.ToInt32(leitorVeiculo["GRUPOID"]);
            string modelo = Convert.ToString(leitorVeiculo["MODELO"]);
            string fabricante = Convert.ToString(leitorVeiculo["FABRICANTE"]);
            int ano = Convert.ToInt32(leitorVeiculo["ANO"]);
            string cambio = Convert.ToString(leitorVeiculo["CAMBIO"]);
            string cor = Convert.ToString(leitorVeiculo["COR"]);
            string placa = Convert.ToString(leitorVeiculo["PLACA"]);
            int kilometragem = Convert.ToInt32(leitorVeiculo["KILOMETRAGEM"]);
            string combustivel = Convert.ToString(leitorVeiculo["COMBUSTIVEL"]);
            decimal capacidadeDoTanque = Convert.ToDecimal(leitorVeiculo["CAPACIDADETANQUE"]);

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
                GrupoDeVeiculos = repositorioGrupo.SelecionarPorId(idGrupo)
            };
        }
    }
}
