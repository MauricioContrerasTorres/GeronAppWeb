using Macaner.GeronAppWeb.Shared.Common;
using Macaner.GeronAppWeb.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Macaner.GeronAppWeb.Service.Interface
{
    public interface IMedicamentoService
    {
        #region Metodos sincronicos
        Response<bool> Create(MedicamentoDTO medicamentoDTO);
        Response<List<MedicamentoDTO>> GetAll();
        Response<MedicamentoDTO> Get(int idMedicamento);
        List<DropDownDTO> GetDropDown();
        Response<List<MedicamentoDTO>> Search(string textoBusqueda);
        Response<bool> Delete(int idMedicamento);
        Response<bool> Update(MedicamentoDTO medicamentoDTO);
        Response<bool> Exists(MedicamentoDTO medicamentoDTO);
        #endregion

        #region Metodos Asincronicos
        Task<Response<bool>> CreateAsync(MedicamentoDTO medicamentoDTO);
        Task<Response<List<MedicamentoDTO>>> GetAllAsync();
        Task<List<DropDownDTO>> GetDropDownAsync();
        Task<Response<MedicamentoDTO>> GetAsync(int idMedicamento);
        Task<Response<List<MedicamentoDTO>>> SearchAsync(string textoBusqueda);
        Task<Response<bool>> DeleteAsync(int idMedicamento);
        Task<Response<bool>> UpdateAsync(MedicamentoDTO medicamentoDTO);
        Task<Response<bool>> ExistsAsync(MedicamentoDTO medicamentoDTO);
        #endregion
    }
}
