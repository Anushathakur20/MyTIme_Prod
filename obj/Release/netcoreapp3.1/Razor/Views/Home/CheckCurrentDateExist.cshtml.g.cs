#pragma checksum "C:\Anusha\MyTIMEAPP\MyTIMEAPP_prod\MyTIMEAPP\Views\Home\CheckCurrentDateExist.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a674af5b3915c84b2cf5bd9d18ded5ed990b4d0a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_CheckCurrentDateExist), @"mvc.1.0.view", @"/Views/Home/CheckCurrentDateExist.cshtml")]
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
#line 1 "C:\Anusha\MyTIMEAPP\MyTIMEAPP_prod\MyTIMEAPP\Views\_ViewImports.cshtml"
using MyTIMEAPP;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Anusha\MyTIMEAPP\MyTIMEAPP_prod\MyTIMEAPP\Views\_ViewImports.cshtml"
using MyTIMEAPP.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a674af5b3915c84b2cf5bd9d18ded5ed990b4d0a", @"/Views/Home/CheckCurrentDateExist.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"329199749451f3ff70c760535e987906c315e34d", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_CheckCurrentDateExist : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@" <script type=""text/javascript"">
        function Confirm() {
            var input = $(""<input />"");
            input.attr(""type"", ""hidden"").attr(""name"", ""confirm_value"");
            if (confirm(""Do you want to save data?"")) {
                input.val(""Yes"");
            } else {
                input.val(""No"");
            }
            $(""form"")[0].appendChild(input[0]);
        }
    </script>
");
#nullable restore
#line 13 "C:\Anusha\MyTIMEAPP\MyTIMEAPP_prod\MyTIMEAPP\Views\Home\CheckCurrentDateExist.cshtml"
     if (ViewBag.Message != null)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <script type=\"text/javascript\">\r\n            $(function () {\r\n              alert(\"");
#nullable restore
#line 17 "C:\Anusha\MyTIMEAPP\MyTIMEAPP_prod\MyTIMEAPP\Views\Home\CheckCurrentDateExist.cshtml"
                Write(ViewBag.Message);

#line default
#line hidden
#nullable disable
            WriteLiteral("\")\r\n            });\r\n        </script>\r\n");
#nullable restore
#line 20 "C:\Anusha\MyTIMEAPP\MyTIMEAPP_prod\MyTIMEAPP\Views\Home\CheckCurrentDateExist.cshtml"
    }

#line default
#line hidden
#nullable disable
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
