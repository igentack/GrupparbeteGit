﻿using Microsoft.AspNetCore.Mvc;

namespace Gitgruppen.Controllers
{
    public class SettingsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
