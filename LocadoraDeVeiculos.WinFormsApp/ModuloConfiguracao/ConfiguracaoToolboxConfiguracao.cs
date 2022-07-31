using LocadoraDeVeiculos.WinFormsApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.WinFormsApp.ModuloConfiguracao
{
    public class ConfiguracaoToolboxConfiguracao : ConfiguracaoToolboxBase
    {
        public override string TipoMenu => "Configurações";

        public override string TooltipInserir => "";

        public override string TooltipEditar => "";

        public override string TooltipExcluir => "";

        public override string TooltipDevolver => "";

        public override string TooltipGerarPdf => "";

        public override bool InserirHabilitado => false;

        public override bool EditarHabilitado => false;

        public override bool ExcluirHabilitado => false;
    }
}
