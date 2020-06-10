using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace POC_PS_Automation.Domain
{
    public class ServerProcessingInfra
    {
        public string Hostname { get; set; }
        public string Name { get; set; }
        public string NumberOfCores { get; set; }
        public string RAMInGB { get; set; }
    }
}
