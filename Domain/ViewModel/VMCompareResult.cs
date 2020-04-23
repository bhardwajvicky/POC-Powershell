using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POC_PS_Automation.Domain.ViewModel
{
    public class VMCompareResult
    {
        public IEnumerable<ComparePackageRow> PackageCompareResult { get; set; }
        public IEnumerable<ComparePolicyRow> PolicyCompareResult { get; set; }
        public IEnumerable<FolderPermissionCompareRow> FolderCompareResult { get; set; }
    }
}
