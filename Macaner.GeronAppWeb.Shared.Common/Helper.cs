using Macaner.GeronAppWeb.Shared.DTO;
using Macaner.GeronAppWeb.Shared.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Macaner.GeronAppWeb.Shared.Common
{
    public class Helper : IHelper
    {
        public byte[] ConvertirAArchivo(string archivo)
        {
            var base64Data = archivo.Split(',')[1];
            return Convert.FromBase64String(base64Data);
        }

        public bool EsRutValido(string RUT, string DV)
        {
            return ValidarRut($"{RUT}-{DV}");
        }

        private bool ValidarRut(string rutCompleto)
        {
            if (string.IsNullOrWhiteSpace(rutCompleto))
                return false;

            rutCompleto = rutCompleto.Replace(".", "").Replace("-", "").Trim();
            if (rutCompleto.Length < 2)
                return false;

            string rut = rutCompleto[..^1];
            char dvIngresado = rutCompleto[^1];

            if (!int.TryParse(rut, out int rutNumerico))
                return false;

            char dvCalculado = CalcularDV(rutNumerico);
            return dvIngresado == dvCalculado;
        }

        private char CalcularDV(int rut)
        {
            int suma = 0, multiplicador = 2;

            while (rut > 0)
            {
                suma += (rut % 10) * multiplicador;
                rut /= 10;
                multiplicador = multiplicador == 7 ? 2 : multiplicador + 1;
            }

            int resto = 11 - (suma % 11);
            return resto == 11 ? '0' : resto == 10 ? 'K' : resto.ToString()[0];
        }
    }
}
