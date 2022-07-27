using LocadoraDeVeiculos.Dominio.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloCliente
{
    public class Cliente : EntidadeBase<Cliente>
    {

        public Cliente()
        {
        }

        public Cliente(string nome, string email, string endereco, string cpf, string cnpj, string telefone)
        {
            Nome = nome;
            Email = email;
            Endereco = endereco;    
            Cpf = cpf;
            Cnpj = cnpj;
            Telefone = telefone;
        }

        public string Nome { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
        public string Cpf { get; set; }
        public string Cnpj { get; set; }
        public string Telefone { get; set; }

        public Cliente Clonar()
        {
            return MemberwiseClone() as Cliente;
        }

        public override bool Equals(object? obj)
        {
            return obj is Cliente cliente &&
                   Id == cliente.Id &&
                   Nome == cliente.Nome &&
                   Email == cliente.Email &&
                   Endereco == cliente.Endereco &&
                   Cpf == cliente.Cpf &&
                   Cnpj == cliente.Cnpj &&
                   Telefone == cliente.Telefone;
        }

        public override string ToString()
        {
            return $"{Nome} - {Cpf}";
        }
    }
}