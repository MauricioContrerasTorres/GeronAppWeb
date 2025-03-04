using Macaner.GeronAppWeb.Client.Web.Models;
using Macaner.GeronAppWeb.Service.Interface;
using Macaner.GeronAppWeb.Shared.DTO;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;


namespace Macaner.GeronAppWeb.Client.Web.Pages.Ficha.Paciente
{
    public partial class ProfilePaciente
    {
        [Parameter]
        public int? idPaciente { get; set; }

        [Inject] public IJSRuntime jsRuntime { get; set; } = default!;
        [Inject] public IPacienteService _pacienteService { get; set; } = default!;
        [Inject] public IComunaService _comunaService { get; set; }
        [Inject] public IMedicamentoService _medicamentoService { get; set; } = default!;
        [Inject] public IAlergiaService _alergiaService { get; set; } = default!;
        [Inject] public ISexoService _sexoService { get; set; } = default!;
        [Inject] public LoadingService Loading { get; set; } = default!;

        private PacienteDTO _paciente { get; set; } = new PacienteDTO(); // Inicializar
        private ProfilePacienteViewModel profilePaciente { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Loading.SetLoading(true);
            if (idPaciente == null)
            {
                await jsRuntime.InvokeVoidAsync("ShowErrorAlert", "Error: idPaciente es NULL");
                return;
            }

            var respuesta = await _pacienteService.GetAsync(idPaciente.Value);
            if (respuesta == null || respuesta.Data == null)
            {
                await jsRuntime.InvokeVoidAsync("ShowErrorAlert", "Error: No se encontró el paciente.");
                return;
            }

            _paciente = respuesta.Data;
            profilePaciente = new ProfilePacienteViewModel(_comunaService, _medicamentoService, _alergiaService, _sexoService, _pacienteService);
            await MapearDTOAViewModel();
            Loading.SetLoading(false);
            StateHasChanged(); 
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await MostrarFotoPaciente(_paciente.FotoArchivo);
        }

        protected async Task MostrarFotoPaciente(byte[] foto)
        {
            if (foto == null || foto.Length == 0)
            {
               // await jsRuntime.InvokeVoidAsync("ShowErrorAlert", "Error: La foto está vacía.");
                return;
            }

            string base64Image = $"data:image/png;base64,{Convert.ToBase64String(foto)}";
            _paciente.Foto = base64Image;
            await jsRuntime.InvokeVoidAsync("drawImageOnCanvasWithoutVideo", "canvas", base64Image);
        }

        protected async Task MapearDTOAViewModel() {

            profilePaciente.Nombre = _paciente.Nombre + " "+ _paciente.ApellidoPaterno +" "+ _paciente.ApellidoMaterno;
            profilePaciente.IdComuna = _paciente.IdComuna;
            profilePaciente.Direccion = _paciente.Direccion;            
            profilePaciente.Edad = _paciente.Edad;
            profilePaciente.EmailContactoPrincipal = _paciente.EmailContactoPrincipal;
            profilePaciente.EmailContactoSecundario = _paciente.EmailContactoSecundario;
            profilePaciente.FechaIngreso = _paciente.FechaIngreso;
            profilePaciente.FechaNacimiento = _paciente.FechaNacimiento;
            profilePaciente.Foto = _paciente.Foto;
            profilePaciente.FotoArchivo = _paciente.FotoArchivo;
            profilePaciente.IdComuna = _paciente.IdComuna;
            profilePaciente.IdPaciente = _paciente.IdPaciente;
            profilePaciente.IdSexo = _paciente.IdSexo;
            //profilePaciente.ListadoAlergias = _paciente.ListadoAlergias;
            //profilePaciente.ListadoMedicamentosAlergia = _paciente.ListadoMedicamentosAlergia;
      
            profilePaciente.RUT = _paciente.RUT.ToString()+"-"+_paciente.DV;
            profilePaciente.Sexo = profilePaciente.Sexo;
            profilePaciente.TelefonoContactoPrincipal = _paciente.TelefonoContactoPrincipal;
            profilePaciente.TelefonoContactoSecundario = _paciente.TelefonoContactoSecundario;
            await profilePaciente.InitializeAsync();
        }
    }
}
