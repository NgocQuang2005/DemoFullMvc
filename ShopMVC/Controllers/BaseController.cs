﻿using Microsoft.AspNetCore.Mvc;

namespace ShopMVC.Controllers
{
    public class BaseController : Controller
    {
        public void SetAlert(string mes , string type)
        {
            TempData["AlertMessage"] = mes;
            if (type == "success")
            {
                TempData["Type"] = "alert-success";
            }
            if (type == "warning")
            {
                TempData["Type"] = "alert-warning";
            }
            if (type == "error")
            {
                TempData["Type"] = "alert-error";
            }
        }
    }
}
