using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
namespace Utility
{
    public class ServiceUrl
    {
        public string WebApiBaseUrl { get; set; }



        #region Public Constructor
        public ServiceUrl()
        {
            this.WebApiBaseUrl = ConfigurationManager.AppSettings.Get("WebApiBaseUrl").ToString();
        }
        #endregion 

    }
}
