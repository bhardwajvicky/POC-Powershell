using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace POC_PS_Automation.Domain
{
    public class Disk
    {
        public string Hostname { get; set; }
        public string PartitionName { get; set; }
        public string UsedSpace { get; set; }
        public string FreeSpace { get; set; }
        public string TotalSpace { get; set; }
    }
}
