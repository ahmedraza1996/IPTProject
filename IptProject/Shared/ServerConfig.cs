using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace IptProject.Shared
{
    public class ServerConfig
    {
        public static string GetBaseUrl()
        {
            string Ip = ConfigurationManager.AppSettings["serverIP"].ToString();
            string port = ConfigurationManager.AppSettings["serverPort"].ToString();

            string baseurl = "https://" + Ip + ":" + port + "/api/";
            return baseurl;
        }
    }
}