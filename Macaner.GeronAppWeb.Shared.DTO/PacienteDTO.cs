using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Macaner.GeronAppWeb.Shared.DTO
{
    public class PacienteDTO
    {
        public int IdPaciente { get; set; }        
        public string Foto { get; set; }
        public byte[] FotoArchivo { get; set; }
        public int RUT { get; set; }
        public string DV { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int IdSexo { get; set; }
        public int Edad { get; set; }
        public string Direccion { get; set; }
        public int IdComuna { get; set; }
        public string NombreComuna { get; set; }
        public string TelefonoContactoPrincipal { get; set; }
        public string TelefonoContactoSecundario { get; set; }
        public string EmailContactoPrincipal { get; set; }
        public string EmailContactoSecundario { get; set; }

        // Datos para la institución
        public DateTime FechaIngreso { get; set; }
        public int IdAsistente { get; set; }
        public string NombreAsistente { get; set; }
        public List<int> ListadoAlergias { get; set; }
        public List<int> ListadoMedicamentosAlergia { get; set; }        
    }
}
