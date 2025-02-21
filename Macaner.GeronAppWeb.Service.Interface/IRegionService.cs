using Macaner.GeronAppWeb.Shared.Common;
using Macaner.GeronAppWeb.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Macaner.GeronAppWeb.Service.Interface
{
    public  interface IRegionService
    {
        #region Metodos sincronicos
        Response<bool> Create(RegionDTO regionDTO);
        List<DropDownDTO> GetDropDown();
        Response<List<RegionDTO>> GetAll();
        Response<RegionDTO> Get(int idRegion);
        Response<List<RegionDTO>> Search(string textoBusqueda);
        Response<bool> Delete(int idRegion);
        Response<bool> Update(RegionDTO regionDTO);
        Response<bool> Exists(RegionDTO region);
        #endregion

        #region Metodos Asincronicos
        Task<Response<bool>> CreateAsync(RegionDTO RegionDTO);
        Task<List<DropDownDTO>> GetDropDownAsync();
        Task<Response<List<RegionDTO>>> GetAllAsync();
        Task<Response<RegionDTO>> GetAsync(int idRegion);
        Task<Response<List<RegionDTO>>> SearchAsync(string textoBusqueda);
        Task<Response<bool>> DeleteAsync(int idRegion);
        Task<Response<bool>> UpdateAsync(RegionDTO regionDTO);
        Task<Response<bool>> ExistsAsync(RegionDTO region);
        #endregion
    }
}
