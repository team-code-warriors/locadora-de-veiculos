using LocadoraDeVeiculos.WinFormsApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.WinFormsApp.ModuloLocacao
{
    public class ConfiguracaoToolboxLocacao : ConfiguracaoToolboxBase
    {
        public override string TipoMenu => "Cadastro de Locações";

        public override string TooltipInserir { get { return "Inserir uma nova locação"; } }

        public override string TooltipEditar { get { return "Editar uma locação existente"; } }

        public override string TooltipExcluir { get { return "Excluir uma locação existente"; } }

        public override string TooltipDevolver { get { return "Inserir uma devolução"; } }

        public override string TooltipGerarPdf { get { return "Gerar PDF de uma locação/devolução"; } }

        public virtual bool DevolverHabilitado { get { return true; } }

        public virtual bool GerarPdfHabilitado { get { return true; } }
    }
}
