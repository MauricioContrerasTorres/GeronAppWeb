using Macaner.GeronAppWeb.Service.Interface;
using Macaner.GeronAppWeb.Shared.DTO;
using System.ComponentModel.DataAnnotations;

namespace Macaner.GeronAppWeb.Client.Web.Models
{
    public class PacienteViewModel
    {
        private readonly IComunaService _comunaService;
        private readonly IMedicamentoService _medicamentoService;
        private readonly IAlergiaService _alergiaService;
        private readonly ISexoService _sexoService;

        public string Foto { get; set; } /* FOTO !!!!!!!! */
   

        [Required(ErrorMessage = "La Comuna es obligatoria")]
        public int IdComuna { get; set; }
        public List<DropDownDTO> ListaComunas { get; set; }              
        public List<DropDownDTO> ListaMedicamentosAlergicos { get; set; }
        public List<DropDownDTO> ListaMedicamentosAlergicosSeleccionados { get; set; } = new List<DropDownDTO>();  
        public List<DropDownDTO> ListaAlergias { get; set; }
        public List<DropDownDTO> ListaAlergiasSeleccionadas { get; set; } = new List<DropDownDTO>();
        
        public int IdSexo { get; set; }
        public List<DropDownDTO> ListaSexo { get; set; }       

        [Required(ErrorMessage = "El númwero de rut es obligatorio")]
        public string RUT { get; set; }

        [Required(ErrorMessage = "El dígito verificador es obligatorio")]
        public string DV { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El Apellido Paterno es obligatorio")]
        public string ApellidoPaterno { get; set; }

        [Required(ErrorMessage = "El Apellido Materno es obligatorio")]
        public string ApellidoMaterno { get; set; }

        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria")]
        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "La edad es obligatoria")]
        public int Edad { get; set; }

        [Required(ErrorMessage = "La dirección es obligatoria")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "El número de telefono principal es obligatorio")]
        public string TelefonoContactoPrincipal { get; set; }
        public string TelefonoContactoSecundario { get; set; }

        [Required(ErrorMessage = "El email de contacto principal es obligatorio")] 
        public string EmailContactoPrincipal { get; set; }
        public string EmailContactoSecundario { get; set; }

        [Required(ErrorMessage = "La fecha de Ingreso es obligatoria")]
        public DateTime FechaIngreso { get; set; }

        public int IdAsistente { get; set; }
        public string NombreAsistente { get; set; }

        public PacienteViewModel(IComunaService comunaService, IMedicamentoService medicamentoService, IAlergiaService alergiaService, ISexoService sexoService)
        {
            _comunaService = comunaService;
            _alergiaService = alergiaService;
            _medicamentoService = medicamentoService;
            _sexoService = sexoService;
        }

        public async Task InitializeAsync()
        {
            await CreateSelects();
            FechaIngreso = DateTime.Today;
        }

        private async Task CreateSelects()
        {
            ListaComunas = await _comunaService.GetDropDownAsync();
            ListaAlergias = await _alergiaService.GetDropDownAsync();
            ListaMedicamentosAlergicos = await _medicamentoService.GetDropDownAsync();
            ListaSexo = await _sexoService.GetDropDownAsync();
        }
    }
}
