#pragma checksum "C:\Users\tsanz\Documents\Mes documents\Cours\Master 2\Aide à la decision\DesicionAid\DecisionAid\DecisionAid\Views\Main\Result.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c413854bb17c457655fa4371afece2018c925a74"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Main_Result), @"mvc.1.0.view", @"/Views/Main/Result.cshtml")]
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
#line 1 "C:\Users\tsanz\Documents\Mes documents\Cours\Master 2\Aide à la decision\DesicionAid\DecisionAid\DecisionAid\Views\Main\Result.cshtml"
using DecisionAid.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c413854bb17c457655fa4371afece2018c925a74", @"/Views/Main/Result.cshtml")]
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
            WriteLiteral("\r\n<div class=\"row\">\r\n    <div class=\"col-6\">\r\n        <table>\r\n            <tr>\r\n                <th>Etudiants</th>\r\n\r\n");
#nullable restore
#line 15 "C:\Users\tsanz\Documents\Mes documents\Cours\Master 2\Aide à la decision\DesicionAid\DecisionAid\DecisionAid\Views\Main\Result.cshtml"
                 for (var i = 1; i <= Model.Candidacies.Establishments.Count; i++)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <th>Ordre : ");
#nullable restore
#line 17 "C:\Users\tsanz\Documents\Mes documents\Cours\Master 2\Aide à la decision\DesicionAid\DecisionAid\DecisionAid\Views\Main\Result.cshtml"
                           Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n");
#nullable restore
#line 18 "C:\Users\tsanz\Documents\Mes documents\Cours\Master 2\Aide à la decision\DesicionAid\DecisionAid\DecisionAid\Views\Main\Result.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </tr>\r\n\r\n");
#nullable restore
#line 22 "C:\Users\tsanz\Documents\Mes documents\Cours\Master 2\Aide à la decision\DesicionAid\DecisionAid\DecisionAid\Views\Main\Result.cshtml"
             foreach (var student in Model.Candidacies.Students)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>");
#nullable restore
#line 25 "C:\Users\tsanz\Documents\Mes documents\Cours\Master 2\Aide à la decision\DesicionAid\DecisionAid\DecisionAid\Views\Main\Result.cshtml"
                   Write(student.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n");
#nullable restore
#line 27 "C:\Users\tsanz\Documents\Mes documents\Cours\Master 2\Aide à la decision\DesicionAid\DecisionAid\DecisionAid\Views\Main\Result.cshtml"
                     foreach (var preferency in student.Preferencies)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <td>");
#nullable restore
#line 29 "C:\Users\tsanz\Documents\Mes documents\Cours\Master 2\Aide à la decision\DesicionAid\DecisionAid\DecisionAid\Views\Main\Result.cshtml"
                       Write(preferency.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 30 "C:\Users\tsanz\Documents\Mes documents\Cours\Master 2\Aide à la decision\DesicionAid\DecisionAid\DecisionAid\Views\Main\Result.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </tr>\r\n");
#nullable restore
#line 33 "C:\Users\tsanz\Documents\Mes documents\Cours\Master 2\Aide à la decision\DesicionAid\DecisionAid\DecisionAid\Views\Main\Result.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </table>\r\n    </div>\r\n\r\n    <div class=\"col-6\">\r\n        <table>\r\n            <tr>\r\n                <th>Etablissements</th>\r\n\r\n");
#nullable restore
#line 43 "C:\Users\tsanz\Documents\Mes documents\Cours\Master 2\Aide à la decision\DesicionAid\DecisionAid\DecisionAid\Views\Main\Result.cshtml"
                 for (var i = 1; i <= Model.Candidacies.Students.Count; i++)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <th>Ordre : ");
#nullable restore
#line 45 "C:\Users\tsanz\Documents\Mes documents\Cours\Master 2\Aide à la decision\DesicionAid\DecisionAid\DecisionAid\Views\Main\Result.cshtml"
                           Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n");
#nullable restore
#line 46 "C:\Users\tsanz\Documents\Mes documents\Cours\Master 2\Aide à la decision\DesicionAid\DecisionAid\DecisionAid\Views\Main\Result.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </tr>\r\n\r\n");
#nullable restore
#line 50 "C:\Users\tsanz\Documents\Mes documents\Cours\Master 2\Aide à la decision\DesicionAid\DecisionAid\DecisionAid\Views\Main\Result.cshtml"
             foreach (var establishment in Model.Candidacies.Establishments)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>");
#nullable restore
#line 53 "C:\Users\tsanz\Documents\Mes documents\Cours\Master 2\Aide à la decision\DesicionAid\DecisionAid\DecisionAid\Views\Main\Result.cshtml"
                   Write(establishment.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n");
#nullable restore
#line 55 "C:\Users\tsanz\Documents\Mes documents\Cours\Master 2\Aide à la decision\DesicionAid\DecisionAid\DecisionAid\Views\Main\Result.cshtml"
                     foreach (var preferency in establishment.Preferencies)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <td>");
#nullable restore
#line 57 "C:\Users\tsanz\Documents\Mes documents\Cours\Master 2\Aide à la decision\DesicionAid\DecisionAid\DecisionAid\Views\Main\Result.cshtml"
                       Write(preferency.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 58 "C:\Users\tsanz\Documents\Mes documents\Cours\Master 2\Aide à la decision\DesicionAid\DecisionAid\DecisionAid\Views\Main\Result.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </tr>\r\n");
#nullable restore
#line 61 "C:\Users\tsanz\Documents\Mes documents\Cours\Master 2\Aide à la decision\DesicionAid\DecisionAid\DecisionAid\Views\Main\Result.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </table>\r\n    </div>\r\n</div>\r\n\r\n<table>\r\n    <tr>\r\n        <th>Etudiants</th>\r\n        <th>Etablissements</th>\r\n    </tr>\r\n\r\n");
#nullable restore
#line 73 "C:\Users\tsanz\Documents\Mes documents\Cours\Master 2\Aide à la decision\DesicionAid\DecisionAid\DecisionAid\Views\Main\Result.cshtml"
     foreach (var pair in Model.Matches)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>");
#nullable restore
#line 76 "C:\Users\tsanz\Documents\Mes documents\Cours\Master 2\Aide à la decision\DesicionAid\DecisionAid\DecisionAid\Views\Main\Result.cshtml"
           Write(pair.Key.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 77 "C:\Users\tsanz\Documents\Mes documents\Cours\Master 2\Aide à la decision\DesicionAid\DecisionAid\DecisionAid\Views\Main\Result.cshtml"
           Write(pair.Value.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n        </tr>\r\n");
#nullable restore
#line 80 "C:\Users\tsanz\Documents\Mes documents\Cours\Master 2\Aide à la decision\DesicionAid\DecisionAid\DecisionAid\Views\Main\Result.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</table>");
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