using Macaner.GeronAppWeb.Service.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Macaner.GeronAppWeb.Service.ApiServices.ConnectionService;

namespace Macaner.GeronAppWeb.Service.ApiServices
{

    public class ConnectionService : IConnectionService
    {
        private IConfiguration _configuration;

        public ConnectionService(IConfiguration configuration)
        {
            try
            {
                _configuration = configuration;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

                throw;
            }
        }

        public string GetConnection()
        {
            string apiSenderoAPSValor = "";
            var endPointsSection = _configuration.GetSection("EndPoints");
            if (endPointsSection.Exists())
            {
                //endPointsSection.GetSection("ApiSenderoAPS").Value.ToString();
                var apiSenderoAPS = endPointsSection.GetSection("ApiGeronApp");



                apiSenderoAPSValor = apiSenderoAPS.Value;
                //Console.WriteLine(apiSenderoAPS);
            }

            //return _configuration.GetSection("EndPoints").GetChildren().ToString();
            return apiSenderoAPSValor;
        }
    }

}
