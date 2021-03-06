#pragma checksum "C:\Users\vedat\source\repos\StudentPortal\StudentPortal.WebUI\Areas\Student\Views\Cart\GetChosenCourses.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "36b5451b58300e5fcee00d3a31cb0995101fae5d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Student_Views_Cart_GetChosenCourses), @"mvc.1.0.view", @"/Areas/Student/Views/Cart/GetChosenCourses.cshtml")]
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
#line 2 "C:\Users\vedat\source\repos\StudentPortal\StudentPortal.WebUI\Areas\Student\Views\_ViewImports.cshtml"
using StudentPortal.WebUI.Areas.Student.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\vedat\source\repos\StudentPortal\StudentPortal.WebUI\Areas\Student\Views\_ViewImports.cshtml"
using StudentPortal.WebUI.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\vedat\source\repos\StudentPortal\StudentPortal.WebUI\Areas\Student\Views\_ViewImports.cshtml"
using StudentPortal.Entites.Concrete;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"36b5451b58300e5fcee00d3a31cb0995101fae5d", @"/Areas/Student/Views/Cart/GetChosenCourses.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d21a3ce16926d09c07ec7b78cc7c8fa4c4e78926", @"/Areas/Student/Views/_ViewImports.cshtml")]
    public class Areas_Student_Views_Cart_GetChosenCourses : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<ChosenCourseListModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\vedat\source\repos\StudentPortal\StudentPortal.WebUI\Areas\Student\Views\Cart\GetChosenCourses.cshtml"
  
    ViewData["Title"] = "ChosenCourse Page";
    Layout = "~/Areas/Student/Views/Shared/_StudentLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n<div class=\"container\">\r\n    <div class=\"row\">\r\n");
#nullable restore
#line 9 "C:\Users\vedat\source\repos\StudentPortal\StudentPortal.WebUI\Areas\Student\Views\Cart\GetChosenCourses.cshtml"
         foreach (var chosenCourse in Model)
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\vedat\source\repos\StudentPortal\StudentPortal.WebUI\Areas\Student\Views\Cart\GetChosenCourses.cshtml"
             foreach (var chosenCourseItem in chosenCourse.ChosenCourseItems)
            {


#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    <div class=""col-xl-4 col-lg-4  col-md-6 col-sm-6 mb-3"">
                        <div class=""card card-custom card-stretch"">
                            <div class=""card-body"">
                                <div class=""d-flex flex-row align-items-center py-1"" style=""cursor: pointer; margin: 0;"">
                                    <div class=""symbol symbol-60 symbol-light-primary mr-5"">
                                        <span class=""symbol-label"">
                                            ");
#nullable restore
#line 20 "C:\Users\vedat\source\repos\StudentPortal\StudentPortal.WebUI\Areas\Student\Views\Cart\GetChosenCourses.cshtml"
                                       Write(chosenCourseItem.ChosenCourseItemId);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                        </span>
                                    </div>
                                    <div class=""d-flex flex-column my-lg-0 my-2 pr-3"">
                                        <a href=""javascript:;"" class=""text-dark font-weight-bolder text-hover-primary font-size-h5"">
                                            ");
#nullable restore
#line 25 "C:\Users\vedat\source\repos\StudentPortal\StudentPortal.WebUI\Areas\Student\Views\Cart\GetChosenCourses.cshtml"
                                       Write(chosenCourseItem.ChosenCourseName.ToUpper());

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                        </a>
                                        <span class=""text-muted font-weight-bold font-size-lg"">??rg??n ????retim</span>
                                    </div>
                                </div>
                                <div class=""d-flex"">
                                    <table class=""table"">
                                        <thead>
                                            <tr>
                                                <th style=""width: 20%"">
                                                    Oran
                                                </th>
                                                <th>
                                                    ??al????ma Tipi
                                                </th>
                                                <th style=""width: 30%"" class=""text-right"">
                                                    Not
                                                </th>");
            WriteLiteral(@"
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <td>
                                                    10
                                                </td>
                                                <td>
                                                    Ara S&#x131;nav
                                                </td>
                                                <td class=""text-right"">
                                                    ");
#nullable restore
#line 54 "C:\Users\vedat\source\repos\StudentPortal\StudentPortal.WebUI\Areas\Student\Views\Cart\GetChosenCourses.cshtml"
                                               Write(chosenCourseItem.Midterm);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    3
                                                </td>
                                                <td>
                                                    K&#x131;sa S&#x131;nav
                                                </td>
                                                <td class=""text-right"">
                                                    ");
#nullable restore
#line 65 "C:\Users\vedat\source\repos\StudentPortal\StudentPortal.WebUI\Areas\Student\Views\Cart\GetChosenCourses.cshtml"
                                               Write(chosenCourseItem.Quiz1);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    3
                                                </td>
                                                <td>
                                                    K&#x131;sa S&#x131;nav
                                                </td>
                                                <td class=""text-right"">
                                                    ");
#nullable restore
#line 76 "C:\Users\vedat\source\repos\StudentPortal\StudentPortal.WebUI\Areas\Student\Views\Cart\GetChosenCourses.cshtml"
                                               Write(chosenCourseItem.Quiz2);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    4
                                                </td>
                                                <td>
                                                    &#xD6;dev
                                                </td>
                                                <td class=""text-right"">
                                                    ");
#nullable restore
#line 87 "C:\Users\vedat\source\repos\StudentPortal\StudentPortal.WebUI\Areas\Student\Views\Cart\GetChosenCourses.cshtml"
                                               Write(chosenCourseItem.Homework);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    80
                                                </td>
                                                <td>
                                                    Final
                                                </td>
                                                <td class=""text-right"">
                                                    ");
#nullable restore
#line 98 "C:\Users\vedat\source\repos\StudentPortal\StudentPortal.WebUI\Areas\Student\Views\Cart\GetChosenCourses.cshtml"
                                               Write(chosenCourseItem.Final);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
");
#nullable restore
#line 107 "C:\Users\vedat\source\repos\StudentPortal\StudentPortal.WebUI\Areas\Student\Views\Cart\GetChosenCourses.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 107 "C:\Users\vedat\source\repos\StudentPortal\StudentPortal.WebUI\Areas\Student\Views\Cart\GetChosenCourses.cshtml"
             
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<ChosenCourseListModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
