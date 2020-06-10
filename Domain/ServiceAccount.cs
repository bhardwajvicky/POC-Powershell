using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace POC_PS_Automation.Domain
{
    public class ServiceAccount
    {
        public string Hostname { get; set; }
        public string ServiceAccountName { get; set; }
    }
}
