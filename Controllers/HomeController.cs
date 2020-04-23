using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using POC_PS_Automation.Common;
using POC_PS_Automation.Domain.RequestObjects;
using POC_PS_Automation.Domain.ViewModel;
using POC_PS_Automation.Models;

namespace POC_PS_Automation.Controllers
{
    public class HomeController : Controller
    {
        private readonly string _package_ext_psfile = "Package_ext.ps1";
        private readonly string _policy_ext_psfile = "Policy_ext.ps1";
        private readonly string _folder_perm_ext_psfile = "Folder_Perm_ext.ps1";
        private readonly string _package_cmp_psfile = "Package_cmp.ps1";
        private readonly string _policy_cmp_psfile = "Policy_cmp.ps1";
        private readonly string _folder_perm_cmp_psfile = "Folder_Perm_cmp.ps1";
        private readonly string _input_scripts_path = "wwwroot/PSScripts/";

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (TempData["TargetTab"] == null) TempData["TargetTab"] = "Extract";
            if (TempData["Delay"] == null) TempData["Delay"] = 0;
            return View();
        }

        [HttpPost]
        public IActionResult Compare(string Host2008, string Host2016)
        {
            PSLibrary psl = new PSLibrary();
            FileLibrary fl = new FileLibrary();

            fl.UpdateInputCompareHostFile(Host2008, Host2016);

            psl.ExecutePowershellScript(_input_scripts_path + _package_cmp_psfile);
            psl.ExecutePowershellScript(_input_scripts_path+_policy_cmp_psfile);
            psl.ExecutePowershellScript(_input_scripts_path+_folder_perm_cmp_psfile);
            TempData["TargetTab"] = "Compare";
            TempData["Delay"] = 5000;
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult RunExtract([Bind("HostCSV,FolderPath")] HostExtractRequest req)
        {
            PSLibrary psl = new PSLibrary();
            FileLibrary fl = new FileLibrary();
            //Write Input Files
            fl.UpdateInputHostNameFile(req.HostCSV);
            fl.UpdateInputFolderPathFile(req.FolderPath);


            //Run Script
            psl.ExecutePowershellScript(_input_scripts_path + _package_ext_psfile);
            psl.ExecutePowershellScript(_input_scripts_path + _policy_ext_psfile);
            psl.ExecutePowershellScript(_input_scripts_path + _folder_perm_ext_psfile);

            TempData["TargetTab"] = "Extract";
            TempData["Delay"] = 5000;
            return RedirectToAction("Index");
        }

        public PartialViewResult ExtractPolicyDetails()
        {
            //Load Policy Extract
            FileLibrary fl = new FileLibrary();
            var x = fl.ReadPolicyExtract();
            return PartialView("_PartialPolicies", x);
        }

        public PartialViewResult ExtractPackageDetails()
        {
            //Load Policy
            FileLibrary fl = new FileLibrary();
            var x = fl.ReadPackageExtract();
            return PartialView("_PartialPackages", x);
        }

        public PartialViewResult ExtractPermissionDetails()
        {
            //Load Policy
            FileLibrary fl = new FileLibrary();
            var x = fl.ReadPermissionExtact();
            return PartialView("_PartialPermissions", x);
        }


        public PartialViewResult PartialFetchCompareResults()
        {
            //Load Policy
            FileLibrary fl = new FileLibrary();
            VMCompareResult vm = new VMCompareResult();
            vm.PolicyCompareResult = fl.ReadPolicyCompare();
            vm.PackageCompareResult = fl.ReadPackageCompare();
            vm.FolderCompareResult = fl.ReadFolderCompare();
            return PartialView("_PartialCompareResult", vm);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
