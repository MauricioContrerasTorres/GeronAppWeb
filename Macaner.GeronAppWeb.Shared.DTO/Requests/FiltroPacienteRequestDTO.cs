using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Macaner.GeronAppWeb.Shared.DTO.Requests
{
    public class FiltroPacienteRequestDTO
    {
        public int IdPaciente { get; set; }
        public int IdComuna { get; set; }
        public string Nombre { get; set; }
        public int RUT { get; set; }
    }
}
