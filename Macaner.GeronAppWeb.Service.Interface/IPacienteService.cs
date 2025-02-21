using Macaner.GeronAppWeb.Shared.Common;
using Macaner.GeronAppWeb.Shared.DTO;
using Macaner.GeronAppWeb.Shared.DTO.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Macaner.GeronAppWeb.Service.Interface
{
    public interface IPacienteService
    {
        #region Metodos sincronicos
        Response<bool> Create(PacienteDTO pacienteDTO);
        Response<List<PacienteDTO>> GetAll();
        Response<PacienteDTO> Get(int idPaciente);
        Response<List<PacienteDTO>> Search(string textoBusqueda);
        Response<bool> Delete(int idPaciente);
        Response<bool> Update(PacienteDTO pacienteDTO);
        Response<bool> Exists(PacienteDTO pacienteDTO);
        Response<List<ListaPacienteDTO>> GetListaPacientes(FiltroPacienteRequestDTO request);
        Response<List<AlergiaMedicamentoPacienteDTO>> GeAlergiasMedicamentosPacientes(int IdPaciente);
        Response<List<AlergiaPacienteDTO>> GetAlergias(int IdPaciente);

        #endregion

        #region Metodos Asincronicos
        Task<Response<bool>> CreateAsync(PacienteDTO pacienteDTO);
        Task<Response<List<PacienteDTO>>> GetAllAsync();
        Task<Response<PacienteDTO>> GetAsync(int idPaciente);
        Task<Response<List<PacienteDTO>>> SearchAsync(string textoBusqueda);
        Task<Response<bool>> DeleteAsync(int idPaciente);
        Task<Response<bool>> UpdateAsync(PacienteDTO pacienteDTO);
        Task<Response<bool>> ExistsAsync(PacienteDTO pacienteDTO);
        Task<Response<List<ListaPacienteDTO>>> GetListaPacientesAsync(FiltroPacienteRequestDTO request);
        Task<Response<List<AlergiaMedicamentoPacienteDTO>>> GeAlergiasMedicamentosPacientesAsync(int IdPaciente);
        Task<Response<List<AlergiaPacienteDTO>>> GetAlergiasAsync(int IdPaciente);
        #endregion
    }
}
