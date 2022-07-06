using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculos;
using System.Drawing;

namespace LocadoraDeVeiculos.Dominio.ModuloVeiculo
{
    public class Veiculo : EntidadeBase<Veiculo>
    {
        public Veiculo() { }

        public string Modelo { get; set; }
        public string Fabricante { get; set; }
        public int Ano { get; set; }
        public string Cambio { get; set; }
        public string Cor { get; set; }
        public string Placa { get; set; }
        public int Kilometragem { get; set; }
        public string TipoDeCombustivel { get; set; }
        public decimal CapacidadeDoTanque { get; set; }
        public GrupoDeVeiculos GrupoDeVeiculos { get; set; }

        public byte[] Foto { get; set; }

        //public Bitmap Foto
        //{
        //    get
        //    {
        //        using (var stream = new MemoryStream(FotoB))
        //        {
        //            return new Bitmap(stream);
        //        }
        //    }
        //}

        public Veiculo(string modelo, string fabricante, int ano, string cambio,
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

        public Veiculo Clonar()
        {
            return MemberwiseClone() as Veiculo;
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
                   EqualityComparer<GrupoDeVeiculos>.Default.Equals(GrupoDeVeiculos, veiculo.GrupoDeVeiculos);
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(Id);
            hash.Add(Modelo);
            hash.Add(Fabricante);
            hash.Add(Ano);
            hash.Add(Cambio);
            hash.Add(Cor);
            hash.Add(Placa);
            hash.Add(Kilometragem);
            hash.Add(TipoDeCombustivel);
            hash.Add(CapacidadeDoTanque);
            hash.Add(GrupoDeVeiculos);
            return hash.ToHashCode();
        }
    }
}
