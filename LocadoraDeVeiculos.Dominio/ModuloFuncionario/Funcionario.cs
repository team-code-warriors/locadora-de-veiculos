using LocadoraDeVeiculos.Dominio.Compartilhado;

namespace LocadoraDeVeiculos.Dominio.ModuloFuncionario
{
    public class Funcionario : EntidadeBase<Funcionario>
    {
        public Funcionario()
        {

        }

        public string Nome { get; set; }
        public double Salario { get; set; }
        public DateTime DataAdmissao { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string TipoPerfil { get; set; }

        public Funcionario(string nome, double salario, DateTime dataAdmissao, string login, string senha, string tipoPerfil)
        {
            Nome = nome;
            Salario = salario;
            DataAdmissao = dataAdmissao;
            Login = login;
            Senha = senha;
            TipoPerfil = tipoPerfil;
        }

        public override bool Equals(object? obj)
        {
            return obj is Funcionario funcionario &&
                   Id == funcionario.Id &&
                   Nome == funcionario.Nome &&
                   Salario == funcionario.Salario &&
                   DataAdmissao == funcionario.DataAdmissao &&
                   Login == funcionario.Login &&
                   Senha == funcionario.Senha &&
                   TipoPerfil == funcionario.TipoPerfil;
        }
        public Funcionario Clonar()
        {
            return MemberwiseClone() as Funcionario;
        }

        public override string ToString()
        {
            return $"{Nome} - {Login}";
        }
    }
}
