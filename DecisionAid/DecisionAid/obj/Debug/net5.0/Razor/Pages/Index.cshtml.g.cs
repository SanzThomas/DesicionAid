#pragma checksum "C:\Users\tsanz\Documents\Mes documents\Cours\Master 2\Aide à la decision\DesicionAid\DecisionAid\DecisionAid\Pages\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "89e9d9f20d534f3966dca166706439f0b861b493"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(DecisionAid.Pages.Pages_Index), @"mvc.1.0.razor-page", @"/Pages/Index.cshtml")]
namespace DecisionAid.Pages
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
#line 1 "C:\Users\tsanz\Documents\Mes documents\Cours\Master 2\Aide à la decision\DesicionAid\DecisionAid\DecisionAid\Pages\_ViewImports.cshtml"
using DecisionAid;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"89e9d9f20d534f3966dca166706439f0b861b493", @"/Pages/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0ba033656767631b94f997024954c7bdff46a7dd", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Index : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Main", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "GenerateCandidacies", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("choose-count"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\tsanz\Documents\Mes documents\Cours\Master 2\Aide à la decision\DesicionAid\DecisionAid\DecisionAid\Pages\Index.cshtml"
  
    ViewData["Title"] = "Accueil";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"text-center\">\r\n    <h1 class=\"display-4\">Bienvenue sur notre projet d\'analyse du mariage stable</h1>\r\n\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "89e9d9f20d534f3966dca166706439f0b861b4934762", async() => {
                WriteLiteral(@"
        <div class=""form-group"">
            <label for=""count"">Choisissez combien d'étudiants et d'établissements vous souhaitez générer</label>
            <input type=""number"" class=""form-control col-1 mx-auto"" id=""count"" name=""count"" value=""5"" />
        </div>
        <button class=""btn btn-outline-primary"" type=""submit"">Valider</button>
    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    <div id=\"preferencies-content\"></div>\r\n</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"

<script type=""text/javascript"">

    var buildPreferencies = function () {

        var allStudents = $("".students-items.sortable"");
        var allEstablishments = $("".establishments-items.sortable"");

        var data = {
            students: [allStudents.length],
            establishments: [allEstablishments.length]
        };

        allStudents.each(function (i, item) {

            var id = $(item).prev(""h5"").data(""id"");
            var name = $(item).prev(""h5"").html();

            var preferencyOrders = $(item).children();
            var preferencies = [preferencyOrders.length];

            preferencyOrders.each(function (j, preferency) {

                var preferencyId = $(preferency).data(""id"");
                var preferencyName = $(preferency).html();

                preferencies[j] = { id: preferencyId, name: preferencyName };
            });

            data.students[i] = { id, name, preferencies };
        });

        allEstablishments.each(function ");
                WriteLiteral(@"(i, item) {

            var id = $(item).prev(""h5"").data(""id"");
            var name = $(item).prev(""h5"").html();

            var preferencyOrders = $(item).children();
            var preferencies = [preferencyOrders.length];

            preferencyOrders.each(function (j, preferency) {

                var preferencyId = $(preferency).data(""id"");
                var preferencyName = $(preferency).html();

                preferencies[j] = { id: preferencyId, name: preferencyName };
            });

            data.establishments[i] = { id, name, preferencies };
        });

        $.ajax({
            url: """);
#nullable restore
#line 74 "C:\Users\tsanz\Documents\Mes documents\Cours\Master 2\Aide à la decision\DesicionAid\DecisionAid\DecisionAid\Pages\Index.cshtml"
             Write(Url.Action("InitModel", "Main"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\",\r\n            method: \"POST\",\r\n            async: false\r\n        });\r\n\r\n        for (var i = 0; i < data.students.length; i++) {\r\n\r\n            console.log(\"for\");\r\n\r\n            $.ajax({\r\n                url: \"");
#nullable restore
#line 84 "C:\Users\tsanz\Documents\Mes documents\Cours\Master 2\Aide à la decision\DesicionAid\DecisionAid\DecisionAid\Pages\Index.cshtml"
                 Write(Url.Action("BuildModel", "Main"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@""",
                method: ""POST"",
                data: {
                    student: data.students[i],
                    establishment: data.establishments[i]
                },
                async: false
            });
        } 
    }

    var generateResultsByStudents = function (e) {
        e.preventDefault();

        buildPreferencies();

        $(""#generate-solution"").submit();
    }

    var generateResultsByEstablishments = function (e) {
        e.preventDefault();

        buildPreferencies();

        $(""#generate-solution"").prop(""action"", $(""#generate-solution"").prop(""action"").replace(""GenerateSolutionByStudents"", ""GenerateSolutionByEstablishments""));
        $(""#generate-solution"").submit();
    }

    $(document).ready(function () {

        // Evénements
        $(document).on(""click"", ""#validate-preferencies-by-student"", generateResultsByStudents);
        $(document).on(""click"", ""#validate-preferencies-by-establishment"", generateResultsByEstablishmen");
                WriteLiteral("ts);\r\n    });\r\n\r\n</script>\r\n");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IndexModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<IndexModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<IndexModel>)PageContext?.ViewData;
        public IndexModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
