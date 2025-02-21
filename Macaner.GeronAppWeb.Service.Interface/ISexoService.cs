using Macaner.GeronAppWeb.Shared.Common;
using Macaner.GeronAppWeb.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Macaner.GeronAppWeb.Service.Interface
{
    public interface ISexoService
    {
        #region Metodos sincronicos
        Response<bool> Create(SexoDTO sexoDTO);
        Response<List<SexoDTO>> GetAll();
        Response<SexoDTO> Get(int idSexo);
        Response<List<SexoDTO>> Search(string textoBusqueda);
        Response<bool> Delete(int idSexo);
        Response<bool> Update(SexoDTO sexoDTO);
        Response<bool> Exists(SexoDTO sexoDTO);
        List<DropDownDTO> GetDropDown();
        #endregion

        #region Metodos Asincronicos
        Task<Response<bool>> CreateAsync(SexoDTO sexoDTO);
        Task<Response<List<SexoDTO>>> GetAllAsync();
        Task<Response<SexoDTO>> GetAsync(int idSexo);
        Task<Response<List<SexoDTO>>> SearchAsync(string textoBusqueda);
        Task<Response<bool>> DeleteAsync(int idSexo);
        Task<Response<bool>> UpdateAsync(SexoDTO sexoDTO);
        Task<Response<bool>> ExistsAsync(SexoDTO sexoDTO);
        Task<List<DropDownDTO>> GetDropDownAsync();
        #endregion
    }
}
