using LocadoraDeVeiculos.WinFormsApp.Compartilhado;

namespace LocadoraDeVeiculos.WinFormsApp.ModuloVeiculo
{
    public class ConfiguracaoToolBoxVeiculo : ConfiguracaoToolboxBase
    {
        public override string TipoMenu => "Cadastro de Veículo";

        public override string TooltipInserir { get { return "Inserir um novo veículo"; } }

        public override string TooltipEditar { get { return "Editar um veículo existente"; } }

        public override string TooltipExcluir { get { return "Excluir um veículo existente"; } }

        public override string TooltipDevolver => "Botão especifíco para locações";

        public override string TooltipGerarPdf => "Botão especifíco para locações";
    }
}
