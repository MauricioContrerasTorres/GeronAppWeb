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
    public class AlergiaService : IAlergiaService
    {
        private readonly IConnectionService _connectionService;
        private readonly ISenderApi _senderApiCommon;

        public AlergiaService(IConnectionService connectionServices, ISenderApi senderApiCommon)
        {
            _connectionService = connectionServices;
            _senderApiCommon = senderApiCommon;
        }


        #region Metodos Sincronicos

        public Response<bool> Update(AlergiaDTO alergiaDTO)
        {
            var response = new Response<bool>();
            try
            {
                string url = _connectionService.GetConnection();
                string jsonString = JsonConvert.SerializeObject(alergiaDTO);
                HttpContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                var httpResult = _senderApiCommon.PostApi(url + "/Alergia/UpdateAsync", content);

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
                response.Message = "Hubo un error al obtener todos las Alergias";

            }

            return response;
        }

        public Response<bool> Create(AlergiaDTO alergiaDTO)
        {
            var response = new Response<bool>();
            try
            {
                string url = _connectionService.GetConnection();
                string jsonString = JsonConvert.SerializeObject(alergiaDTO);
                HttpContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                var httpResult = _senderApiCommon.PostApi(url + "/Alergia/CreateAsync", content);

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
                response.Message = "Hubo un error al crear Alergia";

            }
            return response;
        }

        public Response<bool> Delete(int idAlergia)
        {
            var response = new Response<bool>();
            try
            {
                string url = _connectionService.GetConnection();
                string jsonString = JsonConvert.SerializeObject(idAlergia);
                HttpContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                var httpResult = _senderApiCommon.PostApi(url + "/Alergia/DeleteAsync", content);

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
                response.Message = "Hubo un error al eliminar Alergia";
            }

            return response;

        }

        public Response<bool> Exists(AlergiaDTO alergiaDTO)
        {
            var response = new Response<bool>();
            try
            {
                string url = _connectionService.GetConnection();
                HttpContent content = null; // Asegúrate de inicializar `content` si es necesario

                // Realiza la solicitud POST asíncrona
                var httpResult = _senderApiCommon.PostApi(url + "/Alergia/ExistsAsync", content);

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
                response.Message = "Hubo un error al obtener todos las Alergias";
            }

            return response;
        }

        public Response<List<AlergiaDTO>> GetAll()
        {
            var response = new Response<List<AlergiaDTO>>();
            try
            {
                string url = _connectionService.GetConnection();
                HttpContent content = null; // Asegúrate de inicializar `content` si es necesario

                // Realiza la solicitud POST asíncrona
                var httpResult = _senderApiCommon.PostApi(url + "/Alergia/GetAllAsync", content);

                if (httpResult.IsSuccessStatusCode)
                {
                    var responseContent = httpResult.Content.ReadAsStringAsync();
                    response = JsonConvert.DeserializeObject<Response<List<AlergiaDTO>>>(responseContent.Result);
                }
                else
                {
                    response.Message = $"Error en la respuesta del servidor: {httpResult.StatusCode}";
                }
            }
            catch (Exception ex)
            {
                response.Message = "Hubo un error al obtener todos las Alergias";
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
                linea.Id = item.IdAlergia;
                linea.Descripcion = item.Nombre;
                dropDown.Add(linea);
            }

            return dropDown;
        }
        public Response<AlergiaDTO> Get(int idAlergia)
        {
            throw new NotImplementedException();
        }

        public Response<List<AlergiaDTO>> Search(string textoBusqueda)
        {
            var response = new Response<List<AlergiaDTO>>();

            try
            {
                string url = _connectionService.GetConnection();
                string jsonString = JsonConvert.SerializeObject(textoBusqueda);
                HttpContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                var httpResult = _senderApiCommon.PostApi(url + "/Alergia/SearchAsync", content);

                if (httpResult.IsSuccessStatusCode)
                {
                    var responseContent = httpResult.Content.ReadAsStringAsync();
                    response = JsonConvert.DeserializeObject<Response<List<AlergiaDTO>>>(responseContent.Result);
                }
                else
                {
                    response.Message = $"Error en la respuesta del servidor: {httpResult.StatusCode}";
                }

            }
            catch (Exception ex)
            {
                response.Message = "Hubo un error con la búsqueda de Alergia";

            }

            return response;
        }

        #endregion

        #region Metodos Asincronicos

        public async Task<Response<bool>> CreateAsync(AlergiaDTO alergiaDTO)
        {
            var response = new Response<bool>();
            try
            {
                string url = _connectionService.GetConnection();
                string jsonString = JsonConvert.SerializeObject(alergiaDTO);
                HttpContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                var httpResult = await _senderApiCommon.PostApiAsync(url + "/Alergia/CreateAsync", content);

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
                response.Message = "Hubo un error al crear Alergia";

            }
            return response;
        }

        public async Task<Response<bool>> DeleteAsync(int idAlergia)
        {
            var response = new Response<bool>();
            try
            {
                string url = _connectionService.GetConnection();
                string jsonString = JsonConvert.SerializeObject(idAlergia);
                HttpContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                var httpResult = await _senderApiCommon.PostApiAsync(url + "/Alergia/DeleteAsync", content);

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
                response.Message = "Hubo un error al eliminar Alergia";
            }

            return response;
        }

        public async Task<Response<bool>> ExistsAsync(AlergiaDTO alergiaDTO)
        {
            var response = new Response<bool>();
            try
            {
                string url = _connectionService.GetConnection();
                string jsonString = JsonConvert.SerializeObject(alergiaDTO);
                HttpContent content = new StringContent(jsonString, Encoding.UTF8, "application/json"); // Asegúrate de inicializar `content` si es necesario

                // Realiza la solicitud POST asíncrona
                var httpResult = await _senderApiCommon.PostApiAsync(url + "/Alergia/ExistsAsync", content);

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
                response.Message = "Hubo un error al obtener todos las Alergias";
            }

            return response;
        }

        public async Task<Response<List<AlergiaDTO>>> GetAllAsync()
        {
            var response = new Response<List<AlergiaDTO>>();
            try
            {
                string url = _connectionService.GetConnection();
                HttpContent content = null; // Asegúrate de inicializar `content` si es necesario

                // Realiza la solicitud POST asíncrona
                var httpResult = await _senderApiCommon.PostApiAsync(url + "/Alergia/GetAllAsync", content);

                if (httpResult.IsSuccessStatusCode)
                {
                    var responseContent = await httpResult.Content.ReadAsStringAsync();
                    response = JsonConvert.DeserializeObject<Response<List<AlergiaDTO>>>(responseContent);
                }
                else
                {
                    response.Message = $"Error en la respuesta del servidor: {httpResult.StatusCode}";
                }
            }
            catch (Exception ex)
            {
                response.Message = "Hubo un error al obtener todos las Alergias";
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
                linea.Id = item.IdAlergia;
                linea.Descripcion = item.Nombre;
                dropDown.Add(linea);
            }

            return dropDown;
        }

        public async Task<Response<AlergiaDTO>> GetAsync(int IdAlergia)
        {
            var response = new Response<AlergiaDTO>();
            try
            {
                string url = _connectionService.GetConnection();
                string jsonString = JsonConvert.SerializeObject(IdAlergia);
                HttpContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                // Realiza la solicitud POST asíncrona
                var httpResult = await _senderApiCommon.PostApiAsync(url + "/Alergia/GetAsync", content);

                if (httpResult.IsSuccessStatusCode)
                {
                    var responseContent = await httpResult.Content.ReadAsStringAsync();
                    response = JsonConvert.DeserializeObject<Response<AlergiaDTO>>(responseContent);
                }
                else
                {
                    response.Message = $"Error en la respuesta del servidor: {httpResult.StatusCode}";
                }
            }
            catch (Exception ex)
            {
                response.Message = "Hubo un error al obtener todos las Alergias";
            }

            return response;
        }

        public async Task<Response<bool>> UpdateAsync(AlergiaDTO alergiaDTO)
        {
            var response = new Response<bool>();
            try
            {
                //AlergiaEditarRequest request = new AlergiaEditarRequest();
                //request.IdAlergia = idAlergia;
                //request.DetalleAlergia = alergiaDTO;

                string url = _connectionService.GetConnection();
                string jsonString = JsonConvert.SerializeObject(alergiaDTO);
                HttpContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                var httpResult = await _senderApiCommon.PostApiAsync(url + "/Alergia/UpdateAsync", content);

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
                response.Message = "Hubo un error al obtener todos las Alergias";

            }

            return response;
        }

        public async Task<Response<List<AlergiaDTO>>> SearchAsync(string textoBusqueda)
        {
            var response = new Response<List<AlergiaDTO>>();

            try
            {
                string url = _connectionService.GetConnection();
                string jsonString = JsonConvert.SerializeObject(textoBusqueda);
                HttpContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                var httpResult = await _senderApiCommon.PostApiAsync(url + "/Alergia/SearchAsync", content);

                if (httpResult.IsSuccessStatusCode)
                {
                    var responseContent = await httpResult.Content.ReadAsStringAsync();
                    response = JsonConvert.DeserializeObject<Response<List<AlergiaDTO>>>(responseContent);
                }
                else
                {
                    response.Message = $"Error en la respuesta del servidor: {httpResult.StatusCode}";
                }

            }
            catch (Exception ex)
            {
                response.Message = "Hubo un error con la búsqueda de Alergia";

            }

            return response;
        }

        #endregion
    }
}
