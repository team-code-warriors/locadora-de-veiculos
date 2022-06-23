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
    }
}
