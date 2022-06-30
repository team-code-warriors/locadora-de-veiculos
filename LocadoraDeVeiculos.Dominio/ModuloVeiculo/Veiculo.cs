using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculos;

namespace LocadoraDeVeiculos.Dominio.ModuloVeiculo
{
    public class Veiculo : EntidadeBase<Veiculo>
    {
        public Veiculo() { }

        public string Modelo { get; set; }
        public string Fabricante { get; set; }
        public string Ano { get; set; }
        public string Cambio { get; set; }
        public string Cor { get; set; }
        public string Placa { get; set; }
        public int Kilometragem { get; set; }
        public string TipoDeCombustivel { get; set; }
        public decimal CapacidadeDoTanque { get; set; }
        public GrupoDeVeiculos GrupoDeVeiculos { get; set; }


        public Veiculo(string modelo, string fabricante, string ano, string cambio,
            string cor, string placa, int kilometragem, string tipoDeCombustivel,
            decimal capacidadeDoTanque, GrupoDeVeiculos grupoDeVeiculos)
        {
            Modelo = modelo;
            Fabricante = fabricante;
            Ano = ano;
            Cambio = cambio;
            Cor = cor;
            Placa = placa;
            Kilometragem = kilometragem;
            TipoDeCombustivel = tipoDeCombustivel;
            CapacidadeDoTanque = capacidadeDoTanque;
            GrupoDeVeiculos = grupoDeVeiculos;
        }

        public override bool Equals(object? obj)
        {
            return obj is Veiculo veiculo &&
                Id == veiculo.Id &&
                Modelo == veiculo.Modelo &&
                Fabricante == veiculo.Fabricante &&
                Ano == veiculo.Ano &&
                Cambio == veiculo.Cambio &&
                Cor == veiculo.Cor &&
                Placa == veiculo.Placa &&
                Kilometragem == veiculo.Kilometragem &&
                TipoDeCombustivel == veiculo.TipoDeCombustivel &&
                CapacidadeDoTanque == veiculo.CapacidadeDoTanque &&
                GrupoDeVeiculos == veiculo.GrupoDeVeiculos;
        }
        public Veiculo Clonar()
        {
            return MemberwiseClone() as Veiculo;
        }
    }
}
