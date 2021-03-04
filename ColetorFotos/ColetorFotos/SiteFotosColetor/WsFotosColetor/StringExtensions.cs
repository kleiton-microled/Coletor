using System;
using System.Data.SqlTypes;
using System.Text;
using System.Text.RegularExpressions;

namespace WsFotosColetor.Extensions
{
    public static class StringExtensions
    {
        public static int ToInt(this string valor)
        {
            if (Int32.TryParse(valor, out _))
                return Convert.ToInt32(valor);

            return 0;
        }

        public static decimal ToDecimal(this string valor)
        {
            if (Decimal.TryParse(valor, out _))
                return Convert.ToDecimal(valor);

            return 0;
        }

        public static double ToDouble(this string valor)
        {
            if (Double.TryParse(valor, out _))
                return Convert.ToDouble(valor);

            return 0;
        }

        public static bool ToBoolean(this string valor)
        {
            if (Boolean.TryParse(valor, out _))
                return true;

            return false;
        }

        public static byte[] ToByteArray(this string texto)
        {
            return Encoding.ASCII.GetBytes(texto);
        }

        public static string RemoverCaracteresEspeciais(this string valor)
        {
            return Regex.Replace(valor ?? string.Empty, "[^0-9a-zA-Z]+", "");
        }
    }
}