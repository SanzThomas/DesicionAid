#pragma checksum "C:\Users\tsanz\Documents\Mes documents\Cours\Master 2\Aide à la decision\DesicionAid\DecisionAid\DecisionAid\Views\Main\Result.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "81e5a3174803973464d62423bade88cdc4e9eac8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(DecisionAid.Pages.Views_Main_Result), @"mvc.1.0.view", @"/Views/Main/Result.cshtml")]
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
#line 1 "C:\Users\tsanz\Documents\Mes documents\Cours\Master 2\Aide à la decision\DesicionAid\DecisionAid\DecisionAid\Views\Main\_ViewImports.cshtml"
using DecisionAid;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\tsanz\Documents\Mes documents\Cours\Master 2\Aide à la decision\DesicionAid\DecisionAid\DecisionAid\Views\Main\Result.cshtml"
using DecisionAid.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"81e5a3174803973464d62423bade88cdc4e9eac8", @"/Views/Main/Result.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"882de6138ae1f5c798a96c5e13b714cbf84f90e7", @"/Views/Main/_ViewImports.cshtml")]
    public class Views_Main_Result : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<MatchesModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 5 "C:\Users\tsanz\Documents\Mes documents\Cours\Master 2\Aide à la decision\DesicionAid\DecisionAid\DecisionAid\Views\Main\Result.cshtml"
  
    ViewData["Title"] = "Résultat";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"row\">\r\n    <div class=\"col-12 table-responsive mb-5\">\r\n        <table class=\"table table-bordered\">\r\n            <caption>Préférences des étudiants</caption>\r\n            <tr>\r\n                <th>Etudiants</th>\r\n\r\n");
#nullable restore
#line 16 "C:\Users\tsanz\Documents\Mes documents\Cours\Master 2\Aide à la decision\DesicionAid\DecisionAid\DecisionAid\Views\Main\Result.cshtml"
                 for (var i = 1; i <= Model.Candidacies.Establishments.Count; i++)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <th nowrap>Choix ");
#nullable restore
#line 18 "C:\Users\tsanz\Documents\Mes documents\Cours\Master 2\Aide à la decision\DesicionAid\DecisionAid\DecisionAid\Views\Main\Result.cshtml"
                                Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n");
#nullable restore
#line 19 "C:\Users\tsanz\Documents\Mes documents\Cours\Master 2\Aide à la decision\DesicionAid\DecisionAid\DecisionAid\Views\Main\Result.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </tr>\r\n\r\n");
#nullable restore
#line 23 "C:\Users\tsanz\Documents\Mes documents\Cours\Master 2\Aide à la decision\DesicionAid\DecisionAid\DecisionAid\Views\Main\Result.cshtml"
             foreach (var student in Model.Candidacies.Students)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td nowrap>");
#nullable restore
#line 26 "C:\Users\tsanz\Documents\Mes documents\Cours\Master 2\Aide à la decision\DesicionAid\DecisionAid\DecisionAid\Views\Main\Result.cshtml"
                          Write(student.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n");
#nullable restore
#line 28 "C:\Users\tsanz\Documents\Mes documents\Cours\Master 2\Aide à la decision\DesicionAid\DecisionAid\DecisionAid\Views\Main\Result.cshtml"
                     foreach (var preferency in student.Preferencies)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <td nowrap>");
#nullable restore
#line 30 "C:\Users\tsanz\Documents\Mes documents\Cours\Master 2\Aide à la decision\DesicionAid\DecisionAid\DecisionAid\Views\Main\Result.cshtml"
                              Write(preferency.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 31 "C:\Users\tsanz\Documents\Mes documents\Cours\Master 2\Aide à la decision\DesicionAid\DecisionAid\DecisionAid\Views\Main\Result.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </tr>\r\n");
#nullable restore
#line 34 "C:\Users\tsanz\Documents\Mes documents\Cours\Master 2\Aide à la decision\DesicionAid\DecisionAid\DecisionAid\Views\Main\Result.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </table>\r\n    </div>\r\n\r\n    <div class=\"col-12 table-responsive mb-5\">\r\n        <table class=\"table table-bordered\">\r\n            <caption>Préférences des établissements</caption>\r\n            <tr>\r\n                <th>Etablissements</th>\r\n\r\n");
#nullable restore
#line 45 "C:\Users\tsanz\Documents\Mes documents\Cours\Master 2\Aide à la decision\DesicionAid\DecisionAid\DecisionAid\Views\Main\Result.cshtml"
                 for (var i = 1; i <= Model.Candidacies.Students.Count; i++)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <th nowrap>Choix ");
#nullable restore
#line 47 "C:\Users\tsanz\Documents\Mes documents\Cours\Master 2\Aide à la decision\DesicionAid\DecisionAid\DecisionAid\Views\Main\Result.cshtml"
                                Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n");
#nullable restore
#line 48 "C:\Users\tsanz\Documents\Mes documents\Cours\Master 2\Aide à la decision\DesicionAid\DecisionAid\DecisionAid\Views\Main\Result.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </tr>\r\n\r\n");
#nullable restore
#line 52 "C:\Users\tsanz\Documents\Mes documents\Cours\Master 2\Aide à la decision\DesicionAid\DecisionAid\DecisionAid\Views\Main\Result.cshtml"
             foreach (var establishment in Model.Candidacies.Establishments)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td nowrap>");
#nullable restore
#line 55 "C:\Users\tsanz\Documents\Mes documents\Cours\Master 2\Aide à la decision\DesicionAid\DecisionAid\DecisionAid\Views\Main\Result.cshtml"
                          Write(establishment.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n");
#nullable restore
#line 57 "C:\Users\tsanz\Documents\Mes documents\Cours\Master 2\Aide à la decision\DesicionAid\DecisionAid\DecisionAid\Views\Main\Result.cshtml"
                     foreach (var preferency in establishment.Preferencies)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <td nowrap>");
#nullable restore
#line 59 "C:\Users\tsanz\Documents\Mes documents\Cours\Master 2\Aide à la decision\DesicionAid\DecisionAid\DecisionAid\Views\Main\Result.cshtml"
                              Write(preferency.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 60 "C:\Users\tsanz\Documents\Mes documents\Cours\Master 2\Aide à la decision\DesicionAid\DecisionAid\DecisionAid\Views\Main\Result.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </tr>\r\n");
#nullable restore
#line 63 "C:\Users\tsanz\Documents\Mes documents\Cours\Master 2\Aide à la decision\DesicionAid\DecisionAid\DecisionAid\Views\Main\Result.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
        </table>
    </div>
</div>

<div class=""row"">
    <div class=""col-4 table-responsive mb-5"">
        <table class=""table table-bordered"">
            <caption>Affectations</caption>
            <tr>
                <th>Etablissements</th>
                <th>Etudiants</th>
            </tr>

");
#nullable restore
#line 78 "C:\Users\tsanz\Documents\Mes documents\Cours\Master 2\Aide à la decision\DesicionAid\DecisionAid\DecisionAid\Views\Main\Result.cshtml"
             foreach (var pair in Model.Matches)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td nowrap>");
#nullable restore
#line 81 "C:\Users\tsanz\Documents\Mes documents\Cours\Master 2\Aide à la decision\DesicionAid\DecisionAid\DecisionAid\Views\Main\Result.cshtml"
                          Write(pair.Key.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td nowrap>");
#nullable restore
#line 82 "C:\Users\tsanz\Documents\Mes documents\Cours\Master 2\Aide à la decision\DesicionAid\DecisionAid\DecisionAid\Views\Main\Result.cshtml"
                          Write(string.Join(", ", pair.Value.Select(v => v.Name)));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                </tr>\r\n");
#nullable restore
#line 84 "C:\Users\tsanz\Documents\Mes documents\Cours\Master 2\Aide à la decision\DesicionAid\DecisionAid\DecisionAid\Views\Main\Result.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
        </table>
    </div>
    <div class=""col-4 table-responsive mb-5"">
        <table class=""table table-bordered"">
            <caption>Satisfaction des étudiants</caption>
            <tr>
                <th>Etudiants</th>
                <th>Satisfaction</th>
            </tr>

");
#nullable restore
#line 96 "C:\Users\tsanz\Documents\Mes documents\Cours\Master 2\Aide à la decision\DesicionAid\DecisionAid\DecisionAid\Views\Main\Result.cshtml"
             foreach (var pair in Model.StudentSatisfactions)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td nowrap>");
#nullable restore
#line 99 "C:\Users\tsanz\Documents\Mes documents\Cours\Master 2\Aide à la decision\DesicionAid\DecisionAid\DecisionAid\Views\Main\Result.cshtml"
                          Write(pair.Key);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td nowrap>");
#nullable restore
#line 100 "C:\Users\tsanz\Documents\Mes documents\Cours\Master 2\Aide à la decision\DesicionAid\DecisionAid\DecisionAid\Views\Main\Result.cshtml"
                          Write(pair.Value);

#line default
#line hidden
#nullable disable
            WriteLiteral(" %</td>\r\n                </tr>\r\n");
#nullable restore
#line 102 "C:\Users\tsanz\Documents\Mes documents\Cours\Master 2\Aide à la decision\DesicionAid\DecisionAid\DecisionAid\Views\Main\Result.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
        </table>
    </div>
    <div class=""col-4 table-responsive mb-5"">
        <table class=""table table-bordered"">
            <caption>Satisfaction des établissements</caption>
            <tr>
                <th>Etablissements</th>
                <th>Satisfaction</th>
            </tr>

");
#nullable restore
#line 114 "C:\Users\tsanz\Documents\Mes documents\Cours\Master 2\Aide à la decision\DesicionAid\DecisionAid\DecisionAid\Views\Main\Result.cshtml"
             foreach (var pair in Model.EstablishmentSatisfactions)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td nowrap>");
#nullable restore
#line 117 "C:\Users\tsanz\Documents\Mes documents\Cours\Master 2\Aide à la decision\DesicionAid\DecisionAid\DecisionAid\Views\Main\Result.cshtml"
                          Write(pair.Key);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td nowrap>");
#nullable restore
#line 118 "C:\Users\tsanz\Documents\Mes documents\Cours\Master 2\Aide à la decision\DesicionAid\DecisionAid\DecisionAid\Views\Main\Result.cshtml"
                          Write(pair.Value);

#line default
#line hidden
#nullable disable
            WriteLiteral(" %</td>\r\n                </tr>\r\n");
#nullable restore
#line 120 "C:\Users\tsanz\Documents\Mes documents\Cours\Master 2\Aide à la decision\DesicionAid\DecisionAid\DecisionAid\Views\Main\Result.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </table>\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MatchesModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
