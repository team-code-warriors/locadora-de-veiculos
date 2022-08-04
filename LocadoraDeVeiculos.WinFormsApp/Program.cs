using LocadoraDeVeiculos.Infra.Logging;
using LocadoraDeVeiculos.Infra.Orm.Compartilhado;
using LocadoraDeVeiculos.WinFormsApp.Compartilhado.ServiceLocator;

namespace LocadoraDeVeiculos.WinFormsApp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            MigradorBancoDadosLocadoraDeVeiculos.AtualizarBancoDados();
            ConfiguracaoLogs.ConfigurarEscritaLogs();
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new TelaMenuPrincipal(new ServiceLocatorComAutofac()));

        }
    }
    
}