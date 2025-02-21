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
    public class MedicamentoService : IMedicamentoService
    {
        private readonly IConnectionService _connectionService;
        private readonly ISenderApi _senderApiCommon;

        public MedicamentoService(IConnectionService connectionServices, ISenderApi senderApiCommon)
        {
            _connectionService = connectionServices;
            _senderApiCommon = senderApiCommon;
        }


        #region Metodos Sincronicos

        public Response<bool> Update(MedicamentoDTO medicamentoDTO)
        {
            var response = new Response<bool>();
            try
            {
                string url = _connectionService.GetConnection();
                string jsonString = JsonConvert.SerializeObject(medicamentoDTO);
                HttpContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                var httpResult = _senderApiCommon.PostApi(url + "/Medicamento/UpdateAsync", content);

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
                response.Message = "Hubo un error al obtener todos las Medicamentos";

            }

            return response;
        }

        public Response<bool> Create(MedicamentoDTO medicamentoDTO)
        {
            var response = new Response<bool>();
            try
            {
                string url = _connectionService.GetConnection();
                string jsonString = JsonConvert.SerializeObject(medicamentoDTO);
                HttpContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                var httpResult = _senderApiCommon.PostApi(url + "/Medicamento/CreateAsync", content);

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
                response.Message = "Hubo un error al crear Medicamento";

            }
            return response;
        }

        public Response<bool> Delete(int idMedicamento)
        {
            var response = new Response<bool>();
            try
            {
                string url = _connectionService.GetConnection();
                string jsonString = JsonConvert.SerializeObject(idMedicamento);
                HttpContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                var httpResult = _senderApiCommon.PostApi(url + "/Medicamento/DeleteAsync", content);

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
                response.Message = "Hubo un error al eliminar Medicamento";
            }

            return response;

        }

        public Response<bool> Exists(MedicamentoDTO medicamentoDTO)
        {
            var response = new Response<bool>();
            try
            {
                string url = _connectionService.GetConnection();
                HttpContent content = null; // Asegúrate de inicializar `content` si es necesario

                // Realiza la solicitud POST asíncrona
                var httpResult = _senderApiCommon.PostApi(url + "/Medicamento/ExistsAsync", content);

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
                response.Message = "Hubo un error al obtener todos las Medicamentos";
            }

            return response;
        }

        public Response<List<MedicamentoDTO>> GetAll()
        {
            var response = new Response<List<MedicamentoDTO>>();
            try
            {
                string url = _connectionService.GetConnection();
                HttpContent content = null; // Asegúrate de inicializar `content` si es necesario

                // Realiza la solicitud POST asíncrona
                var httpResult = _senderApiCommon.PostApi(url + "/Medicamento/GetAllAsync", content);

                if (httpResult.IsSuccessStatusCode)
                {
                    var responseContent = httpResult.Content.ReadAsStringAsync();
                    response = JsonConvert.DeserializeObject<Response<List<MedicamentoDTO>>>(responseContent.Result);
                }
                else
                {
                    response.Message = $"Error en la respuesta del servidor: {httpResult.StatusCode}";
                }
            }
            catch (Exception ex)
            {
                response.Message = "Hubo un error al obtener todos las Medicamentos";
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
                linea.Id = item.IdMedicamento;
                linea.Descripcion = item.Nombre;
                dropDown.Add(linea);
            }

            return dropDown;
        }
        public Response<MedicamentoDTO> Get(int idMedicamento)
        {
            throw new NotImplementedException();
        }

        public Response<List<MedicamentoDTO>> Search(string textoBusqueda)
        {
            var response = new Response<List<MedicamentoDTO>>();

            try
            {
                string url = _connectionService.GetConnection();
                string jsonString = JsonConvert.SerializeObject(textoBusqueda);
                HttpContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                var httpResult = _senderApiCommon.PostApi(url + "/Medicamento/SearchAsync", content);

                if (httpResult.IsSuccessStatusCode)
                {
                    var responseContent = httpResult.Content.ReadAsStringAsync();
                    response = JsonConvert.DeserializeObject<Response<List<MedicamentoDTO>>>(responseContent.Result);
                }
                else
                {
                    response.Message = $"Error en la respuesta del servidor: {httpResult.StatusCode}";
                }

            }
            catch (Exception ex)
            {
                response.Message = "Hubo un error con la búsqueda de Medicamento";

            }

            return response;
        }

        #endregion

        #region Metodos Asincronicos

        public async Task<Response<bool>> CreateAsync(MedicamentoDTO medicamentoDTO)
        {
            var response = new Response<bool>();
            try
            {
                string url = _connectionService.GetConnection();
                string jsonString = JsonConvert.SerializeObject(medicamentoDTO);
                HttpContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                var httpResult = await _senderApiCommon.PostApiAsync(url + "/Medicamento/CreateAsync", content);

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
                response.Message = "Hubo un error al crear Medicamento";

            }
            return response;
        }

        public async Task<Response<bool>> DeleteAsync(int idMedicamento)
        {
            var response = new Response<bool>();
            try
            {
                string url = _connectionService.GetConnection();
                string jsonString = JsonConvert.SerializeObject(idMedicamento);
                HttpContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                var httpResult = await _senderApiCommon.PostApiAsync(url + "/Medicamento/DeleteAsync", content);

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
                response.Message = "Hubo un error al eliminar Medicamento";
            }

            return response;
        }

        public async Task<Response<bool>> ExistsAsync(MedicamentoDTO medicamentoDTO)
        {
            var response = new Response<bool>();
            try
            {
                string url = _connectionService.GetConnection();
                string jsonString = JsonConvert.SerializeObject(medicamentoDTO);
                HttpContent content = new StringContent(jsonString, Encoding.UTF8, "application/json"); // Asegúrate de inicializar `content` si es necesario

                // Realiza la solicitud POST asíncrona
                var httpResult = await _senderApiCommon.PostApiAsync(url + "/Medicamento/ExistsAsync", content);

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
                response.Message = "Hubo un error al obtener todos las Medicamentos";
            }

            return response;
        }

        public async Task<Response<List<MedicamentoDTO>>> GetAllAsync()
        {
            var response = new Response<List<MedicamentoDTO>>();
            try
            {
                string url = _connectionService.GetConnection();
                HttpContent content = null; // Asegúrate de inicializar `content` si es necesario

                // Realiza la solicitud POST asíncrona
                var httpResult = await _senderApiCommon.PostApiAsync(url + "/Medicamento/GetAllAsync", content);

                if (httpResult.IsSuccessStatusCode)
                {
                    var responseContent = await httpResult.Content.ReadAsStringAsync();
                    response = JsonConvert.DeserializeObject<Response<List<MedicamentoDTO>>>(responseContent);
                }
                else
                {
                    response.Message = $"Error en la respuesta del servidor: {httpResult.StatusCode}";
                }
            }
            catch (Exception ex)
            {
                response.Message = "Hubo un error al obtener todos las Medicamentos";
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
                linea.Id = item.IdMedicamento;
                linea.Descripcion = item.Nombre;
                dropDown.Add(linea);
            }

            return dropDown;
        }

        public async Task<Response<MedicamentoDTO>> GetAsync(int IdMedicamento)
        {
            var response = new Response<MedicamentoDTO>();
            try
            {
                string url = _connectionService.GetConnection();
                string jsonString = JsonConvert.SerializeObject(IdMedicamento);
                HttpContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                // Realiza la solicitud POST asíncrona
                var httpResult = await _senderApiCommon.PostApiAsync(url + "/Medicamento/GetAsync", content);

                if (httpResult.IsSuccessStatusCode)
                {
                    var responseContent = await httpResult.Content.ReadAsStringAsync();
                    response = JsonConvert.DeserializeObject<Response<MedicamentoDTO>>(responseContent);
                }
                else
                {
                    response.Message = $"Error en la respuesta del servidor: {httpResult.StatusCode}";
                }
            }
            catch (Exception ex)
            {
                response.Message = "Hubo un error al obtener todos las Medicamentos";
            }

            return response;
        }

        public async Task<Response<bool>> UpdateAsync(MedicamentoDTO medicamentoDTO)
        {
            var response = new Response<bool>();
            try
            {
                //MedicamentoEditarRequest request = new MedicamentoEditarRequest();
                //request.IdMedicamento = idMedicamento;
                //request.DetalleMedicamento = medicamentoDTO;

                string url = _connectionService.GetConnection();
                string jsonString = JsonConvert.SerializeObject(medicamentoDTO);
                HttpContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                var httpResult = await _senderApiCommon.PostApiAsync(url + "/Medicamento/UpdateAsync", content);

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
                response.Message = "Hubo un error al obtener todos las Medicamentos";

            }

            return response;
        }

        public async Task<Response<List<MedicamentoDTO>>> SearchAsync(string textoBusqueda)
        {
            var response = new Response<List<MedicamentoDTO>>();

            try
            {
                string url = _connectionService.GetConnection();
                string jsonString = JsonConvert.SerializeObject(textoBusqueda);
                HttpContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                var httpResult = await _senderApiCommon.PostApiAsync(url + "/Medicamento/SearchAsync", content);

                if (httpResult.IsSuccessStatusCode)
                {
                    var responseContent = await httpResult.Content.ReadAsStringAsync();
                    response = JsonConvert.DeserializeObject<Response<List<MedicamentoDTO>>>(responseContent);
                }
                else
                {
                    response.Message = $"Error en la respuesta del servidor: {httpResult.StatusCode}";
                }

            }
            catch (Exception ex)
            {
                response.Message = "Hubo un error con la búsqueda de Medicamento";

            }

            return response;
        }

        #endregion
    }
}
