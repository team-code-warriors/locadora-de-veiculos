using LocadoraDeVeiculos.WinFormsApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.WinFormsApp.ModuloTaxa
{
    public class ConfiguracaoToolboxTaxa : ConfiguracaoToolboxBase
    {
        public override string TipoMenu => "Cadastro de Taxas";

        public override string TooltipInserir { get { return "Inserir uma nova taxa"; } }

        public override string TooltipEditar { get { return "Editar uma taxa existente"; } }

        public override string TooltipExcluir { get { return "Excluir uma taxa existente"; } }

        public override string TooltipDevolver => "Botão especifíco para devoluções";

        public override string TooltipGerarPdf => "Botão especifíco para devoluções";

    }
}
