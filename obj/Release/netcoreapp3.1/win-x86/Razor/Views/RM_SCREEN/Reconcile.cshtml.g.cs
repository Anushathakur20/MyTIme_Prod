#pragma checksum "C:\Anusha\MyTIMEAPP (3)\MyTIMEAPP\MyTIMEAPP\Views\RM_SCREEN\Reconcile.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "650ef63926da71f65b5887e6c339cc4c90a5d626"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_RM_SCREEN_Reconcile), @"mvc.1.0.view", @"/Views/RM_SCREEN/Reconcile.cshtml")]
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
#line 1 "C:\Anusha\MyTIMEAPP (3)\MyTIMEAPP\MyTIMEAPP\Views\_ViewImports.cshtml"
using MyTIMEAPP;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Anusha\MyTIMEAPP (3)\MyTIMEAPP\MyTIMEAPP\Views\_ViewImports.cshtml"
using MyTIMEAPP.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"650ef63926da71f65b5887e6c339cc4c90a5d626", @"/Views/RM_SCREEN/Reconcile.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"329199749451f3ff70c760535e987906c315e34d", @"/Views/_ViewImports.cshtml")]
    public class Views_RM_SCREEN_Reconcile : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<MyTIME.Models.MyTime_TB>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/ApproveReject.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<!DOCTYPE html>\r\n<html>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "650ef63926da71f65b5887e6c339cc4c90a5d6263797", async() => {
                WriteLiteral("\r\n     ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "650ef63926da71f65b5887e6c339cc4c90a5d6264060", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "650ef63926da71f65b5887e6c339cc4c90a5d6265863", async() => {
                WriteLiteral(@"
    <div class=""card"">
        <div class=""float-left card-header text-uppercase text-white"" style=""background-color:#224abe;"">
            <h5 style=""text-align:center;"">Reconcile</h5>
        </div>
   </div>
    <div class=""card-body"">
         <div class=""card-body justify-content-md-center"">
            <div class=""d-grid gap-2 d-md-flex justify-content-md-center d-grid gap-2 d-md-block me-md-2 me-1"">
                
                <button class=""btn btn-success btn-responsive justify-content-md-center me-1"" type=""button"" onclick=""approve()"" placeholder=""Approve"" style=""border-radius:10px;margin-right: 20px;white-space: normal !important;"">
                    APPROVE
                </button>
                <button class=""btn btn-danger btn-responsive justify-content-md-center me-1"" type=""button"" onclick=""reject()"" placeholder=""Reject"" style=""border-radius:10px;margin-right: 20px;white-space: normal !important;"">
                    REJECT
                </button>
               
 ");
                WriteLiteral(@"           </div>
            </div>
        <div class=""table-responsive text-nowrap"">
            <table id=""reConcile"" class=""table table-bordered table-hover"">
                <thead style=""position:sticky;top:0;background-color:#224abe;color:white"">
                    <tr>
                        <th>
                            <input type=""checkbox"" id=""select-all"" name=""SelectAll"" onclick=""selectAll()"" />
                        </th>
                        <th>Match?</th>
                        <th>Id</th>
                        <th>DAS ID</th>
                        <th>Employee Name</th>
                        <th>Report Manager</th>
                        <th>Date</th>
                        <th>Login</th>
                        <th>Logout</th>
                        <th>Total Time</th>
                        <th>Overtime</th>
                        <th>Work</th>
                        <th>Meeting</th>
                        <th>Training</th>
                   ");
                WriteLiteral("     <th>Break</th>\r\n                        <th>Auxiliary</th>\r\n                        <th>Comment</th>\r\n                        <th>Status</th>\r\n                    </tr>\r\n                </thead>\r\n                <tbody>\r\n");
#nullable restore
#line 54 "C:\Anusha\MyTIMEAPP (3)\MyTIMEAPP\MyTIMEAPP\Views\RM_SCREEN\Reconcile.cshtml"
                     foreach (var row in ViewBag.Recon)
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                  <tr>\r\n                <td>\r\n                    <input type=\"checkbox\" name=\"ids\" data-id=\"");
#nullable restore
#line 58 "C:\Anusha\MyTIMEAPP (3)\MyTIMEAPP\MyTIMEAPP\Views\RM_SCREEN\Reconcile.cshtml"
                                                          Write(row.ID);

#line default
#line hidden
#nullable disable
                WriteLiteral("\" />\r\n                </td>\r\n                    <td>");
#nullable restore
#line 60 "C:\Anusha\MyTIMEAPP (3)\MyTIMEAPP\MyTIMEAPP\Views\RM_SCREEN\Reconcile.cshtml"
                   Write(row.Match);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 61 "C:\Anusha\MyTIMEAPP (3)\MyTIMEAPP\MyTIMEAPP\Views\RM_SCREEN\Reconcile.cshtml"
                   Write(row.ID);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 62 "C:\Anusha\MyTIMEAPP (3)\MyTIMEAPP\MyTIMEAPP\Views\RM_SCREEN\Reconcile.cshtml"
                   Write(row.DasID);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 63 "C:\Anusha\MyTIMEAPP (3)\MyTIMEAPP\MyTIMEAPP\Views\RM_SCREEN\Reconcile.cshtml"
                   Write(row.Employee_Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td> \r\n                    <td>");
#nullable restore
#line 64 "C:\Anusha\MyTIMEAPP (3)\MyTIMEAPP\MyTIMEAPP\Views\RM_SCREEN\Reconcile.cshtml"
                   Write(row.Report_Manager_Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 65 "C:\Anusha\MyTIMEAPP (3)\MyTIMEAPP\MyTIMEAPP\Views\RM_SCREEN\Reconcile.cshtml"
                   Write(row.Date);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 66 "C:\Anusha\MyTIMEAPP (3)\MyTIMEAPP\MyTIMEAPP\Views\RM_SCREEN\Reconcile.cshtml"
                   Write(row.Login);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 67 "C:\Anusha\MyTIMEAPP (3)\MyTIMEAPP\MyTIMEAPP\Views\RM_SCREEN\Reconcile.cshtml"
                   Write(row.Logout);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 68 "C:\Anusha\MyTIMEAPP (3)\MyTIMEAPP\MyTIMEAPP\Views\RM_SCREEN\Reconcile.cshtml"
                   Write(row.Total_Time);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 69 "C:\Anusha\MyTIMEAPP (3)\MyTIMEAPP\MyTIMEAPP\Views\RM_SCREEN\Reconcile.cshtml"
                   Write(row.Over_Time);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 70 "C:\Anusha\MyTIMEAPP (3)\MyTIMEAPP\MyTIMEAPP\Views\RM_SCREEN\Reconcile.cshtml"
                   Write(row.Works);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 71 "C:\Anusha\MyTIMEAPP (3)\MyTIMEAPP\MyTIMEAPP\Views\RM_SCREEN\Reconcile.cshtml"
                   Write(row.Meeting);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 72 "C:\Anusha\MyTIMEAPP (3)\MyTIMEAPP\MyTIMEAPP\Views\RM_SCREEN\Reconcile.cshtml"
                   Write(row.Training);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 73 "C:\Anusha\MyTIMEAPP (3)\MyTIMEAPP\MyTIMEAPP\Views\RM_SCREEN\Reconcile.cshtml"
                   Write(row.Breaks);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 74 "C:\Anusha\MyTIMEAPP (3)\MyTIMEAPP\MyTIMEAPP\Views\RM_SCREEN\Reconcile.cshtml"
                   Write(row.Auxiliary);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 75 "C:\Anusha\MyTIMEAPP (3)\MyTIMEAPP\MyTIMEAPP\Views\RM_SCREEN\Reconcile.cshtml"
                   Write(row.Comment);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 76 "C:\Anusha\MyTIMEAPP (3)\MyTIMEAPP\MyTIMEAPP\Views\RM_SCREEN\Reconcile.cshtml"
                   Write(row.Status);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td> \r\n            </tr>\r\n");
#nullable restore
#line 78 "C:\Anusha\MyTIMEAPP (3)\MyTIMEAPP\MyTIMEAPP\Views\RM_SCREEN\Reconcile.cshtml"
        }

#line default
#line hidden
#nullable disable
                WriteLiteral("               </tbody>\r\n            </table>\r\n        </div>\r\n    </div>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</html>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<MyTIME.Models.MyTime_TB>> Html { get; private set; }
    }
}
#pragma warning restore 1591