using Microsoft.Extensions.Configuration;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.Logging
{
    public class ConfiguracaoLogs
    {
        public static void ConfigurarEscritaLogs()
        {
            var configuracao = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("ConfiguracaoAplicacao.json")
                .Build();

            var diretorioSaida = configuracao
                .GetSection("ConfiguracaoLogs")
                .GetSection("DiretorioSaida")
                .Value;

            var configuracaoLogEmArquivo = new LoggerConfiguration()
                   .MinimumLevel.Debug()
                   .WriteTo.File(diretorioSaida + "/log.txt",
               rollingInterval: RollingInterval.Day,
               outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
               .CreateLogger();

            var configuracaoLogNaWeb = new LoggerConfiguration()
                   .MinimumLevel.Debug()
                   .WriteTo.Seq("http://localhost:5341");

            Log.Logger = configuracaoLogNaWeb.CreateLogger();
        }
    }
}
