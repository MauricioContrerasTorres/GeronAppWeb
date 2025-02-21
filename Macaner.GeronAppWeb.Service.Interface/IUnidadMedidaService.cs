using Macaner.GeronAppWeb.Shared.Common;
using Macaner.GeronAppWeb.Shared.DTO;


namespace Macaner.GeronAppWeb.Service.Interface
{
    public interface IUnidadMedidaService
    {
        #region Metodos sincronicos
        Response<bool> Create(UnidadMedidaDTO unidadMedidaDTO);
        Response<List<UnidadMedidaDTO>> GetAll();
        Response<UnidadMedidaDTO> Get(int idUnidadMedida);
        Response<List<UnidadMedidaDTO>> Search(string textoBusqueda);
        Response<bool> Delete(int idUnidadMedida);
        Response<bool> Update(UnidadMedidaDTO unidadMedidaDTO);
        Response<bool> Exists(UnidadMedidaDTO unidadMedidaDTO);
        #endregion

        #region Metodos Asincronicos
        Task<Response<bool>> CreateAsync(UnidadMedidaDTO unidadMedidaDTO);
        Task<Response<List<UnidadMedidaDTO>>> GetAllAsync();
        Task<Response<UnidadMedidaDTO>> GetAsync(int idUnidadMedida);
        Task<Response<List<UnidadMedidaDTO>>> SearchAsync(string textoBusqueda);
        Task<Response<bool>> DeleteAsync(int idUnidadMedida);
        Task<Response<bool>> UpdateAsync(UnidadMedidaDTO unidadMedidaDTO);
        Task<Response<bool>> ExistsAsync(UnidadMedidaDTO unidadMedidaDTO);
        #endregion
    }
}
