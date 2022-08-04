using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.Dominio.ModuloTaxa;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;

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
        public DateTime DataDevolucao { get; set; }
        public int KmCarro { get; set; }
        public decimal Valor { get; set; }
        public StatusLocacaoEnum Status { get; set; }

        public Locacao(Funcionario funcionario, Condutor condutor, Veiculo veiculo, PlanoDeCobranca plano, List<Taxa> taxas, DateTime dataLocacao, DateTime dataDevolucao, int kmCarro, StatusLocacaoEnum status)
        {
            Funcionario = funcionario;
            Condutor = condutor;
            Veiculo = veiculo;
            Plano = plano;
            Taxas = taxas;
            DataLocacao = dataLocacao;
            DataDevolucao = dataDevolucao;
            KmCarro = kmCarro;
            Status = status;
        }

        public Locacao Clonar()
        {
            return MemberwiseClone() as Locacao;
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
                   DataDevolucao == locacao.DataDevolucao &&
                   KmCarro == locacao.KmCarro &&
                   Status == locacao.Status;
        }
    }
}
