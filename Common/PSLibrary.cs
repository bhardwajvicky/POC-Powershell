using System;
using System.Diagnostics;
using System.IO;

namespace POC_PS_Automation.Common
{
    public class PSLibrary
    {
        public void ExecutePowershellScript(string scriptPath)
        {
            var startInfo = new ProcessStartInfo()
            {
                FileName = "powershell.exe",
                Arguments = $"-NoProfile -ExecutionPolicy unrestricted -file \"{scriptPath}\"",
                UseShellExecute = false
            };
            Process.Start(startInfo);
        }

        //public void ExecuteTestScript()
        //{
        //    var ps1File = "wwwroot/PSScripts/test.ps1";
        //    var startInfo = new ProcessStartInfo()
        //    {
        //        FileName = "powershell.exe",
        //        Arguments = $"-NoProfile -ExecutionPolicy unrestricted -file \"{ps1File}\"",
        //        UseShellExecute = false
        //    };
        //    Process.Start(startInfo);
        //}

        public void ExecuteCompareScript()
        {
            var ps1File = "wwwroot/PSScripts/test.ps1";
            var startInfo = new ProcessStartInfo()
            {
                FileName = "powershell.exe",
                Arguments = $"-NoProfile -ExecutionPolicy unrestricted -file \"{ps1File}\"",
                UseShellExecute = false
            };
            Process.Start(startInfo);
        }

        public void ExecuteFetchHostDetailScript(string hostNameCSV)
        {
            var ps1File = "wwwroot/PSScripts/test.ps1";
            var startInfo = new ProcessStartInfo()
            {
                FileName = "powershell.exe",
                Arguments = $"-NoProfile -ExecutionPolicy unrestricted -file \"{ps1File}\"",
                UseShellExecute = false
            };
            Process.Start(startInfo);
        }
        public string ReadTestScriptOutput()
        {
            String result = string.Empty;
            try
            {   // Open the text file using a stream reader.
                using (StreamReader sr = new StreamReader("wwwroot/ScriptOutput/Testoutput.csv"))
                {
                    // Read the stream to a string, and write the string to the console.
                    result = sr.ReadToEnd();
                }
            }
            catch (IOException e)
            {
                result = "File reading issue.";
            }
            
            return result.Replace("\n", "<br/>");
        }
    }
}
