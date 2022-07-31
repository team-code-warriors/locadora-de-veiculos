//using Microsoft.Extensions.Configuration;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace LocadoraDeVeiculos.Infra.Configs
//{
//    public class ConfiguracaoAplicacao
//    {
//        public ConfiguracaoAplicacao()
//        {
//            IConfiguration configuracao = new ConfigurationBuilder()
//            .SetBasePath(Directory.GetCurrentDirectory())
//            .AddJsonFile("ConfiguracaoAplicacao.json")
//            .Build();

//            var connectionString = configuracao.GetConnectionString("SqlServer");
//            ConnectionStrings = new ConnectionStrings { SqlServer = connectionString };

//            var diretorioSaida = configuracao
//                .GetSection("ConfiguracaoLogs")
//                .GetSection("DiretorioSaida")
//                .Value;
//            ConfiguracaoLogs = new ConfiguracaoLogs { DiretorioSaida = diretorioSaida };

//            var gasolina = configuracao
//             .GetSection("ConfiguracaoPrecoCombustivel")
//             .GetSection("PrecoGasolina")
//             .Value;

//            ConfiguracaoPrecoGasolina = new ConfiguracaoPrecoGasolina
//            {
//                PrecoGasolina = gasolina,
//            };
//        }


//        public ConfiguracaoLogs ConfiguracaoLogs { get; set; }

//        public ConnectionStrings ConnectionStrings { get; set; }

//        public ConfiguracaoPrecoGasolina ConfiguracaoPrecoGasolina { get; set; }

//    }

//    public class ConfiguracaoLogs
//    {
//        public string DiretorioSaida { get; set; }
//    }

//    public class ConnectionStrings
//    {
//        public string SqlServer { get; set; }
//    }

//    public class ConfiguracaoPrecoGasolina
//    {
//        public decimal PrecoGasolina { get; set; }
 
//    }
//}
