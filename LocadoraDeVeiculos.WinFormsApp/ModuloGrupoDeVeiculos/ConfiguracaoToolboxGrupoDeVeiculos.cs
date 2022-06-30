using LocadoraDeVeiculos.WinFormsApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.WinFormsApp.ModuloGrupoDeVeiculos
{
    public class ConfiguracaoToolboxGrupoDeVeiculos : ConfiguracaoToolboxBase
    {
        public override string TipoMenu => "Cadastro de Grupo de Veículos";

        public override string TooltipInserir { get { return "Inserir um novo grupo"; } }

        public override string TooltipEditar { get { return "Editar um grupo existente"; } }

        public override string TooltipExcluir { get { return "Excluir um grupo existente"; } }
    }
}
