using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Macaner.GeronAppWeb.Shared.Interface
{
    public interface IHelper
    {
        byte[] ConvertirAArchivo(string archivo);

        bool EsRutValido(string RUT, string DV);
    }
}
