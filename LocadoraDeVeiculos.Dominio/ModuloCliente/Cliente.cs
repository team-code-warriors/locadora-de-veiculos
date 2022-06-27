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

        public Cliente(string nome, string email, string endereco, string cpf, string telefone, string cnh)
        {
            Nome = nome;
            Email = email;
            Endereco = endereco;    
            Cpf = cpf;
            Telefone = telefone;
            Cnh = cnh;
        }

        public string Nome { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }
        public string Cnh { get; set; }
    }
}