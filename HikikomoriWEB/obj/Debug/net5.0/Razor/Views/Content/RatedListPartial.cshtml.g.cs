#pragma checksum "C:\Users\Sfagnum\Documents\обучение\Программирование\C#\ASP.NET Core\eaxDeskTop\HikomoriASP\HikikomoriWEB\Views\Content\RatedListPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fb5143dfb427b6374b58b02c3c2673e8b378b5f9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Content_RatedListPartial), @"mvc.1.0.view", @"/Views/Content/RatedListPartial.cshtml")]
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
#line 2 "C:\Users\Sfagnum\Documents\обучение\Программирование\C#\ASP.NET Core\eaxDeskTop\HikomoriASP\HikikomoriWEB\Views\_ViewImports.cshtml"
using HikikomoriWEB;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Sfagnum\Documents\обучение\Программирование\C#\ASP.NET Core\eaxDeskTop\HikomoriASP\HikikomoriWEB\Views\_ViewImports.cshtml"
using HikikomoriWEB.Domain.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fb5143dfb427b6374b58b02c3c2673e8b378b5f9", @"/Views/Content/RatedListPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8e672e69147921f9cd1fc4140a558d2e64010285", @"/Views/_ViewImports.cshtml")]
    public class Views_Content_RatedListPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<RateContentViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/fav.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("ico"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<table class=\"table-list-rate\">\r\n    <caption>Оценил</caption>\r\n    <thead>\r\n        <tr><th>Id</th><th>Название</th><th>Жанр</th><th>Автор</th><th>Год выпуска</th><th>Оценка</th></tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 9 "C:\Users\Sfagnum\Documents\обучение\Программирование\C#\ASP.NET Core\eaxDeskTop\HikomoriASP\HikikomoriWEB\Views\Content\RatedListPartial.cshtml"
         foreach (var i in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td class=\"item-id\">");
#nullable restore
#line 12 "C:\Users\Sfagnum\Documents\обучение\Программирование\C#\ASP.NET Core\eaxDeskTop\HikomoriASP\HikikomoriWEB\Views\Content\RatedListPartial.cshtml"
                               Write(i.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 13 "C:\Users\Sfagnum\Documents\обучение\Программирование\C#\ASP.NET Core\eaxDeskTop\HikomoriASP\HikikomoriWEB\Views\Content\RatedListPartial.cshtml"
               Write(i.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 14 "C:\Users\Sfagnum\Documents\обучение\Программирование\C#\ASP.NET Core\eaxDeskTop\HikomoriASP\HikikomoriWEB\Views\Content\RatedListPartial.cshtml"
               Write(i.Genre);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 15 "C:\Users\Sfagnum\Documents\обучение\Программирование\C#\ASP.NET Core\eaxDeskTop\HikomoriASP\HikikomoriWEB\Views\Content\RatedListPartial.cshtml"
               Write(i.Autor);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 16 "C:\Users\Sfagnum\Documents\обучение\Программирование\C#\ASP.NET Core\eaxDeskTop\HikomoriASP\HikikomoriWEB\Views\Content\RatedListPartial.cshtml"
               Write(i.CreationYear);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>\r\n                    ");
#nullable restore
#line 18 "C:\Users\Sfagnum\Documents\обучение\Программирование\C#\ASP.NET Core\eaxDeskTop\HikomoriASP\HikikomoriWEB\Views\Content\RatedListPartial.cshtml"
               Write(i.Rating);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 18 "C:\Users\Sfagnum\Documents\обучение\Программирование\C#\ASP.NET Core\eaxDeskTop\HikomoriASP\HikikomoriWEB\Views\Content\RatedListPartial.cshtml"
                               if (i.Replay == true)
                    {

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "fb5143dfb427b6374b58b02c3c2673e8b378b5f96859", async() => {
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
#nullable restore
#line 19 "C:\Users\Sfagnum\Documents\обучение\Программирование\C#\ASP.NET Core\eaxDeskTop\HikomoriASP\HikikomoriWEB\Views\Content\RatedListPartial.cshtml"
                                                             }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </td>\r\n            </tr>\r\n");
#nullable restore
#line 22 "C:\Users\Sfagnum\Documents\обучение\Программирование\C#\ASP.NET Core\eaxDeskTop\HikomoriASP\HikikomoriWEB\Views\Content\RatedListPartial.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<RateContentViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
