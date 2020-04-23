using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POC_PS_Automation.Domain.RequestObjects
{
    public class HostExtractRequest
    {
        public string HostCSV { get; set; }
        public string FolderPath { get; set; }
    }
}
