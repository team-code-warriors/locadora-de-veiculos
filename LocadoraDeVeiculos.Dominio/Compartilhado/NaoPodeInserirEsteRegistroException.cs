namespace LocadoraDeVeiculos.Dominio.Compartilhado
{
    public class NaoPodeInserirEsteRegistroException : Exception
    {
        public NaoPodeInserirEsteRegistroException(Exception ex) : base("", ex)
        {

        }
    }
}
