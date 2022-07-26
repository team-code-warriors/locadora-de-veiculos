using LocadoraDeVeiculos.WinFormsApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.WinFormsApp.ModuloCondutor
{
    public class ConfiguracaoToolboxCondutor : ConfiguracaoToolboxBase
    {
        public override string TipoMenu => "Cadastro de Condutores";

        public override string TooltipInserir => "Inserir um novo condutor";

        public override string TooltipEditar => "Editar um condutor existente";

        public override string TooltipExcluir => "Excluir um condutor existente";

        public override string TooltipDevolver => "Botão especifíco para devoluções";

        public override string TooltipGerarPdf => "Botão especifíco para devoluções";
    }
}
