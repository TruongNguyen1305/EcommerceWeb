#pragma checksum "D:\visual studio\C#\EcommerceWebApp\EcommerceWebApp\Views\CheckOut\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cfb34b537b3aea4957a9bd9a2abe364cd56d2723"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_CheckOut_Index), @"mvc.1.0.view", @"/Views/CheckOut/Index.cshtml")]
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
#line 1 "D:\visual studio\C#\EcommerceWebApp\EcommerceWebApp\Views\_ViewImports.cshtml"
using EcommerceWebApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\visual studio\C#\EcommerceWebApp\EcommerceWebApp\Views\_ViewImports.cshtml"
using EcommerceWebApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cfb34b537b3aea4957a9bd9a2abe364cd56d2723", @"/Views/CheckOut/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7f52b12d5d6ebe268c3a991717aeb3c1526997d4", @"/Views/_ViewImports.cshtml")]
    public class Views_CheckOut_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<OrderDetail>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("145"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("height", new global::Microsoft.AspNetCore.Html.HtmlString("145"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("poster_1_up"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("shop_thumbnail"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("enctype", new global::Microsoft.AspNetCore.Html.HtmlString("multipart/form-data"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "CheckOut", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "BuySuccess", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("checkout"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", new global::Microsoft.AspNetCore.Html.HtmlString("checkout"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\visual studio\C#\EcommerceWebApp\EcommerceWebApp\Views\CheckOut\Index.cshtml"
  
    ViewData["Title"] = "Checkout";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""product-big-title-area"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-md-12"">
                <div class=""product-bit-title text-center"">
                    <h2>Shopping Cart</h2>
                </div>
            </div>
        </div>
    </div>
</div>


<div class=""single-product-area"">
    <div class=""zigzag-bottom""></div>
    <div class=""container"">
        <div class=""row"">
            <div class=""col-md-12"">
                <div class=""product-content-right"">
                    <div class=""woocommerce"">
                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cfb34b537b3aea4957a9bd9a2abe364cd56d27237630", async() => {
                WriteLiteral(@"

                            <div id=""customer_details"" class=""container"">
                                <div class=""row"">
                                    <div class=""woocommerce-billing-fields col-md-8"">
                                        <h3>Billing Details</h3>
                                        <input type=""hidden""");
                BeginWriteAttribute("value", " value=\"", 1198, "\"", 1220, 1);
#nullable restore
#line 32 "D:\visual studio\C#\EcommerceWebApp\EcommerceWebApp\Views\CheckOut\Index.cshtml"
WriteAttributeValue("", 1206, Model.OrderId, 1206, 14, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" name=\"OrderId\"/>\r\n                                        <p id=\"billing_full_name_field\" class=\"form-row form-row-first validate-required\">\r\n                                            <label");
                BeginWriteAttribute("class", " class=\"", 1414, "\"", 1422, 0);
                EndWriteAttribute();
                WriteLiteral(@" for=""billing_full_name"">
                                                Full Name <abbr title=""required"" class=""required"">*</abbr>
                                            </label>
                                            <input required type=""text""");
                BeginWriteAttribute("value", " value=\"", 1683, "\"", 1691, 0);
                EndWriteAttribute();
                BeginWriteAttribute("placeholder", " placeholder=\"", 1692, "\"", 1706, 0);
                EndWriteAttribute();
                WriteLiteral(@" id=""billing_full_name"" name=""FullName"" class=""input-text "">
                                        </p>


                                        <div class=""clear""></div>

                                        <p id=""billing_address_1_field"" class=""form-row form-row-wide address-field validate-required"">
                                            <label");
                BeginWriteAttribute("class", " class=\"", 2075, "\"", 2083, 0);
                EndWriteAttribute();
                WriteLiteral(@" for=""billing_address_1"">
                                                Address <abbr title=""required"" class=""required"">*</abbr>
                                            </label>
                                            <input required type=""text""");
                BeginWriteAttribute("value", " value=\"", 2342, "\"", 2350, 0);
                EndWriteAttribute();
                WriteLiteral(@" placeholder=""Street address"" id=""billing_address_1"" name=""Address"" class=""input-text "">
                                        </p>

 

                                        <div class=""clear""></div>

                                        <p id=""billing_email_field"" class=""form-row form-row-first validate-required validate-email"">
                                            <label");
                BeginWriteAttribute("class", " class=\"", 2748, "\"", 2756, 0);
                EndWriteAttribute();
                WriteLiteral(@" for=""billing_email"">
                                                Email Address <abbr title=""required"" class=""required"">*</abbr>
                                            </label>
                                            <input required type=""text""");
                BeginWriteAttribute("value", " value=\"", 3017, "\"", 3025, 0);
                EndWriteAttribute();
                BeginWriteAttribute("placeholder", " placeholder=\"", 3026, "\"", 3040, 0);
                EndWriteAttribute();
                WriteLiteral(@" id=""billing_email"" name=""Email"" class=""input-text "">
                                        </p>

                                        <p id=""billing_phone_field"" class=""form-row form-row-last validate-required validate-phone"">
                                            <label");
                BeginWriteAttribute("class", " class=\"", 3328, "\"", 3336, 0);
                EndWriteAttribute();
                WriteLiteral(" for=\"billing_phone\">\r\n                                                Phone <abbr title=\"required\" class=\"required\">*</abbr>\r\n                                            </label>\r\n                                            <input required type=\"text\"");
                BeginWriteAttribute("value", " value=\"", 3589, "\"", 3597, 0);
                EndWriteAttribute();
                BeginWriteAttribute("placeholder", " placeholder=\"", 3598, "\"", 3612, 0);
                EndWriteAttribute();
                WriteLiteral(@" id=""billing_phone"" name=""Phone"" class=""input-text "">
                                        </p>
                                        <div class=""clear""></div>
                                    </div>
                                </div>

                            </div>

                            <h3 id=""order_review_heading"">Your order</h3>

                            <div id=""order_review"" style=""position: relative;"">
                                <table class=""shop_table"">
                                    <thead>
                                        <tr>
                                            <th class=""product-thumbnail"">&nbsp;</th>
                                            <th class=""product-name"">Product</th>
                                            <th class=""product-total"">Total</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                 ");
                WriteLiteral("       <tr class=\"cart_item\">\r\n                                            <td class=\"product-thumbnail\">\r\n                                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "cfb34b537b3aea4957a9bd9a2abe364cd56d272313852", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                AddHtmlAttributeValue("", 4868, "~/images/products/", 4868, 18, true);
#nullable restore
#line 87 "D:\visual studio\C#\EcommerceWebApp\EcommerceWebApp\Views\CheckOut\Index.cshtml"
AddHtmlAttributeValue("", 4886, Model.Product.Thumb, 4886, 20, false);

#line default
#line hidden
#nullable disable
                EndAddHtmlAttributeValues(__tagHelperExecutionContext);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                                            </td>\r\n                                            <td class=\"product-name\">\r\n                                                ");
#nullable restore
#line 90 "D:\visual studio\C#\EcommerceWebApp\EcommerceWebApp\Views\CheckOut\Index.cshtml"
                                           Write(Model.Product.ProductName);

#line default
#line hidden
#nullable disable
                WriteLiteral(" <strong class=\"product-quantity\">× ");
#nullable restore
#line 90 "D:\visual studio\C#\EcommerceWebApp\EcommerceWebApp\Views\CheckOut\Index.cshtml"
                                                                                                         Write(Model.Quantity);

#line default
#line hidden
#nullable disable
                WriteLiteral("</strong>\r\n                                            </td>\r\n                                            <td class=\"product-total\">\r\n                                                <span class=\"amount\">");
#nullable restore
#line 93 "D:\visual studio\C#\EcommerceWebApp\EcommerceWebApp\Views\CheckOut\Index.cshtml"
                                                                Write(Model.Total.Value.ToString("#,###"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@" VND</span>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                            <input type=""submit"" class=""btn btn-lg-square btn-primary"" value=""Submit"" />
                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_8.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_9);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<OrderDetail> Html { get; private set; }
    }
}
#pragma warning restore 1591
