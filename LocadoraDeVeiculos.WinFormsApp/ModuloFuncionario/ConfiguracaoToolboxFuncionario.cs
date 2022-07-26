using LocadoraDeVeiculos.WinFormsApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.WinFormsApp.ModuloFuncionario
{
    public class ConfiguracaoToolboxFuncionario : ConfiguracaoToolboxBase
    {
        public override string TipoMenu => "Cadastro de Funcionários";

        public override string TooltipInserir { get { return "Inserir um novo funcionário"; } }

        public override string TooltipEditar { get { return "Editar um funcionário existente"; } }

        public override string TooltipExcluir { get { return "Excluir um funcionário existente"; } }

        public override string TooltipDevolver => "Botão especifíco para devoluções";

        public override string TooltipGerarPdf => "Botão especifíco para devoluções";
    }
}
