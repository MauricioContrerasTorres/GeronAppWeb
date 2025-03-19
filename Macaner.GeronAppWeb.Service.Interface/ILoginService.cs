using Macaner.GeronAppWeb.Shared.Common;
using Macaner.GeronAppWeb.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Macaner.GeronAppWeb.Service.Interface
{
    public interface ILoginService
    {
        #region Metodos Sincronos
        Response<string> Login(LoginDTO loginDTO);
        #endregion

        #region Metodos Asincronos
        Task<Response<string>> LoginAsync(LoginDTO loginDTO);
        #endregion
    }
}
