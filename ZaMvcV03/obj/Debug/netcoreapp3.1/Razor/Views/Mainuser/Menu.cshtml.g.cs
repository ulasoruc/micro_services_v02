#pragma checksum "C:\Github_repo\micro_services\micro_services_v02\micro_services_v02\ZaMvcV03\Views\Mainuser\Menu.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "496afa2bec98bdb1831ed0ac93cfad333cc0e495"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Mainuser_Menu), @"mvc.1.0.view", @"/Views/Mainuser/Menu.cshtml")]
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
#line 1 "C:\Github_repo\micro_services\micro_services_v02\micro_services_v02\ZaMvcV03\Views\_ViewImports.cshtml"
using ZaMvcV03;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Github_repo\micro_services\micro_services_v02\micro_services_v02\ZaMvcV03\Views\_ViewImports.cshtml"
using ZaMvcV03.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"496afa2bec98bdb1831ed0ac93cfad333cc0e495", @"/Views/Mainuser/Menu.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c5551b74a190a5a30136319653b05ebe671dffaa", @"/Views/_ViewImports.cshtml")]
    public class Views_Mainuser_Menu : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "1", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("userform"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("role", new global::Microsoft.AspNetCore.Html.HtmlString("form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Github_repo\micro_services\micro_services_v02\micro_services_v02\ZaMvcV03\Views\Mainuser\Menu.cshtml"
  
    ViewData["Title"] = "Menu";
    Layout = "~/Views/Shared/_LayoutMain.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<div class=\"container\">\r\n");
            WriteLiteral(@"    <div id=""user"" style=""margin-top:1px;"" class=""mainbox col-md-12"">
        <div class=""panel panel-info"">
            <div class=""panel-heading"">
                <div class=""panel-title"">Kullanıcı Bilgi Girişi</div>
                <div style=""float:left; font-size: 80%; position: relative; top:-10px""></div>
            </div>

            <div style=""padding-top:3px"" class=""panel-body"">

                <div style=""display:none"" id=""login-alert"" class=""alert alert-danger col-sm-12""></div>

");
            WriteLiteral("                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "496afa2bec98bdb1831ed0ac93cfad333cc0e4955699", async() => {
                WriteLiteral(@"

                    <div class=""row"">
                        <div class=""col-md-4"">
                            <div style=""margin-bottom: 5px"" class=""input-group"">
                                <span class=""input-group-addon"">Durum </span>
                                <label class=""radio-inline"" style=""margin-left:5px""><input type=""radio"" name=""optStatus"" value=""1"" id=""statu_Active"" checked>Aktif</label>
                                <label class=""radio-inline""><input type=""radio"" name=""optStatus"" value=""0"" id=""statu_Passive"">Pasif</label>
                            </div>
                        </div>

                        <div class=""col-md-4"">
                            <div style=""margin-bottom: 5px"" class=""input-group"">
                                <span class=""input-group-addon"">Yetki </span>
                                <label class=""radio-inline"" style=""margin-left:5px""><input type=""radio"" name=""optAth"" value=""admin"" id=""auth_admin"" checked>Yönetici</label>
      ");
                WriteLiteral(@"                          <label class=""radio-inline""><input type=""radio"" name=""optAth"" value=""user"" id=""auth_user"">Kullanıcı</label>
                            </div>
                        </div>
                        <div class=""col-md-4"">
                            <div style=""margin-bottom: 5px"" class=""input-group"">
                                <span class=""input-group-addon"">Dil </span>
                                <select class=""form-control"" id=""optLang"" style=""margin-left:5px"">
                                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "496afa2bec98bdb1831ed0ac93cfad333cc0e4957636", async() => {
                    WriteLiteral("Türkçe");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                                </select>
                            </div>

                        </div>
                    </div>

                    <div class=""row"">
                        <div class=""col-md-4"">
                            <div style=""margin-bottom: 5px"" class=""input-group"">
                                <span class=""input-group-addon"">Kod</span>
                                <input type=""text"" class=""form-control"" name=""username""");
                BeginWriteAttribute("value", " value=\"", 2967, "\"", 2975, 0);
                EndWriteAttribute();
                WriteLiteral(@" placeholder=""Kullanıcı Kod"" id=""txtusername"">
                            </div>
                        </div>
                        <div class=""col-md-4"">
                            <div style=""margin-bottom: 5px"" class=""input-group"">
                                <span class=""input-group-addon"">E-mail</span>
                                <input type=""text"" class=""form-control"" name=""usermail""");
                BeginWriteAttribute("value", " value=\"", 3388, "\"", 3396, 0);
                EndWriteAttribute();
                WriteLiteral(@" placeholder=""Kullanıcı Mail"" id=""txtuseremail"">
                            </div>
                        </div>
                        <div class=""col-md-4"">
                            <div style=""margin-bottom: 5px"" class=""input-group"">
                                <span class=""input-group-addon"">Yedek E-Mail</i></span>
                                <input type=""text"" class=""form-control"" name=""userbackupmail""");
                BeginWriteAttribute("value", " value=\"", 3827, "\"", 3835, 0);
                EndWriteAttribute();
                WriteLiteral(@" placeholder=""Kullanıcı Yedek Mail"" id=""txtuserbackupemail"">
                            </div>
                        </div>
                    </div>

                    <div class=""row"">
                        <div class=""col-md-4"">
                            <div style=""margin-bottom: 5px"" class=""input-group"">
                                <span class=""input-group-addon""><i class=""glyphicon glyphicon-lock""></i></span>
                                <input type=""password"" class=""form-control"" name=""password"" placeholder=""Şifre"" id=""txtpass"">
                            </div>
                        </div>
                        <div class=""col-md-4"">
                            <div style=""margin-bottom: 5px"" class=""input-group"">
                                <span class=""input-group-addon""><i class=""glyphicon glyphicon-lock""></i></span>
                                <input type=""password"" class=""form-control"" name=""passwordrepeat"" placeholder=""Şifre Tekrar"" id=""txtpassrepeat"">");
                WriteLiteral("\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n\r\n");
                WriteLiteral(@"
                    <div class=""row"">
                        <div class=""col-md-4"">
                            <div style=""margin-bottom: 5px"" class=""input-group"">
                                <span class=""input-group-addon"">Oluşturma Tarih</i></span>
                                <input type=""text"" class=""form-control"" name=""CreateTime""");
                BeginWriteAttribute("value", " value=\"", 6213, "\"", 6221, 0);
                EndWriteAttribute();
                WriteLiteral(@" placeholder=""Tarih"" id=""txtcreateTime"">
                            </div>
                        </div>
                        <div class=""col-md-4"">
                            <div style=""margin-bottom: 5px"" class=""input-group"">
                                <span class=""input-group-addon"">Değiştirme Tarih</i></span>
                                <input type=""text"" class=""form-control"" name=""ChangeTime""");
                BeginWriteAttribute("value", " value=\"", 6644, "\"", 6652, 0);
                EndWriteAttribute();
                WriteLiteral(@" placeholder=""Tarih"" id=""txtchangeTime"">
                            </div>
                        </div>
                        <div class=""col-md-4"">
                            <div style=""margin-bottom: 5px"" class=""input-group"">
                                <span class=""input-group-addon"">Son Kullanma Tarih</i></span>
                                <input type=""text"" class=""form-control"" name=""ExpireTime""");
                BeginWriteAttribute("value", " value=\"", 7077, "\"", 7085, 0);
                EndWriteAttribute();
                WriteLiteral(" placeholder=\"Tarih\" id=\"txtexpireTime\">\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n\r\n\r\n");
                WriteLiteral(@"


                    <div style=""margin-top:10px"" class=""form-group"">
                        <!-- Button -->
                        <div class=""row"">
                            <div class=""col-sm-12 controls"">
                                <a id=""btnNew"" href=""#"" class=""btn btn-success"">Yeni </a>
                                <a id=""btnSave"" href=""#"" class=""btn btn-success"" style=""margin-left:15px"">Kaydet </a>
                                <a id=""btnList"" href=""#"" class=""btn btn-success"" style=""margin-left:15px"">Listele </a>
                                <a id=""btnActivationMain"" href=""#"" class=""btn btn-info"" style=""margin-left:15px"">Aktivasyon Mail </a>
                            </div>
                        </div>
                    </div>


                    <div class=""form-group"">
                        <div class=""col-md-12 control"">
                            <div style=""border-top: 1px solid#888; padding-top:15px; font-size:85%"">
                                ");
                WriteLiteral(@"<table id=""example"" class=""table table-responsive table-striped table-bordered"" style=""width:100%"">
                                    <thead>
                                        <tr>
                                            <th>Id</th>
                                            <th>Durum</th>
                                            <th>Yetki</th>
                                            <th>Kod</th>
                                            <th>Email</th>
                                            <th>SonTarih</th>
                                        </tr>
                                    </thead>
");
                WriteLiteral("                                </table>\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n            </div>\r\n        </div>\r\n    </div>\r\n\r\n</div>\r\n\r\n\r\n<h1>Menu</h1>\r\n\r\n");
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
