using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Macaner.GeronAppWeb.Shared.DTO
{
    public class AlergiaMedicamentoPacienteDTO
    {
        public int IdAlergiaMedicamentoPaciente { get; set; }
        public int IdPaciente { get; set; }
        public int IdMedicamento { get; set; }
    }
}
