using LocadoraDeVeiculos.Infra.Logging;
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
            ConfiguracaoLogs.ConfigurarEscritaLogs();
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var serviceLocatorAutofac = new ServiceLocatorComAutofac();

            Application.Run(new TelaMenuPrincipal(serviceLocatorAutofac));

        }
    }
    
}