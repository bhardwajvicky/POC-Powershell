Get-Process -Name WmiPrvSE | Select-Object -Property BasePriority,Id,SessionId,WorkingSet |
  Export-Csv -Path .\WmiData.csv -NoTypeInformation
$var1 = gpresult /r
$var1 | out-file -filepath ".\wwwroot\ScriptOutput\Testoutput.csv"