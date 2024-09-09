using System.Text.RegularExpressions;

namespace Buffet_Consola
{
    public static class Validadora
    {
        public static bool ValidarStringNombre(string cadenaIngresada)
        {
            Regex validarNombre = new Regex(@"^[a-zA-Z]+$");
            return !validarNombre.IsMatch(cadenaIngresada);
        }
    }
}