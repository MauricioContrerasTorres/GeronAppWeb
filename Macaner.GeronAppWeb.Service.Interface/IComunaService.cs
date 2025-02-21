using Macaner.GeronAppWeb.Shared.Common;
using Macaner.GeronAppWeb.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Macaner.GeronAppWeb.Service.Interface
{
    public interface IComunaService
    {
        #region Metodos sincronicos
        Response<bool> Create(ComunaDTO comunaDTO);
        Response<List<ComunaDTO>> GetAll();
        Response<ComunaDTO> Get(int idComuna);
        List<DropDownDTO> GetDropDown();
        Response<List<ComunaDTO>> Search(string textoBusqueda);
        Response<bool> Delete(int idComuna);
        Response<bool> Update(ComunaDTO comunaDTO);
        Response<bool> Exists(ComunaDTO comunaDTO);
        #endregion

        #region Metodos Asincronicos
        Task<Response<bool>> CreateAsync(ComunaDTO comunaDTO);
        Task<Response<List<ComunaDTO>>> GetAllAsync();
        Task<List<DropDownDTO>> GetDropDownAsync();
        Task<Response<ComunaDTO>> GetAsync(int idComuna);
        Task<Response<List<ComunaDTO>>> SearchAsync(string textoBusqueda);
        Task<Response<bool>> DeleteAsync(int idComuna);
        Task<Response<bool>> UpdateAsync(ComunaDTO comunaDTO);
        Task<Response<bool>> ExistsAsync(ComunaDTO comunaDTO);
        #endregion
    }
}
