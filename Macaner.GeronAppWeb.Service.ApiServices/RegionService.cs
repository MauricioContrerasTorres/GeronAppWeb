using Macaner.GeronAppWeb.Service.Interface;
using Macaner.GeronAppWeb.Shared.Common;
using Macaner.GeronAppWeb.Shared.DTO;
using Macaner.GeronAppWeb.Shared.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Macaner.GeronAppWeb.Service.ApiServices
{
    public class RegionService : IRegionService
    {
        private readonly IConnectionService _connectionService;
        private readonly ISenderApi _senderApiCommon;

        public RegionService(IConnectionService connectionServices, ISenderApi senderApiCommon)
        {
            _connectionService = connectionServices;
            _senderApiCommon = senderApiCommon;
        }


        #region Metodos Sincronicos

        public Response<bool> Update(RegionDTO regionDTO)
        {
            var response = new Response<bool>();
            try
            {
                string url = _connectionService.GetConnection();
                string jsonString = JsonConvert.SerializeObject(regionDTO);
                HttpContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                var httpResult = _senderApiCommon.PostApi(url + "/Region/UpdateAsync", content);

                if (httpResult.IsSuccessStatusCode)
                {
                    var responseContent = httpResult.Content.ReadAsStringAsync();
                    response = JsonConvert.DeserializeObject<Response<bool>>(responseContent.Result);
                }
                else
                {
                    response.Message = $"Error en la respuesta del servidor: {httpResult.StatusCode}";
                }
            }
            catch (Exception ex)
            {
                response.Message = "Hubo un error al obtener todas las Regions";

            }

            return response;
        }

        public Response<bool> Create(RegionDTO regionDTO)
        {
            var response = new Response<bool>();
            try
            {
                string url = _connectionService.GetConnection();
                string jsonString = JsonConvert.SerializeObject(regionDTO);
                HttpContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                var httpResult = _senderApiCommon.PostApi(url + "/Region/CreateAsync", content);

                if (httpResult.IsSuccessStatusCode)
                {
                    var responseContent = httpResult.Content.ReadAsStringAsync();
                    response = JsonConvert.DeserializeObject<Response<bool>>(responseContent.Result);
                }
                else
                {
                    response.Message = $"Error en la respuesta del servidor: {httpResult.StatusCode}";
                }
            }
            catch (Exception ex)
            {
                response.Message = "Hubo un error al crear Region";

            }
            return response;
        }

        public Response<bool> Delete(int idRegion)
        {
            var response = new Response<bool>();
            try
            {
                string url = _connectionService.GetConnection();
                string jsonString = JsonConvert.SerializeObject(idRegion);
                HttpContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                var httpResult = _senderApiCommon.PostApi(url + "/Region/DeleteAsync", content);

                if (httpResult.IsSuccessStatusCode)
                {
                    var responseContent = httpResult.Content.ReadAsStringAsync();
                    response = JsonConvert.DeserializeObject<Response<bool>>(responseContent.Result);
                }
                else
                {
                    response.Message = $"Error en la respuesta del servidor: {httpResult.StatusCode}";
                }

            }
            catch (Exception ex)
            {
                response.Message = "Hubo un error al eliminar Region";
            }

            return response;

        }

        public Response<bool> Exists(RegionDTO region)
        {
            var response = new Response<bool>();
            try
            {
                string url = _connectionService.GetConnection();
                string jsonString = JsonConvert.SerializeObject(region);
                HttpContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                var httpResult = _senderApiCommon.PostApi(url + "/Region/ExistsAsync", content);

                if (httpResult.IsSuccessStatusCode)
                {
                    var responseContent = httpResult.Content.ReadAsStringAsync();
                    response = JsonConvert.DeserializeObject<Response<bool>>(responseContent.Result);
                }
                else
                {
                    response.Message = $"Error en la respuesta del servidor: {httpResult.StatusCode}";
                }

            }
            catch (Exception ex)
            {
                response.Message = "Hubo un error al eliminar Region";
            }

            return response;
        }

        public List<DropDownDTO> GetDropDown() {
            List<DropDownDTO> dropDown = new List<DropDownDTO>();
            var lista = GetAll();

            foreach (var item in lista.Data) {
                DropDownDTO linea = new DropDownDTO();
                linea.Id = item.IdRegion;
                linea.Descripcion = item.Nombre;
                dropDown.Add(linea);
            }

            return dropDown;
        }

        public Response<List<RegionDTO>> GetAll()
        {
            var response = new Response<List<RegionDTO>>();
            try
            {
                string url = _connectionService.GetConnection();
                HttpContent content = null; // Asegúrate de inicializar `content` si es necesario

                // Realiza la solicitud POST asíncrona
                var httpResult = _senderApiCommon.PostApi(url + "/Region/GetAll", content);

                if (httpResult.IsSuccessStatusCode)
                {
                    var responseContent = httpResult.Content.ReadAsStringAsync();
                    response = JsonConvert.DeserializeObject<Response<List<RegionDTO>>>(responseContent.Result);
                }
                else
                {
                    response.Message = $"Error en la respuesta del servidor: {httpResult.StatusCode}";
                }
            }
            catch (Exception ex)
            {
                response.Message = "Hubo un error al obtener todas las Regions";
            }

            return response;
        }

        public Response<RegionDTO> Get(int idRegion)
        {
            throw new NotImplementedException();
        }

        public Response<List<RegionDTO>> Search(string textoBusqueda)
        {
            var response = new Response<List<RegionDTO>>();

            try
            {
                string url = _connectionService.GetConnection();
                string jsonString = JsonConvert.SerializeObject(textoBusqueda);
                HttpContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                var httpResult = _senderApiCommon.PostApi(url + "/Region/SearchAsync", content);

                if (httpResult.IsSuccessStatusCode)
                {
                    var responseContent = httpResult.Content.ReadAsStringAsync();
                    response = JsonConvert.DeserializeObject<Response<List<RegionDTO>>>(responseContent.Result);
                }
                else
                {
                    response.Message = $"Error en la respuesta del servidor: {httpResult.StatusCode}";
                }

            }
            catch (Exception ex)
            {
                response.Message = "Hubo un error con la búsqueda de Region";

            }

            return response;
        }

        #endregion

        #region Metodos Asincronicos

        public async Task<Response<bool>> CreateAsync(RegionDTO regionDTO)
        {
            var response = new Response<bool>();
            try
            {
                string url = _connectionService.GetConnection();
                string jsonString = JsonConvert.SerializeObject(regionDTO);
                HttpContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                var httpResult = await _senderApiCommon.PostApiAsync(url + "/Region/CreateAsync", content);

                if (httpResult.IsSuccessStatusCode)
                {
                    var responseContent = await httpResult.Content.ReadAsStringAsync();
                    response = JsonConvert.DeserializeObject<Response<bool>>(responseContent);
                }
                else
                {
                    response.Message = $"Error en la respuesta del servidor: {httpResult.StatusCode}";
                }
            }
            catch (Exception ex)
            {
                response.Message = "Hubo un error al crear Region";

            }
            return response;
        }

        public async Task<Response<bool>> DeleteAsync(int idRegion)
        {
            var response = new Response<bool>();
            try
            {
                string url = _connectionService.GetConnection();
                string jsonString = JsonConvert.SerializeObject(idRegion);
                HttpContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                var httpResult = await _senderApiCommon.PostApiAsync(url + "/Region/DeleteAsync", content);

                if (httpResult.IsSuccessStatusCode)
                {
                    var responseContent = await httpResult.Content.ReadAsStringAsync();
                    response = JsonConvert.DeserializeObject<Response<bool>>(responseContent);
                }
                else
                {
                    response.Message = $"Error en la respuesta del servidor: {httpResult.StatusCode}";
                }

            }
            catch (Exception ex)
            {
                response.Message = "Hubo un error al eliminar Region";
            }

            return response;
        }

        public async Task<Response<bool>> ExistsAsync(RegionDTO region)
        {
            var response = new Response<bool>();
            try
            {
                string url = _connectionService.GetConnection();
                string jsonString = JsonConvert.SerializeObject(region);
                HttpContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                var httpResult = await _senderApiCommon.PostApiAsync(url + "/Region/ExistsAsync", content);

                if (httpResult.IsSuccessStatusCode)
                {
                    var responseContent = await httpResult.Content.ReadAsStringAsync();
                    response = JsonConvert.DeserializeObject<Response<bool>>(responseContent);
                }
                else
                {
                    response.Message = $"Error en la respuesta del servidor: {httpResult.StatusCode}";
                }

            }
            catch (Exception ex)
            {
                response.Message = "Hubo un error al eliminar Region";
            }

            return response;
        }


        public async Task<List<DropDownDTO>> GetDropDownAsync()
        {
            List<DropDownDTO> dropDown = new List<DropDownDTO>();
            var lista = await GetAllAsync();

            foreach (var item in lista.Data)
            {
                DropDownDTO linea = new DropDownDTO();
                linea.Id = item.IdRegion;
                linea.Descripcion = item.Nombre;
                dropDown.Add(linea);
            }

            return dropDown;
        }
        public async Task<Response<List<RegionDTO>>> GetAllAsync()
        {
            var response = new Response<List<RegionDTO>>();
            try
            {
                string url = _connectionService.GetConnection();
                HttpContent content = null; // Asegúrate de inicializar `content` si es necesario

                // Realiza la solicitud POST asíncrona
                var httpResult = await _senderApiCommon.PostApiAsync(url + "/Region/GetAllAsync", content);

                if (httpResult.IsSuccessStatusCode)
                {
                    var responseContent = await httpResult.Content.ReadAsStringAsync();
                    response = JsonConvert.DeserializeObject<Response<List<RegionDTO>>>(responseContent);
                }
                else
                {
                    response.Message = $"Error en la respuesta del servidor: {httpResult.StatusCode}";
                }
            }
            catch (Exception ex)
            {
                response.Message = "Hubo un error al obtener todas las Regions";
            }

            return response;
        }

        public async Task<Response<RegionDTO>> GetAsync(int IdRegion)
        {
            var response = new Response<RegionDTO>();
            try
            {
                string url = _connectionService.GetConnection();
                string jsonString = JsonConvert.SerializeObject(IdRegion);
                HttpContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                // Realiza la solicitud POST asíncrona
                var httpResult = await _senderApiCommon.PostApiAsync(url + "/Region/GetAsync", content);

                if (httpResult.IsSuccessStatusCode)
                {
                    var responseContent = await httpResult.Content.ReadAsStringAsync();
                    response = JsonConvert.DeserializeObject<Response<RegionDTO>>(responseContent);
                }
                else
                {
                    response.Message = $"Error en la respuesta del servidor: {httpResult.StatusCode}";
                }
            }
            catch (Exception ex)
            {
                response.Message = "Hubo un error al obtener todas las Regions";
            }

            return response;
        }

        public async Task<Response<bool>> UpdateAsync(RegionDTO regionDTO)
        {
            var response = new Response<bool>();
            try
            {
                //RegionEditarRequest request = new RegionEditarRequest();
                //request.IdRegion = idRegion;
                //request.DetalleRegion = regionDTO;

                string url = _connectionService.GetConnection();
                string jsonString = JsonConvert.SerializeObject(regionDTO);
                HttpContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                var httpResult = await _senderApiCommon.PostApiAsync(url + "/Region/UpdateAsync", content);

                if (httpResult.IsSuccessStatusCode)
                {
                    var responseContent = await httpResult.Content.ReadAsStringAsync();
                    response = JsonConvert.DeserializeObject<Response<bool>>(responseContent);
                }
                else
                {
                    response.Message = $"Error en la respuesta del servidor: {httpResult.StatusCode}";
                }
            }
            catch (Exception ex)
            {
                response.Message = "Hubo un error al obtener todas las Regions";

            }

            return response;
        }

        public async Task<Response<List<RegionDTO>>> SearchAsync(string textoBusqueda)
        {
            var response = new Response<List<RegionDTO>>();

            try
            {
                string url = _connectionService.GetConnection();
                string jsonString = JsonConvert.SerializeObject(textoBusqueda);
                HttpContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                var httpResult = await _senderApiCommon.PostApiAsync(url + "/Region/SearchAsync", content);

                if (httpResult.IsSuccessStatusCode)
                {
                    var responseContent = await httpResult.Content.ReadAsStringAsync();
                    response = JsonConvert.DeserializeObject<Response<List<RegionDTO>>>(responseContent);
                }
                else
                {
                    response.Message = $"Error en la respuesta del servidor: {httpResult.StatusCode}";
                }

            }
            catch (Exception ex)
            {
                response.Message = "Hubo un error con la búsqueda de Region";

            }

            return response;
        }

        #endregion
    }
}
