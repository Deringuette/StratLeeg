using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StrategicLegion.Helpers
{
    public class HTMLHelper
    {
        public static string ImageLink(string controllerName, string actionName, string imageName)
        {
            return String.Format("<a href=\"@Url.Action(\"{1}\",\"{0}\")\"><img src=\"@Url.Content(\"~/Content/Images/{2}\")\"/></a>", controllerName, actionName, imageName);
        }
    }
}