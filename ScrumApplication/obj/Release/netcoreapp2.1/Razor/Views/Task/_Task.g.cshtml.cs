#pragma checksum "C:\Users\VIET ANH\Desktop\ScrumApplication\ScrumApplication\Views\Task\_Task.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b1f6f589f2bcc014d3b681ccd2df570c8ce8ab41"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Task__Task), @"mvc.1.0.view", @"/Views/Task/_Task.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Task/_Task.cshtml", typeof(AspNetCore.Views_Task__Task))]
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
#line 1 "C:\Users\VIET ANH\Desktop\ScrumApplication\ScrumApplication\Views\_ViewImports.cshtml"
using ScrumApplication;

#line default
#line hidden
#line 2 "C:\Users\VIET ANH\Desktop\ScrumApplication\ScrumApplication\Views\_ViewImports.cshtml"
using ScrumApplication.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b1f6f589f2bcc014d3b681ccd2df570c8ce8ab41", @"/Views/Task/_Task.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ffcf6b17f4e1c3db34de29396a2c2d3237fc2a48", @"/Views/_ViewImports.cshtml")]
    public class Views_Task__Task : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ScrumApplicationData.Models.Tasks>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "StartTask", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-sm btn-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "RemoveTask", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(41, 76, true);
            WriteLiteral("<div class=\"card mb-2  bg-light\">\n    <div class=\"card-header\">\n        <img");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 117, "\"", 155, 1);
#line 4 "C:\Users\VIET ANH\Desktop\ScrumApplication\ScrumApplication\Views\Task\_Task.cshtml"
WriteAttributeValue("", 123, Model.ApplicationUser?.ImageUrl, 123, 32, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(156, 80, true);
            WriteLiteral(" alt=\"User Image\" class=\"img-circle user-image\" />\n        <strong>\n            ");
            EndContext();
            BeginContext(237, 31, false);
#line 6 "C:\Users\VIET ANH\Desktop\ScrumApplication\ScrumApplication\Views\Task\_Task.cshtml"
       Write(Model.ApplicationUser.FirstName);

#line default
#line hidden
            EndContext();
            BeginContext(268, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(270, 30, false);
#line 6 "C:\Users\VIET ANH\Desktop\ScrumApplication\ScrumApplication\Views\Task\_Task.cshtml"
                                        Write(Model.ApplicationUser.LastName);

#line default
#line hidden
            EndContext();
            BeginContext(300, 104, true);
            WriteLiteral("\n        </strong>\n    </div>\n    <div class=\"card-body  \">\r\n        <p class=\"card-text\">\r\n            ");
            EndContext();
            BeginContext(405, 10, false);
#line 11 "C:\Users\VIET ANH\Desktop\ScrumApplication\ScrumApplication\Views\Task\_Task.cshtml"
       Write(Model.Name);

#line default
#line hidden
            EndContext();
            BeginContext(415, 81, true);
            WriteLiteral("\r\n        </p>\r\n        <p class=\"card-text\">\r\n            Ước lượng hoàn thành: ");
            EndContext();
            BeginContext(497, 9, false);
#line 14 "C:\Users\VIET ANH\Desktop\ScrumApplication\ScrumApplication\Views\Task\_Task.cshtml"
                             Write(Model.Day);

#line default
#line hidden
            EndContext();
            BeginContext(506, 115, true);
            WriteLiteral(" ngày\r\n        </p>\r\n        <footer class=\"blockquote-footer text-white\">\r\n            <cite title=\"Source Title\">");
            EndContext();
            BeginContext(622, 17, false);
#line 17 "C:\Users\VIET ANH\Desktop\ScrumApplication\ScrumApplication\Views\Task\_Task.cshtml"
                                  Write(Model.Description);

#line default
#line hidden
            EndContext();
            BeginContext(639, 90, true);
            WriteLiteral("</cite>\r\n        </footer>\r\n\r\n    </div>\n    <div class=\"card-footer text-right\">\n        ");
            EndContext();
            BeginContext(729, 142, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f8bde7a1da2d4a8bb39c25db9606c468", async() => {
                BeginContext(810, 57, true);
                WriteLiteral("\n            <i class=\"fas fa-play\"></i> Bắt đầu\n        ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 22 "C:\Users\VIET ANH\Desktop\ScrumApplication\ScrumApplication\Views\Task\_Task.cshtml"
                                    WriteLiteral(Model.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(871, 9, true);
            WriteLiteral("\n        ");
            EndContext();
            BeginContext(880, 142, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c75eb48f2e5243d29e7f30de83926aa0", async() => {
                BeginContext(962, 56, true);
                WriteLiteral("\n            <i class=\"fas fa-trash\"></i> Gỡ bỏ\n        ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 25 "C:\Users\VIET ANH\Desktop\ScrumApplication\ScrumApplication\Views\Task\_Task.cshtml"
                                     WriteLiteral(Model.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1022, 18, true);
            WriteLiteral("\n    </div>\n</div>");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ScrumApplicationData.Models.Tasks> Html { get; private set; }
    }
}
#pragma warning restore 1591
