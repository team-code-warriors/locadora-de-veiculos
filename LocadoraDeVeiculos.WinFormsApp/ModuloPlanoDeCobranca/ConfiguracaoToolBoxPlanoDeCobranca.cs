using LocadoraDeVeiculos.WinFormsApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.WinFormsApp.ModuloPlanoDeCobranca
{
    public class ConfiguracaoToolboxPlanoDeCobranca : ConfiguracaoToolboxBase
    {
        public override string TipoMenu => "Cadastro de Plano de Cobranças";

        public override string TooltipInserir { get { return "Inserir um novo plano"; } }

        public override string TooltipEditar { get { return "Editar um plano existente"; } }

        public override string TooltipExcluir { get { return "Excluir um plano existente"; } }
    }
}
