using Macaner.GeronAppWeb.Service.Interface;
using Macaner.GeronAppWeb.Shared.DTO;

namespace Macaner.GeronAppWeb.Client.Web.Models
{
    public class ProfilePacienteViewModel
    {
        private readonly IComunaService _comunaService;
        private readonly IMedicamentoService _medicamentoService;
        private readonly IAlergiaService _alergiaService;
        private readonly ISexoService _sexoService;
        private readonly IPacienteService _pacienteService;

        public int IdPaciente { get; set; }
        public string Foto { get; set; }
        public byte[] FotoArchivo { get; set; }
        public string RUT { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int IdSexo { get; set; }
        public string Sexo { get; set; }
        public int Edad { get; set; }
        public string Direccion { get; set; }

        public int IdComuna {get;set;}
        public string Comuna { get; set; }
        public string TelefonoContactoPrincipal { get; set; }
        public string TelefonoContactoSecundario { get; set; }
        public string EmailContactoPrincipal { get; set; }
        public string EmailContactoSecundario { get; set; }

        // Datos para la institución
        public DateTime FechaIngreso { get; set; }
        public int IdAsistente { get; set; }
        public string NombreAsistente { get; set; }
        public List<DropDownDTO> ListadoAlergiasPaciente { get; set; }
        public List<DropDownDTO> ListadoAlergiasMedicamentosPaciente { get; set; }


        #region Signos Vitales

        public float Estatura { get; set; }
        public float Peso { get; set; }
        public float Presion { get; set; }
        public float IndiceMasa { get; set; }
        public float FrecuenciaCardiaca { get; set; }
        public float Temperatura { get; set; }

        #endregion


        public ProfilePacienteViewModel(IComunaService comunaService, IMedicamentoService medicamentoService, IAlergiaService alergiaService, ISexoService sexoService, IPacienteService pacienteService)
        {
            _comunaService = comunaService;
            _alergiaService = alergiaService;
            _medicamentoService = medicamentoService;
            _sexoService = sexoService;
            _pacienteService = pacienteService;
        }

        public async Task InitializeAsync()
        {
            await CreateSelects();
            //FechaIngreso = DateTime.Today;
        }

        private async Task CreateSelects()
        {
            var respuestaComuna = await _comunaService.GetDropDownAsync();
            Comuna = respuestaComuna.Where(x => x.Id == IdComuna).SingleOrDefault().Descripcion;

            var respuestaSexo = await _sexoService.GetDropDownAsync();
            Sexo = respuestaSexo.Where(x => x.Id == IdSexo).SingleOrDefault().Descripcion;

            var respuestaAlergia = await _pacienteService.GetAlergiasAsync(IdPaciente);
            var listaAlergias = respuestaAlergia.Data;

            ListadoAlergiasPaciente = await _alergiaService.GetDropDownAsync();
            ListadoAlergiasPaciente = ListadoAlergiasPaciente.Where(x => listaAlergias.Select(t=> t.IdAlergia).Contains(x.Id )).ToList();

            var respuestaAlergiaMedicamento = await _pacienteService.GeAlergiasMedicamentosPacientesAsync(IdPaciente);
            var listaAlergiasMedicamentos = respuestaAlergiaMedicamento.Data;

            ListadoAlergiasMedicamentosPaciente = await _medicamentoService.GetDropDownAsync();
            ListadoAlergiasMedicamentosPaciente = ListadoAlergiasMedicamentosPaciente.Where(x => listaAlergiasMedicamentos.Select(t => t.IdMedicamento).Contains(x.Id)).ToList();

        }
    }
}
