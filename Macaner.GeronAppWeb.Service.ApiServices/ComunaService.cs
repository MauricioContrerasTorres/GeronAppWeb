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
    public class ComunaService : IComunaService
    {
        private readonly IConnectionService _connectionService;
        private readonly ISenderApi _senderApiCommon;

        public ComunaService(IConnectionService connectionServices, ISenderApi senderApiCommon)
        {
            _connectionService = connectionServices;
            _senderApiCommon = senderApiCommon;
        }


        #region Metodos Sincronicos

        public Response<bool> Update(ComunaDTO comunaDTO)
        {
            var response = new Response<bool>();
            try
            {
                string url = _connectionService.GetConnection();
                string jsonString = JsonConvert.SerializeObject(comunaDTO);
                HttpContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                var httpResult = _senderApiCommon.PostApi(url + "/Comuna/UpdateAsync", content);

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
                response.Message = "Hubo un error al obtener todas las Comunas";

            }

            return response;
        }

        public Response<bool> Create(ComunaDTO comunaDTO)
        {
            var response = new Response<bool>();
            try
            {
                string url = _connectionService.GetConnection();
                string jsonString = JsonConvert.SerializeObject(comunaDTO);
                HttpContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                var httpResult = _senderApiCommon.PostApi(url + "/Comuna/CreateAsync", content);

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
                response.Message = "Hubo un error al crear Comuna";

            }
            return response;
        }

        public Response<bool> Delete(int idComuna)
        {
            var response = new Response<bool>();
            try
            {
                string url = _connectionService.GetConnection();
                string jsonString = JsonConvert.SerializeObject(idComuna);
                HttpContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                var httpResult = _senderApiCommon.PostApi(url + "/Comuna/DeleteAsync", content);

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
                response.Message = "Hubo un error al eliminar Comuna";
            }

            return response;

        }

        public Response<bool> Exists(ComunaDTO comunaDTO)
        {
            var response = new Response<bool>();
            try
            {
                string url = _connectionService.GetConnection();
                HttpContent content = null; // Asegúrate de inicializar `content` si es necesario

                // Realiza la solicitud POST asíncrona
                var httpResult = _senderApiCommon.PostApi(url + "/Comuna/ExistsAsync", content);

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
                response.Message = "Hubo un error al obtener todas las Comunas";
            }

            return response;
        }

        public Response<List<ComunaDTO>> GetAll()
        {
            var response = new Response<List<ComunaDTO>>();
            try
            {
                string url = _connectionService.GetConnection();
                HttpContent content = null; // Asegúrate de inicializar `content` si es necesario

                // Realiza la solicitud POST asíncrona
                var httpResult = _senderApiCommon.PostApi(url + "/Comuna/GetAllAsync", content);

                if (httpResult.IsSuccessStatusCode)
                {
                    var responseContent = httpResult.Content.ReadAsStringAsync();
                    response = JsonConvert.DeserializeObject<Response<List<ComunaDTO>>>(responseContent.Result);
                }
                else
                {
                    response.Message = $"Error en la respuesta del servidor: {httpResult.StatusCode}";
                }
            }
            catch (Exception ex)
            {
                response.Message = "Hubo un error al obtener todas las Comunas";
            }

            return response;
        }

        public List<DropDownDTO> GetDropDown()
        {
            List<DropDownDTO> dropDown = new List<DropDownDTO>();
            var lista = GetAll();

            foreach (var item in lista.Data)
            {
                DropDownDTO linea = new DropDownDTO();
                linea.Id = item.IdComuna;
                linea.Descripcion = item.Nombre;
                dropDown.Add(linea);
            }

            return dropDown;
        }
        public Response<ComunaDTO> Get(int idComuna)
        {
            throw new NotImplementedException();
        }

        public Response<List<ComunaDTO>> Search(string textoBusqueda)
        {
            var response = new Response<List<ComunaDTO>>();

            try
            {
                string url = _connectionService.GetConnection();
                string jsonString = JsonConvert.SerializeObject(textoBusqueda);
                HttpContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                var httpResult = _senderApiCommon.PostApi(url + "/Comuna/SearchAsync", content);

                if (httpResult.IsSuccessStatusCode)
                {
                    var responseContent = httpResult.Content.ReadAsStringAsync();
                    response = JsonConvert.DeserializeObject<Response<List<ComunaDTO>>>(responseContent.Result);
                }
                else
                {
                    response.Message = $"Error en la respuesta del servidor: {httpResult.StatusCode}";
                }

            }
            catch (Exception ex)
            {
                response.Message = "Hubo un error con la búsqueda de Comuna";

            }

            return response;
        }

        #endregion

        #region Metodos Asincronicos

        public async Task<Response<bool>> CreateAsync(ComunaDTO comunaDTO)
        {
            var response = new Response<bool>();
            try
            {
                string url = _connectionService.GetConnection();
                string jsonString = JsonConvert.SerializeObject(comunaDTO);
                HttpContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                var httpResult = await _senderApiCommon.PostApiAsync(url + "/Comuna/CreateAsync", content);

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
                response.Message = "Hubo un error al crear Comuna";

            }
            return response;
        }

        public async Task<Response<bool>> DeleteAsync(int idComuna)
        {
            var response = new Response<bool>();
            try
            {
                string url = _connectionService.GetConnection();
                string jsonString = JsonConvert.SerializeObject(idComuna);
                HttpContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                var httpResult = await _senderApiCommon.PostApiAsync(url + "/Comuna/DeleteAsync", content);

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
                response.Message = "Hubo un error al eliminar Comuna";
            }

            return response;
        }

        public async Task<Response<bool>> ExistsAsync(ComunaDTO comunaDTO)
        {
            var response = new Response<bool>();
            try
            {
                string url = _connectionService.GetConnection();
                string jsonString = JsonConvert.SerializeObject(comunaDTO);
                HttpContent content = new StringContent(jsonString, Encoding.UTF8, "application/json"); // Asegúrate de inicializar `content` si es necesario

                // Realiza la solicitud POST asíncrona
                var httpResult = await _senderApiCommon.PostApiAsync(url + "/Comuna/ExistsAsync", content);

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
                response.Message = "Hubo un error al obtener todas las Comunas";
            }

            return response;
        }

        public async Task<Response<List<ComunaDTO>>> GetAllAsync()
        {
            var response = new Response<List<ComunaDTO>>();
            try
            {
                string url = _connectionService.GetConnection();
                HttpContent content = null; // Asegúrate de inicializar `content` si es necesario

                // Realiza la solicitud POST asíncrona
                var httpResult = await _senderApiCommon.PostApiAsync(url + "/Comuna/GetAllAsync", content);

                if (httpResult.IsSuccessStatusCode)
                {
                    var responseContent = await httpResult.Content.ReadAsStringAsync();
                    response = JsonConvert.DeserializeObject<Response<List<ComunaDTO>>>(responseContent);
                }
                else
                {
                    response.Message = $"Error en la respuesta del servidor: {httpResult.StatusCode}";
                }
            }
            catch (Exception ex)
            {
                response.Message = "Hubo un error al obtener todas las Comunas";
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
                linea.Id = item.IdComuna;
                linea.Descripcion = item.Nombre;
                dropDown.Add(linea);
            }

            return dropDown;
        }

        public async Task<Response<ComunaDTO>> GetAsync(int IdComuna)
        {
            var response = new Response<ComunaDTO>();
            try
            {
                string url = _connectionService.GetConnection();
                string jsonString = JsonConvert.SerializeObject(IdComuna);
                HttpContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                // Realiza la solicitud POST asíncrona
                var httpResult = await _senderApiCommon.PostApiAsync(url + "/Comuna/GetAsync", content);

                if (httpResult.IsSuccessStatusCode)
                {
                    var responseContent = await httpResult.Content.ReadAsStringAsync();
                    response = JsonConvert.DeserializeObject<Response<ComunaDTO>>(responseContent);
                }
                else
                {
                    response.Message = $"Error en la respuesta del servidor: {httpResult.StatusCode}";
                }
            }
            catch (Exception ex)
            {
                response.Message = "Hubo un error al obtener todas las Comunas";
            }

            return response;
        }

        public async Task<Response<bool>> UpdateAsync(ComunaDTO comunaDTO)
        {
            var response = new Response<bool>();
            try
            {
                //ComunaEditarRequest request = new ComunaEditarRequest();
                //request.IdComuna = idComuna;
                //request.DetalleComuna = comunaDTO;

                string url = _connectionService.GetConnection();
                string jsonString = JsonConvert.SerializeObject(comunaDTO);
                HttpContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                var httpResult = await _senderApiCommon.PostApiAsync(url + "/Comuna/UpdateAsync", content);

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
                response.Message = "Hubo un error al obtener todas las Comunas";

            }

            return response;
        }

        public async Task<Response<List<ComunaDTO>>> SearchAsync(string textoBusqueda)
        {
            var response = new Response<List<ComunaDTO>>();

            try
            {
                string url = _connectionService.GetConnection();
                string jsonString = JsonConvert.SerializeObject(textoBusqueda);
                HttpContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                var httpResult = await _senderApiCommon.PostApiAsync(url + "/Comuna/SearchAsync", content);

                if (httpResult.IsSuccessStatusCode)
                {
                    var responseContent = await httpResult.Content.ReadAsStringAsync();
                    response = JsonConvert.DeserializeObject<Response<List<ComunaDTO>>>(responseContent);
                }
                else
                {
                    response.Message = $"Error en la respuesta del servidor: {httpResult.StatusCode}";
                }

            }
            catch (Exception ex)
            {
                response.Message = "Hubo un error con la búsqueda de Comuna";

            }

            return response;
        }

        #endregion
    }
}
