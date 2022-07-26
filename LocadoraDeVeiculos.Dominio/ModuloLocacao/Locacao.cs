using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.Dominio.ModuloTaxa;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloLocacao
{
    public class Locacao : EntidadeBase<Locacao>
    {
        public Locacao()
        {
        }

        public Funcionario Funcionario { get; set; }
        public Condutor Condutor { get; set; }
        public Veiculo Veiculo { get; set; }
        public PlanoDeCobranca Plano { get; set; }
        public List<Taxa> Taxas { get; set; }
        public DateTime DataLocacao { get; set; }
        public int KmCarro { get; set; }
        public bool EstaAtiva { get; set; }

        public Locacao(Funcionario funcionario, Condutor condutor, Veiculo veiculo, PlanoDeCobranca plano, List<Taxa> taxas, DateTime dataLocacao, int kmCarro, bool estaAtiva)
        {
            Funcionario = funcionario;
            Condutor = condutor;
            Veiculo = veiculo;
            Plano = plano;
            Taxas = taxas;
            DataLocacao = dataLocacao;
            KmCarro = kmCarro;
            EstaAtiva = estaAtiva;
        }

        public override bool Equals(object? obj)
        {
            return obj is Locacao locacao &&
                   Id.Equals(locacao.Id) &&
                   EqualityComparer<Funcionario>.Default.Equals(Funcionario, locacao.Funcionario) &&
                   EqualityComparer<Condutor>.Default.Equals(Condutor, locacao.Condutor) &&
                   EqualityComparer<Veiculo>.Default.Equals(Veiculo, locacao.Veiculo) &&
                   EqualityComparer<PlanoDeCobranca>.Default.Equals(Plano, locacao.Plano) &&
                   EqualityComparer<List<Taxa>>.Default.Equals(Taxas, locacao.Taxas) &&
                   DataLocacao == locacao.DataLocacao &&
                   KmCarro == locacao.KmCarro &&
                   EstaAtiva == locacao.EstaAtiva;
        }

        public Locacao Clonar()
        {
            return MemberwiseClone() as Locacao;
        }
    }
}
