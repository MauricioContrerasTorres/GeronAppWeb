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
using static Macaner.GeronAppWeb.Service.ApiServices.ConnectionService;

namespace Macaner.GeronAppWeb.Service.ApiServices
{
    public class UnidadMedidaService : IUnidadMedidaService
    {
        private readonly IConnectionService _connectionService;
        private readonly ISenderApi _senderApiCommon;

        public UnidadMedidaService(IConnectionService connectionServices, ISenderApi senderApiCommon)
        {
            _connectionService = connectionServices;
            _senderApiCommon = senderApiCommon;
        }


        #region Metodos Sincronicos

        public Response<bool> Update(UnidadMedidaDTO unidadMedidaDTO)
        {
            var response = new Response<bool>();
            try
            {
                string url = _connectionService.GetConnection();
                string jsonString = JsonConvert.SerializeObject(unidadMedidaDTO);
                HttpContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                var httpResult = _senderApiCommon.PostApi(url + "/UnidadMedida/UpdateAsync", content);

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
                response.Message = "Hubo un error al obtener todas las UnidadMedidas";

            }

            return response;
        }

        public Response<bool> Create(UnidadMedidaDTO unidadMedidaDTO)
        {
            var response = new Response<bool>();
            try
            {
                string url = _connectionService.GetConnection();
                string jsonString = JsonConvert.SerializeObject(unidadMedidaDTO);
                HttpContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                var httpResult = _senderApiCommon.PostApi(url + "/UnidadMedida/CreateAsync", content);

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
                response.Message = "Hubo un error al crear UnidadMedida";

            }
            return response;
        }

        public Response<bool> Delete(int idUnidadMedida)
        {
            var response = new Response<bool>();
            try
            {
                string url = _connectionService.GetConnection();
                string jsonString = JsonConvert.SerializeObject(idUnidadMedida);
                HttpContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                var httpResult = _senderApiCommon.PostApi(url + "/UnidadMedida/DeleteAsync", content);

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
                response.Message = "Hubo un error al eliminar UnidadMedida";
            }

            return response;

        }

        public Response<bool> Exists(UnidadMedidaDTO unidadMedidaDTO)
        {
            var response = new Response<bool>();
            try
            {
                string url = _connectionService.GetConnection();
                HttpContent content = null; // Asegúrate de inicializar `content` si es necesario

                // Realiza la solicitud POST asíncrona
                var httpResult = _senderApiCommon.PostApi(url + "/UnidadMedida/ExistsAsync", content);

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
                response.Message = "Hubo un error al obtener todas las UnidadMedidas";
            }

            return response;
        }

        public Response<List<UnidadMedidaDTO>> GetAll()
        {
            var response = new Response<List<UnidadMedidaDTO>>();
            try
            {
                string url = _connectionService.GetConnection();
                HttpContent content = null; // Asegúrate de inicializar `content` si es necesario

                // Realiza la solicitud POST asíncrona
                var httpResult = _senderApiCommon.PostApi(url + "/UnidadMedida/GetAllAsync", content);

                if (httpResult.IsSuccessStatusCode)
                {
                    var responseContent = httpResult.Content.ReadAsStringAsync();
                    response = JsonConvert.DeserializeObject<Response<List<UnidadMedidaDTO>>>(responseContent.Result);
                }
                else
                {
                    response.Message = $"Error en la respuesta del servidor: {httpResult.StatusCode}";
                }
            }
            catch (Exception ex)
            {
                response.Message = "Hubo un error al obtener todas las UnidadMedidas";
            }

            return response;
        }

        public Response<UnidadMedidaDTO> Get(int idUnidadMedida)
        {
            throw new NotImplementedException();
        }

        public Response<List<UnidadMedidaDTO>> Search(string textoBusqueda)
        {
            var response = new Response<List<UnidadMedidaDTO>>();

            try
            {
                string url = _connectionService.GetConnection();
                string jsonString = JsonConvert.SerializeObject(textoBusqueda);
                HttpContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                var httpResult = _senderApiCommon.PostApi(url + "/UnidadMedida/SearchAsync", content);

                if (httpResult.IsSuccessStatusCode)
                {
                    var responseContent = httpResult.Content.ReadAsStringAsync();
                    response = JsonConvert.DeserializeObject<Response<List<UnidadMedidaDTO>>>(responseContent.Result);
                }
                else
                {
                    response.Message = $"Error en la respuesta del servidor: {httpResult.StatusCode}";
                }

            }
            catch (Exception ex)
            {
                response.Message = "Hubo un error con la búsqueda de UnidadMedida";

            }

            return response;
        }

        #endregion

        #region Metodos Asincronicos

        public async Task<Response<bool>> CreateAsync(UnidadMedidaDTO unidadMedidaDTO)
        {
            var response = new Response<bool>();
            try
            {
                string url = _connectionService.GetConnection();
                string jsonString = JsonConvert.SerializeObject(unidadMedidaDTO);
                HttpContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                var httpResult = await _senderApiCommon.PostApiAsync(url + "/UnidadMedida/CreateAsync", content);

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
                response.Message = "Hubo un error al crear UnidadMedida";

            }
            return response;
        }

        public async Task<Response<bool>> DeleteAsync(int idUnidadMedida)
        {
            var response = new Response<bool>();
            try
            {
                string url = _connectionService.GetConnection();
                string jsonString = JsonConvert.SerializeObject(idUnidadMedida);
                HttpContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                var httpResult = await _senderApiCommon.PostApiAsync(url + "/UnidadMedida/DeleteAsync", content);

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
                response.Message = "Hubo un error al eliminar UnidadMedida";
            }

            return response;
        }

        public async Task<Response<bool>> ExistsAsync(UnidadMedidaDTO unidadMedidaDTO)
        {
            var response = new Response<bool>();
            try
            {
                string url = _connectionService.GetConnection();
                string jsonString = JsonConvert.SerializeObject(unidadMedidaDTO);
                HttpContent content = new StringContent(jsonString, Encoding.UTF8, "application/json"); // Asegúrate de inicializar `content` si es necesario

                // Realiza la solicitud POST asíncrona
                var httpResult = await _senderApiCommon.PostApiAsync(url + "/UnidadMedida/ExistsAsync", content);

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
                response.Message = "Hubo un error al obtener todas las UnidadMedidas";
            }

            return response;
        }

        public async Task<Response<List<UnidadMedidaDTO>>> GetAllAsync()
        {
            var response = new Response<List<UnidadMedidaDTO>>();
            try
            {
                string url = _connectionService.GetConnection();
                HttpContent content = null; // Asegúrate de inicializar `content` si es necesario

                // Realiza la solicitud POST asíncrona
                var httpResult = await _senderApiCommon.PostApiAsync(url + "/UnidadMedida/GetAllAsync", content);

                if (httpResult.IsSuccessStatusCode)
                {
                    var responseContent = await httpResult.Content.ReadAsStringAsync();
                    response = JsonConvert.DeserializeObject<Response<List<UnidadMedidaDTO>>>(responseContent);
                }
                else
                {
                    response.Message = $"Error en la respuesta del servidor: {httpResult.StatusCode}";
                }
            }
            catch (Exception ex)
            {
                response.Message = "Hubo un error al obtener todas las UnidadMedidas";
            }

            return response;
        }

        public async Task<Response<UnidadMedidaDTO>> GetAsync(int IdUnidadMedida)
        {
            var response = new Response<UnidadMedidaDTO>();
            try
            {
                string url = _connectionService.GetConnection();
                string jsonString = JsonConvert.SerializeObject(IdUnidadMedida);
                HttpContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                // Realiza la solicitud POST asíncrona
                var httpResult = await _senderApiCommon.PostApiAsync(url + "/UnidadMedida/GetAsync", content);

                if (httpResult.IsSuccessStatusCode)
                {
                    var responseContent = await httpResult.Content.ReadAsStringAsync();
                    response = JsonConvert.DeserializeObject<Response<UnidadMedidaDTO>>(responseContent);
                }
                else
                {
                    response.Message = $"Error en la respuesta del servidor: {httpResult.StatusCode}";
                }
            }
            catch (Exception ex)
            {
                response.Message = "Hubo un error al obtener todas las UnidadMedidas";
            }

            return response;
        }

        public async Task<Response<bool>> UpdateAsync(UnidadMedidaDTO unidadMedidaDTO)
        {
            var response = new Response<bool>();
            try
            {
                //UnidadMedidaEditarRequest request = new UnidadMedidaEditarRequest();
                //request.IdUnidadMedida = idUnidadMedida;
                //request.DetalleUnidadMedida = unidadMedidaDTO;

                string url = _connectionService.GetConnection();
                string jsonString = JsonConvert.SerializeObject(unidadMedidaDTO);
                HttpContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                var httpResult = await _senderApiCommon.PostApiAsync(url + "/UnidadMedida/UpdateAsync", content);

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
                response.Message = "Hubo un error al obtener todas las UnidadMedidas";

            }

            return response;
        }

        public async Task<Response<List<UnidadMedidaDTO>>> SearchAsync(string textoBusqueda)
        {
            var response = new Response<List<UnidadMedidaDTO>>();

            try
            {
                string url = _connectionService.GetConnection();
                string jsonString = JsonConvert.SerializeObject(textoBusqueda);
                HttpContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                var httpResult = await _senderApiCommon.PostApiAsync(url + "/UnidadMedida/SearchAsync", content);

                if (httpResult.IsSuccessStatusCode)
                {
                    var responseContent = await httpResult.Content.ReadAsStringAsync();
                    response = JsonConvert.DeserializeObject<Response<List<UnidadMedidaDTO>>>(responseContent);
                }
                else
                {
                    response.Message = $"Error en la respuesta del servidor: {httpResult.StatusCode}";
                }

            }
            catch (Exception ex)
            {
                response.Message = "Hubo un error con la búsqueda de UnidadMedida";

            }

            return response;
        }

        #endregion
    }
}
