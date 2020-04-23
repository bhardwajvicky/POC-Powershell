using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POC_PS_Automation.Domain
{
    public class FolderPermissionCompareRow
    {
        public string FolderName { get; set; }
        public string GroupOrUser { get; set; }
        public string Permission2008 { get; set; }
        public string Permission2016 { get; set; }
    }
}
