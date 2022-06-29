using LocadoraDeVeiculos.WinFormsApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.WinFormsApp.ModuloCliente
{
    public class ConfiguracaoToolBoxCliente : ConfiguracaoToolboxBase
    {
        public override string TipoMenu => "Cadastro de Clientes";

        public override string TooltipInserir => "Inserir um novo cliente";

        public override string TooltipEditar => "Editar um cliente existente";

        public override string TooltipExcluir => "Excluir um cliente existente";
    }
}
