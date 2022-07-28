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

        public Condutor(Cliente cliente, string nome, string cpf, string cnh, DateTime dataValidadeCnh, string email, string telefone, string endereco)
        {
            Cliente = cliente;
            Nome = nome;
            Cpf = cpf;
            Cnh = cnh;
            DataValidadeCnh = dataValidadeCnh;
            Email = email;
            Telefone = telefone;
            Endereco = endereco;
        }

        public Cliente Cliente { get; set; }

        public string Nome { get; set; }

        public string Cpf { get; set; }

        public string Cnh { get; set; }

        public DateTime DataValidadeCnh { get; set; }

        public string Email { get; set; }

        public string Telefone { get; set; }

        public string Endereco { get; set; }

        public Condutor Clonar()
        {
            return MemberwiseClone() as Condutor;
        }

        public override bool Equals(object? obj)
        {
            return obj is Condutor condutor &&
                   Id == condutor.Id &&
                   EqualityComparer<Cliente>.Default.Equals(Cliente, condutor.Cliente) &&
                   Nome == condutor.Nome &&
                   Cpf == condutor.Cpf &&
                   Cnh == condutor.Cnh &&
                   DataValidadeCnh == condutor.DataValidadeCnh &&
                   Email == condutor.Email &&
                   Telefone == condutor.Telefone &&
                   Endereco == condutor.Endereco;
        }

        public override string ToString()
        {
            return $"{Nome} - {Cpf}";
        }
    }
}
