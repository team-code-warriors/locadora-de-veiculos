using LocadoraDeVeiculos.WinFormsApp.Compartilhado;

namespace LocadoraDeVeiculos.WinFormsApp.ModuloLocacao
{
    public class ConfiguracaoToolboxLocacao : ConfiguracaoToolboxBase
    {
        public override string TipoMenu => "Cadastro de Locações";

        public override string TooltipInserir { get { return "Inserir uma nova locação"; } }

        public override string TooltipEditar { get { return "Não é possível editar uma locação existente"; } }

        public override string TooltipExcluir { get { return "Excluir uma locação existente"; } }

        public override string TooltipDevolver { get { return "Inserir uma devolução"; } }

        public override string TooltipGerarPdf { get { return "Gerar PDF de uma locação/devolução"; } }

        public override bool EditarHabilitado { get { return false; } }

        public override bool DevolverHabilitado { get { return true; } }

        public override bool GerarPdfHabilitado { get { return true; } }
    }
}
