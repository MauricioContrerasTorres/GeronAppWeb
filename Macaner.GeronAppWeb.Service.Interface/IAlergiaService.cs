using Macaner.GeronAppWeb.Shared.Common;
using Macaner.GeronAppWeb.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Macaner.GeronAppWeb.Service.Interface
{
    public interface IAlergiaService
    {
        #region Metodos sincronicos
        Response<bool> Create(AlergiaDTO alergiaDTO);
        Response<List<AlergiaDTO>> GetAll();
        Response<AlergiaDTO> Get(int idAlergia);
        List<DropDownDTO> GetDropDown();
        Response<List<AlergiaDTO>> Search(string textoBusqueda);
        Response<bool> Delete(int idAlergia);
        Response<bool> Update(AlergiaDTO alergiaDTO);
        Response<bool> Exists(AlergiaDTO alergiaDTO);
        #endregion

        #region Metodos Asincronicos
        Task<Response<bool>> CreateAsync(AlergiaDTO alergiaDTO);
        Task<Response<List<AlergiaDTO>>> GetAllAsync();
        Task<List<DropDownDTO>> GetDropDownAsync();
        Task<Response<AlergiaDTO>> GetAsync(int idAlergia);
        Task<Response<List<AlergiaDTO>>> SearchAsync(string textoBusqueda);
        Task<Response<bool>> DeleteAsync(int idAlergia);
        Task<Response<bool>> UpdateAsync(AlergiaDTO alergiaDTO);
        Task<Response<bool>> ExistsAsync(AlergiaDTO alergiaDTO);
        #endregion
    }
}
