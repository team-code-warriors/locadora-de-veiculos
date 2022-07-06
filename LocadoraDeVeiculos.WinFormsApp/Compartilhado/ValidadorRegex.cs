using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.WinFormsApp.Compartilhado
{
    public class ValidadorRegex
    {
        public bool ApenasNumerosInteirosOuDecimais(string numero)
        {
            bool estaValido = System.Text.RegularExpressions.Regex.IsMatch(numero, @"^[+-]?([0-9]+\.?[0-9]*|\.[0-9]+)$");

            return estaValido;
        }
        public bool ApenasNumerosInteiros(string numero)
        {
            bool estaValido = System.Text.RegularExpressions.Regex.IsMatch(numero, @"/^[0-9]{1,}$/");

            return estaValido;
        }

        public bool ApenasLetras(string letra)
        {
            bool estaValido = System.Text.RegularExpressions.Regex.IsMatch(letra, @"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ ]*$");

            return estaValido;
        }

        public bool ApenasLetrasENumeros(string letraENumero)
        {
            bool estaValido = System.Text.RegularExpressions.Regex.IsMatch(letraENumero, @"^[0-9A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ ]*$");

            return estaValido;
        }
  
    }
}
