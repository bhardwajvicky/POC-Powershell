using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace POC_PS_Automation.Domain
{
    public class Policy
    {
        public string Hostname { get; set; }
        public string OSName { get; set; }
        public string OSVersion { get; set; }
        public string AppliedGroupPolicy { get; set; }
    }
}
