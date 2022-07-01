using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloCondutor
{
    public class Condutor : EntidadeBase<Condutor>
    {
        public Condutor()
        {
        }

        public Condutor(Cliente cliente, string cnh, DateTime dataValidadeCnh)
        {
            Cliente = cliente;
            Cnh = cnh;
            DataValidadeCnh = dataValidadeCnh;
        }

        public Cliente Cliente { get; set; }
        public string Cnh { get; set; }
        public DateTime DataValidadeCnh { get; set; }

        public Condutor Clonar()
        {
            return MemberwiseClone() as Condutor;
        }

        public override bool Equals(object? obj)
        {
            return obj is Condutor condutor &&
                   Id == condutor.Id &&
                   Cliente == condutor.Cliente &&
                   Cnh == condutor.Cnh &&
                   DataValidadeCnh == condutor.DataValidadeCnh;
        }
    }
}
