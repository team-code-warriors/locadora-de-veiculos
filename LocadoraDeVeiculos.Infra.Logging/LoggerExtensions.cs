using LocadoraDeVeiculos.Infra.Configs;
using Serilog;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.Logging
{
    public static class LoggerExtensions
    {
        public static void ConfigurarLogEmArquivo(this ILogger log)
        {
            var configuracao = new ConfiguracaoAplicacao();

            var diretorioSaida = configuracao.ConfiguracaoLogs.DiretorioSaida;


            Serilog.Log.Logger = new LoggerConfiguration()
                   .MinimumLevel.Debug()
                   .WriteTo.File(diretorioSaida + "/log.txt",
               rollingInterval: RollingInterval.Day,
               outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
               .CreateLogger();
        }

        public static void ConfigurarLogEmWeb(this ILogger log)
        {
            Serilog.Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Seq("http://localhost:5341/")
                .CreateLogger();
        }
    }
}
