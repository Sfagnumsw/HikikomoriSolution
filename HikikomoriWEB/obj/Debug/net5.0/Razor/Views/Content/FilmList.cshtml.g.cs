#pragma checksum "C:\Users\Sfagnum\Documents\обучение\Программирование\C#\ASP.NET Core\eaxDeskTop\HikomoriASP\HikikomoriWEB\Views\Content\FilmList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0db87a4206fe34faec5e9b80c0683b139ec265cb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Content_FilmList), @"mvc.1.0.view", @"/Views/Content/FilmList.cshtml")]
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
using HikikomoriWEB.Domain.Entity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0db87a4206fe34faec5e9b80c0683b139ec265cb", @"/Views/Content/FilmList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"004d67ba6ba6b55eff395527a75197491a523683", @"/Views/_ViewImports.cshtml")]
    public class Views_Content_FilmList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<html>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0db87a4206fe34faec5e9b80c0683b139ec265cb4269", async() => {
                WriteLiteral("\r\n    <meta name=\"viewport\" content=\"width=device-width\" />\r\n    <title>Books</title>\r\n");
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0db87a4206fe34faec5e9b80c0683b139ec265cb5328", async() => {
                WriteLiteral(@"
    <input type=""button"" class=""delete-button"">
    <table class=""table-list-rate"">
        <caption>Посмотрел</caption>
        <thead>
            <tr><th>Id</th><th>Название</th><th>Жанр</th><th>Студия издания</th><th>Год выпуска</th><th>Оценка</th></tr>
        </thead>
        <tbody>
");
#nullable restore
#line 14 "C:\Users\Sfagnum\Documents\обучение\Программирование\C#\ASP.NET Core\eaxDeskTop\HikomoriASP\HikikomoriWEB\Views\Content\FilmList.cshtml"
             if (ViewBag.Rated != null)
            {
                foreach (var i in (List<RateContent>)ViewBag.Rated)
                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <tr>\r\n                        <td>");
#nullable restore
#line 19 "C:\Users\Sfagnum\Documents\обучение\Программирование\C#\ASP.NET Core\eaxDeskTop\HikomoriASP\HikikomoriWEB\Views\Content\FilmList.cshtml"
                       Write(i.Id);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 20 "C:\Users\Sfagnum\Documents\обучение\Программирование\C#\ASP.NET Core\eaxDeskTop\HikomoriASP\HikikomoriWEB\Views\Content\FilmList.cshtml"
                       Write(i.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 21 "C:\Users\Sfagnum\Documents\обучение\Программирование\C#\ASP.NET Core\eaxDeskTop\HikomoriASP\HikikomoriWEB\Views\Content\FilmList.cshtml"
                       Write(i.Genre);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 22 "C:\Users\Sfagnum\Documents\обучение\Программирование\C#\ASP.NET Core\eaxDeskTop\HikomoriASP\HikikomoriWEB\Views\Content\FilmList.cshtml"
                       Write(i.Autor);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 23 "C:\Users\Sfagnum\Documents\обучение\Программирование\C#\ASP.NET Core\eaxDeskTop\HikomoriASP\HikikomoriWEB\Views\Content\FilmList.cshtml"
                       Write(i.CreationYear);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 25 "C:\Users\Sfagnum\Documents\обучение\Программирование\C#\ASP.NET Core\eaxDeskTop\HikomoriASP\HikikomoriWEB\Views\Content\FilmList.cshtml"
                       Write(i.Rating);

#line default
#line hidden
#nullable disable
                WriteLiteral(" ");
#nullable restore
#line 25 "C:\Users\Sfagnum\Documents\обучение\Программирование\C#\ASP.NET Core\eaxDeskTop\HikomoriASP\HikikomoriWEB\Views\Content\FilmList.cshtml"
                                       if (i.Replay == true)
                            {

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "0db87a4206fe34faec5e9b80c0683b139ec265cb8625", async() => {
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
#line 26 "C:\Users\Sfagnum\Documents\обучение\Программирование\C#\ASP.NET Core\eaxDeskTop\HikomoriASP\HikikomoriWEB\Views\Content\FilmList.cshtml"
                                                                     }

#line default
#line hidden
#nullable disable
                WriteLiteral("                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 29 "C:\Users\Sfagnum\Documents\обучение\Программирование\C#\ASP.NET Core\eaxDeskTop\HikomoriASP\HikikomoriWEB\Views\Content\FilmList.cshtml"
                }
            }
            else
            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                <tr>Пока пусто</tr>\r\n");
#nullable restore
#line 34 "C:\Users\Sfagnum\Documents\обучение\Программирование\C#\ASP.NET Core\eaxDeskTop\HikomoriASP\HikikomoriWEB\Views\Content\FilmList.cshtml"
            }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"        </tbody>
    </table>

    <br>

    <table class=""table-list-remember"">
        <caption>Посмотрю позже</caption>
        <thead>
            <tr><th>Id</th><th>Название</th><th>Жанр</th><th>Студия издания</th><th>Год создания</th></tr>
        </thead>
        <tbody>
");
#nullable restore
#line 46 "C:\Users\Sfagnum\Documents\обучение\Программирование\C#\ASP.NET Core\eaxDeskTop\HikomoriASP\HikikomoriWEB\Views\Content\FilmList.cshtml"
             if (ViewBag.Remembered != null)
            {
                foreach (var i in (List<RememberContent>)ViewBag.Remembered)
                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <tr><td>");
#nullable restore
#line 50 "C:\Users\Sfagnum\Documents\обучение\Программирование\C#\ASP.NET Core\eaxDeskTop\HikomoriASP\HikikomoriWEB\Views\Content\FilmList.cshtml"
                       Write(i.Id);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td><td>");
#nullable restore
#line 50 "C:\Users\Sfagnum\Documents\обучение\Программирование\C#\ASP.NET Core\eaxDeskTop\HikomoriASP\HikikomoriWEB\Views\Content\FilmList.cshtml"
                                     Write(i.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td><td>");
#nullable restore
#line 50 "C:\Users\Sfagnum\Documents\обучение\Программирование\C#\ASP.NET Core\eaxDeskTop\HikomoriASP\HikikomoriWEB\Views\Content\FilmList.cshtml"
                                                     Write(i.Genre);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td><td>");
#nullable restore
#line 50 "C:\Users\Sfagnum\Documents\обучение\Программирование\C#\ASP.NET Core\eaxDeskTop\HikomoriASP\HikikomoriWEB\Views\Content\FilmList.cshtml"
                                                                      Write(i.Autor);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td><td>");
#nullable restore
#line 50 "C:\Users\Sfagnum\Documents\обучение\Программирование\C#\ASP.NET Core\eaxDeskTop\HikomoriASP\HikikomoriWEB\Views\Content\FilmList.cshtml"
                                                                                       Write(i.CreationYear);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td></tr>\r\n");
#nullable restore
#line 51 "C:\Users\Sfagnum\Documents\обучение\Программирование\C#\ASP.NET Core\eaxDeskTop\HikomoriASP\HikikomoriWEB\Views\Content\FilmList.cshtml"
                }
            }
            else
            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                <tr>Пока пусто</tr>\r\n");
#nullable restore
#line 56 "C:\Users\Sfagnum\Documents\обучение\Программирование\C#\ASP.NET Core\eaxDeskTop\HikomoriASP\HikikomoriWEB\Views\Content\FilmList.cshtml"
            }

#line default
#line hidden
#nullable disable
                WriteLiteral("        </tbody>\r\n    </table>\r\n");
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
            WriteLiteral("\r\n</html>");
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
