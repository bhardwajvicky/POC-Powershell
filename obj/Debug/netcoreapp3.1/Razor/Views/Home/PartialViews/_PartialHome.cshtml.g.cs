#pragma checksum "C:\Users\Vikas\source\repos\POC-PS-Automation\POC-PS-Automation\Views\Home\PartialViews\_PartialHome.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "dbe620dcf840cd4dcaf5e26bbf73cd826e1e6987"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_PartialViews__PartialHome), @"mvc.1.0.view", @"/Views/Home/PartialViews/_PartialHome.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\Vikas\source\repos\POC-PS-Automation\POC-PS-Automation\Views\_ViewImports.cshtml"
using POC_PS_Automation;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Vikas\source\repos\POC-PS-Automation\POC-PS-Automation\Views\_ViewImports.cshtml"
using POC_PS_Automation.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dbe620dcf840cd4dcaf5e26bbf73cd826e1e6987", @"/Views/Home/PartialViews/_PartialHome.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9e3812c43322eace2ca87955b8e9ff4af9dc1ab2", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_PartialViews__PartialHome : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"



<div class=""row"">
    <div class=""col-12 alert alert-primary"">Analyse Windows Servers</div>
</div>
<br />
<div class=""row"">
    <div class=""col-5"" style=""border:1px solid black;"">
        <br /><br />
        <div class=""row"">
            <div class=""col-8"">Choose Server version</div>
            <div class=""col-4"">
                <input type=""radio"" name=""server"" value=""2008"" checked/><label style=""padding-left:6px;""> 2008 </label><br />
                <input type=""radio"" name=""server"" value=""2016"" /><label style=""padding-left:6px;""> 2016 </label>
            </div>
        </div>
    </div>
    <div class=""col-1""></div>
    <div class=""col-6"" style=""border:1px solid black;"">
        <div class=""row"" style=""padding:10px 5px 10px 5px;"">
            <div class=""col-9"">
                <label class=""smallLabels small "">Enter Hostnames</label>
                <input type=""text"" name=""hostnamecsv""");
            BeginWriteAttribute("value", " value=\"", 1058, "\"", 1066, 0);
            EndWriteAttribute();
            WriteLiteral(" placeholder=\"Enter multiple hostnames separted by commas\" style=\"width:100%\" />\r\n                <label class=\"smallLabels small \">Folder Path</label>\r\n                <input type=\"text\" name=\"hostPathCSV\"");
            BeginWriteAttribute("value", " value=\"", 1273, "\"", 1281, 0);
            EndWriteAttribute();
            WriteLiteral(@" placeholder=""Enter folder path"" style=""width:100%"" />
            </div>
            <div class=""col-2"">
                <br />
                <a href=""#"" class=""btn btn-primary"" onclick=""fetchHostDetails();"">Run</a>
            </div>
        </div>
        
    </div>
</div>
<br />
<div>
    <nav>
        <div class=""nav nav-tabs"" id=""nav-tab"" role=""tablist"">
            <a class=""nav-item nav-link active"" id=""nav-policies-tab"" data-toggle=""tab"" href=""#nav-policies"" role=""tab"" aria-controls=""nav-policies"" aria-selected=""false"">Policies</a>
            <a class=""nav-item nav-link"" id=""nav-packages-tab"" data-toggle=""tab"" href=""#nav-packages"" role=""tab"" aria-controls=""nav-contact"" aria-selected=""false"">Packages</a>
            <a class=""nav-item nav-link"" id=""nav-permission-tab"" data-toggle=""tab"" href=""#nav-permission"" role=""tab"" aria-controls=""nav-contact"" aria-selected=""false"">Permission</a>
        </div>
    </nav>
    <div class=""tab-content"" id=""nav-tabContent"">
        <div class=""");
            WriteLiteral("tab-pane fade show active\" id=\"nav-policies\" role=\"tabpanel\" aria-labelledby=\"nav-policies-tab\" style=\"padding-left:15px; padding-right:15px;\">\r\n");
            WriteLiteral("        </div>\r\n        <div class=\"tab-pane fade\" id=\"nav-packages\" role=\"tabpanel\" aria-labelledby=\"nav-packages-tab\" style=\"padding-left:15px; padding-right:15px;\">\r\n");
            WriteLiteral("        </div>\r\n        <div class=\"tab-pane fade\" id=\"nav-permission\" role=\"tabpanel\" aria-labelledby=\"nav-permission-tab\" style=\"padding-left:15px; padding-right:15px;\">\r\n");
            WriteLiteral("        </div>\r\n    </div>\r\n</div>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
