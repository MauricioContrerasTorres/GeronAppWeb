using Macaner.GeronAppWeb.Client.Web.Layout;
using Macaner.GeronAppWeb.Shared.Common;
using Macaner.GeronAppWeb.Service.Interface;
using Macaner.GeronAppWeb.Shared.DTO.Requests;
using Macaner.GeronAppWeb.Shared.DTO;
using Microsoft.JSInterop;
using Macaner.GeronAppWeb.Service.ApiServices;
using Microsoft.AspNetCore.Components;

namespace Macaner.GeronAppWeb.Client.Web.Pages.Ficha.Paciente
{    
    public partial class IndexPaciente
    {
        [Inject] public IPacienteService _pacienteService { get; set; } = default!;
        [Inject] public IJSRuntime jsRuntime { get; set; } = default!;
        [Inject] public LoadingService Loading { get; set; } = default!;

        private bool ordenAscendente = true;
        private string columnaOrden = "Id";

        private List<ListaPacienteDTO> _listaPacientes = new List<ListaPacienteDTO>();
        private FiltroPacienteRequestDTO request = new FiltroPacienteRequestDTO();

        private string textoBusqueda { get; set; }

        private bool estaProcesando { get; set; } = false;

        private int? BorrarIdPaciente { get; set; } = null;

        private string mensaje { get; set; }        

        protected override async Task OnInitializedAsync()
        {
            Loading.SetLoading(true);
            var resultado = await _pacienteService.GetListaPacientesAsync(request);

            if (resultado.IsSuccess)
            {
                _listaPacientes = resultado.Data;
            }
            
            Loading.SetLoading(false);
        }

        protected async Task Borrar(int idPaciente)
        {
            BorrarIdPaciente = idPaciente;
            mensaje = "¿Está seguro de borrar el paciente ?";
            await jsRuntime.InvokeVoidAsync("ShowAlertConfirm");
        }

        protected async Task Buscar()
        {
            var resultado = await _pacienteService.GetListaPacientesAsync(request);

            if (resultado.IsSuccess)
            {
                _listaPacientes = resultado.Data;
            }
        }

        protected async Task Click_ConfirmarBorrado(bool confirmado)
        {

            estaProcesando = true;
            Response<bool> fueBorrado;
            if (confirmado)
            {
                fueBorrado = await _pacienteService.DeleteAsync(BorrarIdPaciente.Value);
                if (fueBorrado.Data)
                {
                    var response = await _pacienteService.GetListaPacientesAsync(request);
                    _listaPacientes = response.Data;
                    await jsRuntime.InvokeVoidAsync("ShowSuccessAlert", "Eliminación de Paciente Satisfactoria");
                    await jsRuntime.InvokeVoidAsync("HideAlertConfirm");
                }
                return;
            }

            await jsRuntime.InvokeVoidAsync("ShowErrorAlert", "Hubo un error con la eliminación de Paciente");
            await jsRuntime.InvokeVoidAsync("HideAlertConfirm");
            estaProcesando = false;
        }

        private void OrdenarPor(string columna)
        {
            if (columnaOrden == columna)
            {
                ordenAscendente = !ordenAscendente; // Cambiar orden si es la misma columna
            }
            else
            {
                columnaOrden = columna;
                ordenAscendente = true; // Orden ascendente por defecto al cambiar de columna
            }

            // Ordenar la lista según la columna y el orden
            _listaPacientes = columna switch
            {
                "Id" => ordenAscendente ? _listaPacientes.OrderBy(c => c.IdPaciente).ToList() : _listaPacientes.OrderByDescending(c => c.IdPaciente).ToList(),
                "Nombre" => ordenAscendente ? _listaPacientes.OrderBy(c => c.Nombre).ToList() : _listaPacientes.OrderByDescending(c => c.Nombre).ToList(),
                "ApellidoPaterno" => ordenAscendente ? _listaPacientes.OrderBy(c => c.ApellidoPaterno).ToList() : _listaPacientes.OrderByDescending(c => c.ApellidoPaterno).ToList(),
                "ApellidoMaterno" => ordenAscendente ? _listaPacientes.OrderBy(c => c.ApellidoMaterno).ToList() : _listaPacientes.OrderByDescending(c => c.ApellidoMaterno).ToList(),
                _ => _listaPacientes
            };
        }
    }

    
}

