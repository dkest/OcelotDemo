using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace PassengerApi.Config
{
    public class SwaggerConfigure
    {
        public static void ConfigureSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                //此处的Name 是控制器上分组的名称     Title是界面的大标题
                //分组
                options.SwaggerDoc("Passenger", new OpenApiInfo { Title = "Passenger模块", Version = "Passenger", });

                // 接口排序
                options.OrderActionsBy(o => o.GroupName);

                options.DocInclusionPredicate((docName, apiDes) =>
                {
                    if (!apiDes.TryGetMethodInfo(out MethodInfo methodInfo)) return false;
                    var versions = methodInfo.DeclaringType.GetCustomAttributes(true)
                    .OfType<ApiExplorerSettingsAttribute>()
                    .Select(attr => attr.GroupName);

                    return versions.Any(v => v.ToString() == docName);
                });

                var xmlPath = Path.Combine(AppContext.BaseDirectory, "PassengerApi.xml");//这个就是刚刚配置的xml文件名
                options.IncludeXmlComments(xmlPath, true);
                //默认的第二个参数是false，这个是controller的注释，记得修改


                // 在header中添加token，传递到后台
                //options.OperationFilter<SecurityRequirementsOperationFilter>();

                // Bearer 
                //options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                //{
                //    Description = "JWT Authorization header using the Bearer scheme.",
                //    Name = "Authorization",
                //    In = ParameterLocation.Header,
                //    Scheme = "bearer",
                //    Type = SecuritySchemeType.Http,
                //    BearerFormat = "JWT"
                //});
            });
        }

        public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                //此处的Name 是页面  选择文档下拉框 显示的名称
                options.SwaggerEndpoint($"swagger/Passenger/swagger.json", "Passenger模块");


                //路径配置，设置为空，表示直接在根域名（localhost:8001）访问该文件,
                //注意localhost:8001/swagger是访问不到的，去launchSettings.json把launchUrl去掉，如果你想换一个路径，直接写名字即可，比如直接写c.Route = "doc";
                options.RoutePrefix = string.Empty;
                //DocExpansion设置为none可折叠所有方法
                options.DocExpansion(DocExpansion.None);
                //DefaultModelsExpandDepth设置为 - 1 可不显示models
                options.DefaultModelsExpandDepth(-1);

            });
        }
    }
}
