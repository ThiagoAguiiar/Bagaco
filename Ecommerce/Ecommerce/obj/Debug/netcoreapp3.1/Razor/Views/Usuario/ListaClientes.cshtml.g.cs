#pragma checksum "C:\Users\aluno\Downloads\Ecommerce\Ecommerce\Ecommerce\Views\Usuario\ListaClientes.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "521ab47ebf90a81584a7bfbe6828d73bee756176"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Usuario_ListaClientes), @"mvc.1.0.view", @"/Views/Usuario/ListaClientes.cshtml")]
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
#line 1 "C:\Users\aluno\Downloads\Ecommerce\Ecommerce\Ecommerce\Views\_ViewImports.cshtml"
using Ecommerce;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\aluno\Downloads\Ecommerce\Ecommerce\Ecommerce\Views\_ViewImports.cshtml"
using Ecommerce.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\aluno\Downloads\Ecommerce\Ecommerce\Ecommerce\Views\Usuario\ListaClientes.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\aluno\Downloads\Ecommerce\Ecommerce\Ecommerce\Views\Usuario\ListaClientes.cshtml"
using Newtonsoft.Json;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"521ab47ebf90a81584a7bfbe6828d73bee756176", @"/Views/Usuario/ListaClientes.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6bbcd7c65731fc074a835809e73fcf2cf9014c29", @"/Views/_ViewImports.cshtml")]
    public class Views_Usuario_ListaClientes : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Usuario>
    {
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 4 "C:\Users\aluno\Downloads\Ecommerce\Ecommerce\Ecommerce\Views\Usuario\ListaClientes.cshtml"
  
    Usuario u = JsonConvert.DeserializeObject<Usuario>(Context.Session.GetString("user").ToString());

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n<p class=\"nome\">");
#nullable restore
#line 10 "C:\Users\aluno\Downloads\Ecommerce\Ecommerce\Ecommerce\Views\Usuario\ListaClientes.cshtml"
           Write(u.Nome);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n<p class=\"nome\">");
#nullable restore
#line 11 "C:\Users\aluno\Downloads\Ecommerce\Ecommerce\Ecommerce\Views\Usuario\ListaClientes.cshtml"
           Write(u.Cpf);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n<p class=\"nome\">");
#nullable restore
#line 12 "C:\Users\aluno\Downloads\Ecommerce\Ecommerce\Ecommerce\Views\Usuario\ListaClientes.cshtml"
           Write(u.Telefone);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n<p class=\"nome\">");
#nullable restore
#line 13 "C:\Users\aluno\Downloads\Ecommerce\Ecommerce\Ecommerce\Views\Usuario\ListaClientes.cshtml"
           Write(u.Senha);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n<p class=\"nome\">");
#nullable restore
#line 14 "C:\Users\aluno\Downloads\Ecommerce\Ecommerce\Ecommerce\Views\Usuario\ListaClientes.cshtml"
           Write(u.Tipo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n\r\n<!DOCTYPE html>\r\n<html lang=\"pt-br\">\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "521ab47ebf90a81584a7bfbe6828d73bee7561765275", async() => {
                WriteLiteral(@"
    <meta charset=""UTF-8"">
    <meta http-equiv=""X-UA-Compatible"" content=""IE=edge"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    <script src=""https://kit.fontawesome.com/19a96cf4ea.js"" crossorigin=""anonymous""></script>
    <link rel=""stylesheet"" href=""assets/css/adm_clientes.css"">
    <title>Bagaço - Clientes</title>
");
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "521ab47ebf90a81584a7bfbe6828d73bee7561766618", async() => {
                WriteLiteral(@"
    <header class=""header"">
        <div class=""logo"">
            <a href=""adm_clientes.html"" id=""logo"">BAGAÇO</a>
        </div>
        <nav>
            <a href=""adm_produtos.html"" class=""nav-link"">Produtos</a>
            <a href=""adm_cadastrar.html"" class=""nav-link"">Cadastrar</a>
            <a");
                BeginWriteAttribute("href", " href=\"", 1074, "\"", 1081, 0);
                EndWriteAttribute();
                WriteLiteral(" class=\"nav-link\">Vendas</a>\r\n            <a");
                BeginWriteAttribute("href", " href=\"", 1126, "\"", 1133, 0);
                EndWriteAttribute();
                WriteLiteral(" class=\"nav-link\">Relatórios</a>\r\n            <div id=\"divider\"></div>\r\n            <a");
                BeginWriteAttribute("href", " href=\"", 1220, "\"", 1227, 0);
                EndWriteAttribute();
                WriteLiteral(@" class=""nav-link  user"">
                <i class=""fa-solid fa-user""></i>
            </a>
        </nav>
    </header>

    <div class=""container"">
        <div class=""container-txt"">
            <p>CLIENTES</p>
        </div>


        <ul class=""clientes"">
            <li>
                <div class=""info-cliente"">
                    <div>
                        <p class=""nome"">NOME DO CLIENTE: ");
#nullable restore
#line 53 "C:\Users\aluno\Downloads\Ecommerce\Ecommerce\Ecommerce\Views\Usuario\ListaClientes.cshtml"
                                                    Write(u.Nome);

#line default
#line hidden
#nullable disable
                WriteLiteral(" </p>\r\n                        <p class=\"nome\">CPF DO CLIENTE: ");
#nullable restore
#line 54 "C:\Users\aluno\Downloads\Ecommerce\Ecommerce\Ecommerce\Views\Usuario\ListaClientes.cshtml"
                                                   Write(u.Cpf);

#line default
#line hidden
#nullable disable
                WriteLiteral(" </p>\r\n                        <p class=\"nome\">ENDEREÇO DO CLIENTE:");
#nullable restore
#line 55 "C:\Users\aluno\Downloads\Ecommerce\Ecommerce\Ecommerce\Views\Usuario\ListaClientes.cshtml"
                                                       Write(u.Endereco);

#line default
#line hidden
#nullable disable
                WriteLiteral(" </p>\r\n                        <p class=\"nome\">TELEFONE DO CLIENTE: ");
#nullable restore
#line 56 "C:\Users\aluno\Downloads\Ecommerce\Ecommerce\Ecommerce\Views\Usuario\ListaClientes.cshtml"
                                                        Write(u.Telefone);

#line default
#line hidden
#nullable disable
                WriteLiteral(" </p>\r\n                        p class=\"nome\">SENHA DO CLIENTE: ");
#nullable restore
#line 57 "C:\Users\aluno\Downloads\Ecommerce\Ecommerce\Ecommerce\Views\Usuario\ListaClientes.cshtml"
                                                    Write(u.Telefone);

#line default
#line hidden
#nullable disable
                WriteLiteral(" </p>\r\n                    </div>\r\n                </div>\r\n\r\n            </li>\r\n        </ul>\r\n    </div>\r\n");
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
            WriteLiteral("\r\n</html>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Usuario> Html { get; private set; }
    }
}
#pragma warning restore 1591
