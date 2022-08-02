namespace LocadoraDeVeiculos.Infra.BancoDeDados.Tests.Compartilhado
{
    public class BaseRepositorioOrmTest
    {
        protected LocadoraDeVeiculosDbContext DbContext;
        protected IServiceLocator locator;
        protected ServicoPlanoDeCobranca servicoPlano;
        protected ServicoLocacao servicoLocacao;
        protected ServicoVeiculo servicoVeiculo;
        protected ServicoGrupoDeVeiculo servicoGrupo;
        protected ServicoTaxa servicoTaxa;
        protected ServicoFuncionario servicoFuncionario;
        protected ServicoCliente servicoCliente;
        protected ServicoCondutor servicoCondutor;

        public BaseRepositorioOrmTest()
        {
            Log.Logger.ConfigurarLogEmWeb();
            var configuracao = new ConfiguracaoAplicacao();
            var db = new LocadoraDeVeiculosDbContext(Convert.ToString(configuracao.ConnectionStrings));

            locator = new ServiceLocatorComAutofac();

            servicoCliente.locator.GetServico<Cliente, ServicoCliente, ValidadorCliente>();

            MigradorBancoDadosLocadoraDeVeiculos.AtualizarBancoDados();

            db.Database.ExecuteSqlRaw("DELETE FROM TBLOCACAO");
            db.Database.ExecuteSqlRaw("DELETE FROM TBPLANODECOBRANCA");
            db.Database.ExecuteSqlRaw("DELETE FROM TBCONDUTOR");
            db.Database.ExecuteSqlRaw("DELETE FROM TBCLIENTE");
            db.Database.ExecuteSqlRaw("DELETE FROM TBTAXA");
            db.Database.ExecuteSqlRaw("DELETE FROM TBVEICULO");
            db.Database.ExecuteSqlRaw("DELETE FROM TBGRUPODEVEICULOS");
            db.Database.ExecuteSqlRaw("DELETE FROM TBFUNCIONARIO");
        }
    }
}
