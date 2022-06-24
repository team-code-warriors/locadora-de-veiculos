using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.WinFormsApp.Compartilhado
{
    public class ValidadorRegex
    {
        public bool ApenasNumeros(string numero)
        {
            bool estaValido = System.Text.RegularExpressions.Regex.IsMatch(numero, @"[+-]?\d+(\.\d+)?([Ee][+-]?\d+)?");

            return estaValido;
        }

        public bool ApenasLetras(string letra)
        {
            bool estaValido = System.Text.RegularExpressions.Regex.IsMatch(letra, @"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ ]*$");

            return estaValido;
        }
    }
}
