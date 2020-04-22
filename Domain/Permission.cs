using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POC_PS_Automation.Domain
{
    public class Permission
    {
        public string HostName { get; set; }
        public string FolderName { get; set; }
        public string GroupOrUser { get; set; }
        public string Permissions { get; set; }
    }
}
