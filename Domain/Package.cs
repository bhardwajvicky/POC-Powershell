using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POC_PS_Automation.Domain
{
    public class Package
    {
        public string Hostname { get; set; }
        public string OSName { get; set; }
        public string OSVersion { get; set; }
        public string PackageName { get; set; }
        public string Version { get; set; }
    }
}

