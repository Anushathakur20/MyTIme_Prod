#pragma checksum "C:\Users\Anusha Thakur\Downloads\Mytime_Prod-Prod (1)\Mytime_Prod-Prod\MyTIMEAPP\Views\RM_SCREEN\Reconcile.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7ff25c21adb7ae782f1435f8fc7ed84872e114fb"
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
#line 1 "C:\Users\Anusha Thakur\Downloads\Mytime_Prod-Prod (1)\Mytime_Prod-Prod\MyTIMEAPP\Views\_ViewImports.cshtml"
using MyTIMEAPP;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Anusha Thakur\Downloads\Mytime_Prod-Prod (1)\Mytime_Prod-Prod\MyTIMEAPP\Views\_ViewImports.cshtml"
using MyTIMEAPP.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7ff25c21adb7ae782f1435f8fc7ed84872e114fb", @"/Views/RM_SCREEN/Reconcile.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"687449f71bde884e3dfa18110ce466689c048a56", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_RM_SCREEN_Reconcile : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<MyTIME.Models.MyTime_TB>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/Home.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/aprovedrejectReconcile.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\n<!DOCTYPE html>\n<html>\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7ff25c21adb7ae782f1435f8fc7ed84872e114fb4658", async() => {
                WriteLiteral("\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "7ff25c21adb7ae782f1435f8fc7ed84872e114fb4918", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7ff25c21adb7ae782f1435f8fc7ed84872e114fb6094", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\n   \n");
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
            WriteLiteral("\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7ff25c21adb7ae782f1435f8fc7ed84872e114fb7898", async() => {
                WriteLiteral(@"
    <div class=""card"" id=""card_reconcile"">
        <div class=""float-left card-header text-uppercase text-white"" >
            <h5 id=""h_h5"" >Reconcile</h5>
        </div>
   </div>
    <div class=""card-body"">
        <input type=""text"" class=""form-control"" id=""currentTime"" placeholder=""Login Date & Time"" hidden>
        <div class=""card-body justify-content-md-center"">
            <div class=""d-grid gap-2 d-md-flex justify-content-md-center d-grid gap-2 d-md-block me-md-2 me-1"">

                <button class=""btn btn-success btn-responsive justify-content-md-center me-1"" type=""button"" id=""approveRC"" placeholder=""Approve"">
                    APPROVE
                </button>
                <button class=""btn btn-danger btn-responsive justify-content-md-center me-1"" type=""button"" id=""rejectRC"" placeholder=""Reject"">
                    REJECT
                </button>

            </div>
        </div>
        <div class=""table-responsive text-nowrap"">
            <table id=""reConcile"" class=""table table-bo");
                WriteLiteral(@"rdered table-hover"">
                <thead id=""thead_tbl_reconcile"">
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
                        <th>Break</th>
                        <th>Auxiliary</th>
                        <th>Comment</th>
                        <th>Status</th>
                    </tr>
                </thead>
            ");
                WriteLiteral("    <tbody>\n");
#nullable restore
#line 57 "C:\Users\Anusha Thakur\Downloads\Mytime_Prod-Prod (1)\Mytime_Prod-Prod\MyTIMEAPP\Views\RM_SCREEN\Reconcile.cshtml"
                     foreach (var row in ViewBag.Recon)
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <tr>\n                            <td>\n                                <input type=\"checkbox\" name=\"ids\" data-id=\"");
#nullable restore
#line 61 "C:\Users\Anusha Thakur\Downloads\Mytime_Prod-Prod (1)\Mytime_Prod-Prod\MyTIMEAPP\Views\RM_SCREEN\Reconcile.cshtml"
                                                                      Write(row.ID);

#line default
#line hidden
#nullable disable
                WriteLiteral("\" />\n                            </td>\n                            <td>");
#nullable restore
#line 63 "C:\Users\Anusha Thakur\Downloads\Mytime_Prod-Prod (1)\Mytime_Prod-Prod\MyTIMEAPP\Views\RM_SCREEN\Reconcile.cshtml"
                           Write(row.Match);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\n                            <td>");
#nullable restore
#line 64 "C:\Users\Anusha Thakur\Downloads\Mytime_Prod-Prod (1)\Mytime_Prod-Prod\MyTIMEAPP\Views\RM_SCREEN\Reconcile.cshtml"
                           Write(row.ID);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\n                            <td>");
#nullable restore
#line 65 "C:\Users\Anusha Thakur\Downloads\Mytime_Prod-Prod (1)\Mytime_Prod-Prod\MyTIMEAPP\Views\RM_SCREEN\Reconcile.cshtml"
                           Write(row.DasID);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\n                            <td>");
#nullable restore
#line 66 "C:\Users\Anusha Thakur\Downloads\Mytime_Prod-Prod (1)\Mytime_Prod-Prod\MyTIMEAPP\Views\RM_SCREEN\Reconcile.cshtml"
                           Write(row.Employee_Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\n                            <td>");
#nullable restore
#line 67 "C:\Users\Anusha Thakur\Downloads\Mytime_Prod-Prod (1)\Mytime_Prod-Prod\MyTIMEAPP\Views\RM_SCREEN\Reconcile.cshtml"
                           Write(row.Report_Manager_Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\n                            <td>");
#nullable restore
#line 68 "C:\Users\Anusha Thakur\Downloads\Mytime_Prod-Prod (1)\Mytime_Prod-Prod\MyTIMEAPP\Views\RM_SCREEN\Reconcile.cshtml"
                           Write(String.Format("{0:dd/MM/yyyy}",row.Date));

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\n                            <td>");
#nullable restore
#line 69 "C:\Users\Anusha Thakur\Downloads\Mytime_Prod-Prod (1)\Mytime_Prod-Prod\MyTIMEAPP\Views\RM_SCREEN\Reconcile.cshtml"
                           Write(String.Format("{0:dd/MM/yyyy HH:mm:ss}", row.Login));

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\n                            <td>");
#nullable restore
#line 70 "C:\Users\Anusha Thakur\Downloads\Mytime_Prod-Prod (1)\Mytime_Prod-Prod\MyTIMEAPP\Views\RM_SCREEN\Reconcile.cshtml"
                           Write(String.Format("{0:dd/MM/yyyy HH:mm:ss}", row.Logout));

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\n                            <td>");
#nullable restore
#line 71 "C:\Users\Anusha Thakur\Downloads\Mytime_Prod-Prod (1)\Mytime_Prod-Prod\MyTIMEAPP\Views\RM_SCREEN\Reconcile.cshtml"
                           Write(row.Total_Time);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\n                            <td>");
#nullable restore
#line 72 "C:\Users\Anusha Thakur\Downloads\Mytime_Prod-Prod (1)\Mytime_Prod-Prod\MyTIMEAPP\Views\RM_SCREEN\Reconcile.cshtml"
                           Write(row.Over_Time);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\n                            <td>");
#nullable restore
#line 73 "C:\Users\Anusha Thakur\Downloads\Mytime_Prod-Prod (1)\Mytime_Prod-Prod\MyTIMEAPP\Views\RM_SCREEN\Reconcile.cshtml"
                           Write(row.Works);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\n                            <td>");
#nullable restore
#line 74 "C:\Users\Anusha Thakur\Downloads\Mytime_Prod-Prod (1)\Mytime_Prod-Prod\MyTIMEAPP\Views\RM_SCREEN\Reconcile.cshtml"
                           Write(row.Meeting);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\n                            <td>");
#nullable restore
#line 75 "C:\Users\Anusha Thakur\Downloads\Mytime_Prod-Prod (1)\Mytime_Prod-Prod\MyTIMEAPP\Views\RM_SCREEN\Reconcile.cshtml"
                           Write(row.Training);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\n                            <td>");
#nullable restore
#line 76 "C:\Users\Anusha Thakur\Downloads\Mytime_Prod-Prod (1)\Mytime_Prod-Prod\MyTIMEAPP\Views\RM_SCREEN\Reconcile.cshtml"
                           Write(row.Breaks);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\n                            <td>");
#nullable restore
#line 77 "C:\Users\Anusha Thakur\Downloads\Mytime_Prod-Prod (1)\Mytime_Prod-Prod\MyTIMEAPP\Views\RM_SCREEN\Reconcile.cshtml"
                           Write(row.Auxiliary);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\n                            <td>");
#nullable restore
#line 78 "C:\Users\Anusha Thakur\Downloads\Mytime_Prod-Prod (1)\Mytime_Prod-Prod\MyTIMEAPP\Views\RM_SCREEN\Reconcile.cshtml"
                           Write(row.Comment);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\n                            <td>");
#nullable restore
#line 79 "C:\Users\Anusha Thakur\Downloads\Mytime_Prod-Prod (1)\Mytime_Prod-Prod\MyTIMEAPP\Views\RM_SCREEN\Reconcile.cshtml"
                           Write(row.Status);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\n                        </tr>\n");
#nullable restore
#line 81 "C:\Users\Anusha Thakur\Downloads\Mytime_Prod-Prod (1)\Mytime_Prod-Prod\MyTIMEAPP\Views\RM_SCREEN\Reconcile.cshtml"
                    }

#line default
#line hidden
#nullable disable
                WriteLiteral("                </tbody>\n            </table>\n        </div>\n    </div>\n");
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
            WriteLiteral("\n</html>\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<MyTIME.Models.MyTime_TB>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591