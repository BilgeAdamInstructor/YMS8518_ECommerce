using System;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ECommerce.Helper
{
    public class ViewHelper
    {
        public static string PageJavascript(ViewContext viewContext)
        {
            string[] controllerViewNames = ControllerViewNames(viewContext);

            string html = "<script src=\"/js/page/" + controllerViewNames[0] + "_" + controllerViewNames[1] + ".js?_dt=" + DateTime.UtcNow.Ticks + "\"></script>";
            html += "<script>";
            html += "$(document).ready(function () {";
            html += controllerViewNames[0] + "_" + controllerViewNames[1] + ".Init();";
            html += "});";
            html += "</script>";
            return html;
        }

        private static string[] ControllerViewNames(ViewContext viewContext)
        {
            var cad = (ControllerActionDescriptor) viewContext.ActionDescriptor;

            return new[] { cad.ControllerName, cad.ActionName };
        }
    }
}