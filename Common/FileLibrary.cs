using CsvHelper;
using POC_PS_Automation.Domain;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace POC_PS_Automation.Common
{
    public class FileLibrary
    {
        private readonly string _input_files_path = "wwwroot/InputFiles/";
        private readonly string _input_folderpath_file = "Input_FolderPath.txt";
        private readonly string _input_host_file = "Input_FolderPath.txt";
        private readonly string _input_host_cmp_file = "Input_FolderPath.txt";

        private CsvReader getTextReaderForFile(string path)
        {
            var content = File.ReadAllLines(path);
            content = content.Skip(1).ToArray();
            TextReader reader = new StringReader(string.Join("\r\n", content));
            var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture);
            csvReader.Configuration.HasHeaderRecord = false;
            return csvReader;
        }

        public IEnumerable<Policy> ReadPolicyExtract()
        {
            var path = "wwwroot/ScriptOutput/Output_Policy_ext.csv";
            if (File.Exists(path))
            {
                return getTextReaderForFile(path).GetRecords<Policy>();
            }
            return null;
        }

        public IEnumerable<Permission> ReadPermissionExtact()
        {
            var path = "wwwroot/ScriptOutput/Output_Folderperm_ext.csv";
            if (File.Exists(path))
            {
                return getTextReaderForFile(path).GetRecords<Permission>();
            }
            return null;
        }

        public IEnumerable<Package> ReadPackageExtract()
        {
            var path = "wwwroot/ScriptOutput/Output_package_ext.csv";
            if (File.Exists(path))
            {
                return getTextReaderForFile(path).GetRecords<Package>();
            }
            return null;
        }

        public IEnumerable<ComparePolicyRow> ReadPolicyCompare()
        {
            var path = "wwwroot/ScriptOutput/Output_Policy_cmp.csv";
            if (File.Exists(path))
            {
                return getTextReaderForFile(path).GetRecords<ComparePolicyRow>();
            }
            return null;
        }

        public IEnumerable<ComparePackageRow> ReadPackageCompare()
        {
            var path = "wwwroot/ScriptOutput/Output_package_cmp.csv";
            if (File.Exists(path))
            {
                return getTextReaderForFile(path).GetRecords<ComparePackageRow>();
            }
            return null;
        }

        public IEnumerable<FolderPermissionCompareRow> ReadFolderCompare()
        {
            var path = "wwwroot/ScriptOutput/output_Folderperm_cmp.csv";
            if (File.Exists(path))
            {
                return getTextReaderForFile(path).GetRecords<FolderPermissionCompareRow>();
            }
            return null;
        }

        public IEnumerable<ServerProcessingInfra> ReadCorRAMExtract()
        {
            var path = "wwwroot/ScriptOutput/Output_Core_Ram.csv";
            if (File.Exists(path))
            {
                return getTextReaderForFile(path).GetRecords<ServerProcessingInfra>();
            }
            return null;
        }

        public IEnumerable<Disk> ReadDiskExtract()
        {
            var path = "wwwroot/ScriptOutput/Output_Disk_Space.csv";
            if (File.Exists(path))
            {
                return getTextReaderForFile(path).GetRecords<Disk>();
            }
            return null;
        }

        public IEnumerable<ServiceAccount> ReadServiceAccountExtract()
        {
            var path = "wwwroot/ScriptOutput/Output_ServiceAccount.csv";
            if (File.Exists(path))
            {
                return getTextReaderForFile(path).GetRecords<ServiceAccount>();
            }
            return null;
        }

        public void UpdateInputHostNameFile(string csvInput)
        {
            var inputHostNameFilePath = "wwwroot/InputFiles/Input_Host.txt";
            string[] hostNameArr = null;
            if (csvInput != null)
            {
                hostNameArr = csvInput.Split(",");
            }

            if (csvInput != null && hostNameArr.Length>0)
            {
                deleteFile(inputHostNameFilePath);
                using (StreamWriter sw = File.CreateText(inputHostNameFilePath))
                {
                    foreach (var h in hostNameArr)
                    {
                        sw.WriteLine(h.Trim());
                    }
                }
            }
        }

        public void UpdateInputFolderPathFile(string folderPath)
        {
            var inputFolderPathFileLocation = "wwwroot/InputFiles/Input_FolderPath.txt";
            
            if (folderPath != null && folderPath.Trim().Length > 0)
            {
                deleteFile(inputFolderPathFileLocation);
                using (StreamWriter sw = File.CreateText(inputFolderPathFileLocation))
                {
                    sw.WriteLine(folderPath.Trim());
                }
            }
        }

        public void UpdateInputCompareHostFile(string host2008, string host2016)
        {
            var inputCompareFilePath = "wwwroot/InputFiles/Input_Host_cmp.txt";

            if (host2008!=null && host2016!=null && host2008.Trim().Length > 0 && host2016.Trim().Length>0)
            {
                deleteFile(inputCompareFilePath);
                using (StreamWriter sw = File.CreateText(inputCompareFilePath))
                {
                    sw.WriteLine(host2008.Trim());
                    sw.WriteLine(host2016.Trim());
                }
            }
        }

        private void deleteFile(string path)
        {
            if(File.Exists(path))
            {
                File.Delete(path);
            }
        }
    }
}
