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
            Log.Logger = new LoggerConfiguration()
               .MinimumLevel.Debug()
               .WriteTo.File("logs/log.txt",
               rollingInterval: RollingInterval.Day,
               outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
               .CreateLogger();
        }
    }
}
