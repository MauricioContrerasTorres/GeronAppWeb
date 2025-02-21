using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Macaner.GeronAppWeb.Shared.DTO
{
    public class ListaPacienteDTO
    {
        public int IdPaciente { get; set; }
        public string RUT { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public int Edad { get; set; }
        public string Sexo { get; set; }
    }
}
