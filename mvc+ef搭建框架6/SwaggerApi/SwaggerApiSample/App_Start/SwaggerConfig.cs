using Swagger.Demo.Api;
using SwaggerApiSample;
using Swashbuckle.Application;
using System;
using System.IO;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.Description;
using WebActivatorEx;
[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace SwaggerApiSample
{
    public class SwaggerConfig
    {
        /// <summary>
        /// 获取生成文档路径
        /// </summary>
        /// <returns></returns>
        private static string GetXmlCommentsPath()
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bin", Assembly.GetExecutingAssembly().GetName().Name + ".xml");
        }

        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        // By default, the service root url is inferred from the request used to access the docs.
                        // However, there may be situations (e.g. proxy and load-balanced environments) where this does not
                        // resolve correctly. You can workaround this by providing your own code to determine the root URL.
                        //
                        //c.RootUrl(req => GetRootUrlFromAppConfig());

                        // If schemes are not explicitly provided in a Swagger 2.0 document, then the scheme used to access
                        // the docs is taken as the default. If your API supports multiple schemes and you want to be explicit
                        // about them, you can use the "Schemes" option as shown below.
                        //
                        //c.Schemes(new[] { "http", "https" });


                        // 配置简单API文档信息-用于单个文档
                        //c.SingleApiVersion("v1", "SwaggerApiSample");


                        // 如果要将输出Swagger文档正确缩进，请启用“PrettyPrint”选项。
                        //c.PrettyPrint();

                        // 如果您的API有多个版本，请使用“MultipleApiVersions”而不是“SingleApiVersion”。
                        // 包含在给定API版本的文档中。 像“SingleApiVersion”一样，每次调用“Version”
                        //  返回“信息”构建器，以便您可以为每个API版本提供其他元数据。
                        //
                        c.MultipleApiVersions(
                            (apiDesc, targetApiVersion) => ResolveVersionSupportByRouteConstraint(apiDesc, targetApiVersion),
                            (vc) =>
                            {
                                //vc.Version("v2", "Swashbuckle Dummy API V2");
                                //vc.Version("v1", "Swashbuckle Dummy API V1");
                                vc.Version("v1", "Common API", true).Description("登录，公共服务")
                                .Contact(x =>
                                {
                                    x.Name("2018").Email("nj_ybxie@sina.com").Url("https://www.cnblogs.com/xyb0226/");
                                });

                                vc.Version("Admin", "管理员 API").Description("管理员数据");
                                vc.Version("Brand", "品牌商 API").Description("品牌商管理");
                                vc.Version("Member", "会员 API").Description("会员管理");
                                vc.Version("Seller", "商家 API").Description("商家管理");
                            });

                        // 增加token至请求头部
                        //
                        c.ApiKey("Authorization").Description("token 值").In("header").Name("token");

                        //xml描述文档
                        //
                        c.IncludeXmlComments(GetXmlCommentsPath());

                        // 操作过滤器
                        //增加上传文件过滤操作
                        //
                        //c.OperationFilter<AddDefaultResponse>();

                        //增加Swagger区域选择
                        //
                        c.DocumentFilter<SwaggerAreasSupportDocumentFilter>();


                        //显示开发者信息
                        c.ShowDeveloperInfo();

                        // You can use "BasicAuth", "ApiKey" or "OAuth2" options to describe security schemes for the API.
                        // See https://github.com/swagger-api/swagger-spec/blob/master/versions/2.0.md for more details.
                        // NOTE: These only define the schemes and need to be coupled with a corresponding "security" property
                        // at the document or operation level to indicate which schemes are required for an operation. To do this,
                        // you'll need to implement a custom IDocumentFilter and/or IOperationFilter to set these properties
                        // according to your specific authorization implementation
                        //
                        //c.BasicAuth("basic")
                        //    .Description("Basic HTTP Authentication");
                        //


                        //c.OAuth2("oauth2")
                        //    .Description("OAuth2 Implicit Grant")
                        //    .Flow("implicit")
                        //    .AuthorizationUrl("http://petstore.swagger.wordnik.com/api/oauth/dialog")
                        //    //.TokenUrl("https://tempuri.org/token")
                        //    .Scopes(scopes =>
                        //    {
                        //        scopes.Add("read", "Read access to protected resources");
                        //        scopes.Add("write", "Write access to protected resources");
                        //    });

                        // Set this flag to omit descriptions for any actions decorated with the Obsolete attribute
                        //c.IgnoreObsoleteActions();

                        // Each operation be assigned one or more tags which are then used by consumers for various reasons.
                        // For example, the swagger-ui groups operations according to the first tag of each operation.
                        // By default, this will be controller name but you can use the "GroupActionsBy" option to
                        // override with any value.
                        //
                        //c.GroupActionsBy(apiDesc => apiDesc.HttpMethod.ToString());

                        // You can also specify a custom sort order for groups (as defined by "GroupActionsBy") to dictate
                        // the order in which operations are listed. For example, if the default grouping is in place
                        // (controller name) and you specify a descending alphabetic sort order, then actions from a
                        // ProductsController will be listed before those from a CustomersController. This is typically
                        // used to customize the order of groupings in the swagger-ui.
                        //
                        //c.OrderActionGroupsBy(new DescendingAlphabeticComparer());

                        // If you annotate Controllers and API Types with
                        // Xml comments (http://msdn.microsoft.com/en-us/library/b2s063f7(v=vs.110).aspx), you can incorporate
                        // those comments into the generated docs and UI. You can enable this by providing the path to one or
                        // more Xml comment files.
                        //



                        // Swashbuckle makes a best attempt at generating Swagger compliant JSON schemas for the various types
                        // exposed in your API. However, there may be occasions when more control of the output is needed.
                        // This is supported through the "MapType" and "SchemaFilter" options:
                        //
                        // Use the "MapType" option to override the Schema generation for a specific type.
                        // It should be noted that the resulting Schema will be placed "inline" for any applicable Operations.
                        // While Swagger 2.0 supports inline definitions for "all" Schema types, the swagger-ui tool does not.
                        // It expects "complex" Schemas to be defined separately and referenced. For this reason, you should only
                        // use the "MapType" option when the resulting Schema is a primitive or array type. If you need to alter a
                        // complex Schema, use a Schema filter.
                        //
                        //c.MapType<ProductType>(() => new Schema { type = "integer", format = "int32" });

                        // If you want to post-modify "complex" Schemas once they've been generated, across the board or for a
                        // specific type, you can wire up one or more Schema filters.
                        //
                        //c.SchemaFilter<ApplySchemaVendorExtensions>();

                        // In a Swagger 2.0 document, complex types are typically declared globally and referenced by unique
                        // Schema Id. By default, Swashbuckle does NOT use the full type name in Schema Ids. In most cases, this
                        // works well because it prevents the "implementation detail" of type namespaces from leaking into your
                        // Swagger docs and UI. However, if you have multiple types in your API with the same class name, you'll
                        // need to opt out of this behavior to avoid Schema Id conflicts.
                        //
                        //c.UseFullTypeNameInSchemaIds();

                        // Alternatively, you can provide your own custom strategy for inferring SchemaId's for
                        // describing "complex" types in your API.
                        //
                        //c.SchemaId(t => t.FullName.Contains('`') ? t.FullName.Substring(0, t.FullName.IndexOf('`')) : t.FullName);

                        // Set this flag to omit schema property descriptions for any type properties decorated with the
                        // Obsolete attribute
                        //c.IgnoreObsoleteProperties();

                        // In accordance with the built in JsonSerializer, Swashbuckle will, by default, describe enums as integers.
                        // You can change the serializer behavior by configuring the StringToEnumConverter globally or for a given
                        // enum type. Swashbuckle will honor this change out-of-the-box. However, if you use a different
                        // approach to serialize enums as strings, you can also force Swashbuckle to describe them as strings.
                        //
                        //c.DescribeAllEnumsAsStrings();


                        //

                        // If you've defined an OAuth2 flow as described above, you could use a custom filter
                        // to inspect some attribute on each action and infer which (if any) OAuth2 scopes are required
                        // to execute the operation
                        //
                        //c.OperationFilter<AssignOAuth2SecurityRequirements>();



                        // In contrast to WebApi, Swagger 2.0 does not include the query string component when mapping a URL
                        // to an action. As a result, Swashbuckle will raise an exception if it encounters multiple actions
                        // with the same path (sans query string) and HTTP method. You can workaround this by providing a
                        // custom strategy to pick a winner or merge the descriptions for the purposes of the Swagger docs
                        //
                        //c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());

                        // Wrap the default SwaggerGenerator with additional behavior (e.g. caching) or provide an
                        // alternative implementation for ISwaggerProvider with the CustomProvider option.
                        //
                        //c.CustomProvider((defaultProvider) => new CachingSwaggerProvider(defaultProvider));
                    })
                .EnableSwaggerUi(c =>
                    {
                        // Use the "DocumentTitle" option to change the Document title.
                        // Very helpful when you have multiple Swagger pages open, to tell them apart.
                        //
                        //c.DocumentTitle("My Swagger UI");

                        // Use the "InjectStylesheet" option to enrich the UI with one or more additional CSS stylesheets.
                        // The file must be included in your project as an "Embedded Resource", and then the resource's
                        // "Logical Name" is passed to the method as shown below.
                        //
                        //c.InjectStylesheet(containingAssembly, "Swashbuckle.Dummy.SwaggerExtensions.testStyles1.css");

                        // Use the "InjectJavaScript" option to invoke one or more custom JavaScripts after the swagger-ui
                        // has loaded. The file must be included in your project as an "Embedded Resource", and then the resource's
                        // "Logical Name" is passed to the method as shown above.
                        //
                        //c.InjectJavaScript(thisAssembly, "Swashbuckle.Dummy.SwaggerExtensions.testScript1.js");

                        // The swagger-ui renders boolean data types as a dropdown. By default, it provides "true" and "false"
                        // strings as the possible choices. You can use this option to change these to something else,
                        // for example 0 and 1.
                        //
                        //c.BooleanValues(new[] { "0", "1" });

                        // By default, swagger-ui will validate specs against swagger.io's online validator and display the result
                        // in a badge at the bottom of the page. Use these options to set a different validator URL or to disable the
                        // feature entirely.
                        //c.SetValidatorUrl("http://localhost/validator");
                        //c.DisableValidator();

                        // Use this option to control how the Operation listing is displayed.
                        // It can be set to "None" (default), "List" (shows operations for each resource),
                        // or "Full" (fully expanded: shows operations and their details).
                        //
                        //c.DocExpansion(DocExpansion.List);

                        // Specify which HTTP operations will have the 'Try it out!' option. An empty paramter list disables
                        // it for all operations.
                        //
                        //c.SupportedSubmitMethods("GET", "HEAD");

                        // Use the CustomAsset option to provide your own version of assets used in the swagger-ui.
                        // It's typically used to instruct Swashbuckle to return your version instead of the default
                        // when a request is made for "index.html". As with all custom content, the file must be included
                        // in your project as an "Embedded Resource", and then the resource's "Logical Name" is passed to
                        // the method as shown below.
                        //
                        //c.CustomAsset("index", containingAssembly, "YourWebApiProject.SwaggerExtensions.index.html");

                        // If your API has multiple versions and you've applied the MultipleApiVersions setting
                        // as described above, you can also enable a select box in the swagger-ui, that displays
                        // a discovery URL for each version. This provides a convenient way for users to browse documentation
                        // for different API versions.
                        //
                        //c.EnableDiscoveryUrlSelector();

                        // If your API supports the OAuth2 Implicit flow, and you've described it correctly, according to
                        // the Swagger 2.0 specification, you can enable UI support as shown below.
                        //
                        //c.EnableOAuth2Support(
                        //    clientId: "test-client-id",
                        //    clientSecret: null,
                        //    realm: "test-realm",
                        //    appName: "Swagger UI"
                        //    //additionalQueryStringParams: new Dictionary<string, string>() { { "foo", "bar" } }
                        //);

                        // If your API supports ApiKey, you can override the default values.
                        // "apiKeyIn" can either be "query" or "header"
                        //
                        //c.EnableApiKeySupport("apiKey", "header");

                        //c.InjectStylesheet(thisAssembly, "SwaggerApiSample.Swagger.theme-flattop.css");
                        //c.InjectJavaScript(thisAssembly, "SwaggerApiSample.Swagger.translator.js");

                        c.EnableApiKeySupport("Authorization", "header");

                    });
        }


        /// <summary>
        /// 通过路径约束解决版本支持
        /// </summary>
        /// <param name="apiDesc"></param>
        /// <param name="targetApiVersion"></param>
        /// <returns></returns>
        private static bool ResolveVersionSupportByRouteConstraint(ApiDescription apiDesc, string targetApiVersion)
        {
            if (targetApiVersion == "v1")
            {
                return apiDesc.Route.RouteTemplate.StartsWith("api/{controller}");
            }
            var routeTemplateStart = "api/" + targetApiVersion;
            return apiDesc.Route.RouteTemplate.StartsWith(routeTemplateStart);
        }
    }
}
