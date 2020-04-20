using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using POC_PS_Automation.Common;
using POC_PS_Automation.Models;

namespace POC_PS_Automation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Compare()
        {
            PSLibrary psl = new PSLibrary();
            psl.ExecuteTestScript();
            TempData["output"] = psl.ReadTestScriptOutput();
            return RedirectToAction("Index");
        }

        public ContentResult RefreshPolicies()
        {
            PSLibrary psl = new PSLibrary();
            psl.ExecuteTestScript();
            return Content(psl.ReadTestScriptOutput());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
