using System;
using ECommerce.Data.Enum;
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

        public static string ExposeMessage(Data.DTO.Message_Response message)
        {
            string holderClass = "";
            string icon = "";
            if (message.MessageType == MessageType.Danger)
            {
                holderClass = "alert-outline-danger";
                icon = "flaticon-warning";
            }
            else if (message.MessageType == MessageType.Information)
            {
                holderClass = "alert-outline-info";
                icon = "flaticon-questions-circular-button";
            }
            else if (message.MessageType == MessageType.Success)
            {
                holderClass = "alert-outline-success";
                icon = "flaticon2-check-mark";
            }
            else if (message.MessageType == MessageType.Warning)
            {
                holderClass = "alert-outline-warning";
                icon = "flaticon-warning";
            }
            
            string html = "<div class=\"alert " + holderClass + " fade show\" role=\"alert\">";
            html += "<div class=\"alert-icon\"><i class=\"" + icon + "\"></i></div>";
            html += "<div class=\"alert-text\">" + message.Message + "</div>";
            html += "</div>";

            return html;
        }
    }
}