using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using POC_PS_Automation.Common;
using POC_PS_Automation.Domain.RequestObjects;
using POC_PS_Automation.Domain.ViewModel;
using POC_PS_Automation.Models;

namespace POC_PS_Automation.Controllers
{
    public class HomeController : Controller
    {
        private readonly string _package_ext_psfile;
        private readonly string _policy_ext_psfile ;
        private readonly string _folder_perm_ext_psfile ;
        private readonly string _package_cmp_psfile;
        private readonly string _policy_cmp_psfile ;
        private readonly string _folder_perm_cmp_psfile;
        private readonly string _input_scripts_path;

        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration configuration;

        private readonly int _loadDelayDefault = 0;
        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            this.configuration = configuration;
            _loadDelayDefault =  this.configuration["DefaultParameters:LoadDelayInSeconds"] ==null?0:int.Parse(this.configuration["DefaultParameters:LoadDelayInSeconds"])*1000;

            _package_ext_psfile = configuration["DefaultParameters:Package_ext_psfile"];
            _policy_ext_psfile = configuration["DefaultParameters:Policy_ext_psfile"];
            _folder_perm_ext_psfile = configuration["DefaultParameters:Folder_perm_ext_psfile"];
            _package_cmp_psfile = configuration["DefaultParameters:Package_cmp_psfile"];
            _policy_cmp_psfile = configuration["DefaultParameters:Policy_cmp_psfile"];
            _folder_perm_cmp_psfile = configuration["DefaultParameters:Folder_perm_cmp_psfile"];
            _input_scripts_path = configuration["DefaultParameters:Input_scripts_path"]; ;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Index()
        {
            if (TempData["TargetTab"] == null) TempData["TargetTab"] = "Extract";
            if (TempData["Delay"] == null) TempData["Delay"] = 0;
            return View();
        }

        [HttpPost]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Compare(string Host2008, string Host2016, string CompareHostPath)
        {
            PSLibrary psl = new PSLibrary();
            FileLibrary fl = new FileLibrary();

            fl.UpdateInputCompareHostFile(Host2008, Host2016);
            fl.UpdateInputFolderPathFile(CompareHostPath);

            psl.ExecutePowershellScript(_input_scripts_path + _package_cmp_psfile);
            psl.ExecutePowershellScript(_input_scripts_path+_policy_cmp_psfile);
            psl.ExecutePowershellScript(_input_scripts_path+_folder_perm_cmp_psfile);
            TempData["TargetTab"] = "Compare";
            TempData["Delay"] = _loadDelayDefault;
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
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
            TempData["Delay"] = _loadDelayDefault;
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public PartialViewResult ExtractPolicyDetails()
        {
            //Load Policy Extract
            FileLibrary fl = new FileLibrary();
            var x = fl.ReadPolicyExtract();
            return PartialView("_PartialPolicies", x);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public PartialViewResult ExtractPackageDetails()
        {
            //Load Policy
            FileLibrary fl = new FileLibrary();
            var x = fl.ReadPackageExtract();
            return PartialView("_PartialPackages", x);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public PartialViewResult ExtractPermissionDetails()
        {
            //Load Policy
            FileLibrary fl = new FileLibrary();
            var x = fl.ReadPermissionExtact();
            return PartialView("_PartialPermissions", x);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
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
