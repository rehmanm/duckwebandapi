using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace duck.web.Helper
{
    public class Common
    {
        public static string APIBaseURL = ConfigurationManager.AppSettings["apiBaseUrl"].ToString();
    }
}