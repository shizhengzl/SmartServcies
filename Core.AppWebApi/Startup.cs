using AutoMapper;
using Core.AppSystemServices;
using Core.AppWebApi.Filters;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; 
namespace Core.AppWebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();


            //ע��AutoMapper����Mappings�����Լ�������ӳ����
            services.AddAutoMapper(typeof(Mappings));

            AutomaticInjection.AddAppServices(services);

            services.AddSingleton<IAuthorizationHandler, PermissionAuthorizationHandler>();
             


            //���ȫ���쳣�������
            services.AddMvc(option => {
                option.Filters.Add<GlobalExceptionsFilter>();
            });
            services.AddCors(option => option.AddPolicy("cors", policy => { policy.WithMethods("GET", "POST", "HEAD", "PUT", "DELETE", "OPTIONS").AllowAnyOrigin().AllowAnyHeader(); }));
            // ���Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "System Api", Version = "v1" });
            }); 
            services.AddHttpContextAccessor();

            AppSystemServices.InitDataBase initappsystem= new AppSystemServices.InitDataBase();
            
            Core.DataBaseServices.InitDatabase initdatabase = new DataBaseServices.InitDatabase();
            // ����Bearer��֤
            services.AddAuthentication(o => {
                o.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultChallengeScheme = nameof(ApiResponseHandler);
                o.DefaultForbidScheme = nameof(ApiResponseHandler);
            })
             // ���JwtBearer����
             .AddJwtBearer(o =>
             {
                // o.TokenValidationParameters = "Authorization";
                 o.Events = new JwtBearerEvents
                 {
                     OnAuthenticationFailed = context =>
                     {
              // ������ڣ����<�Ƿ����>��ӵ�������ͷ��Ϣ��
              if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                         {
                             context.Response.Headers.Add("Token-Expired", "true");
                         }
                         return Task.CompletedTask;
                     }
                 };
             })
             .AddScheme<AuthenticationSchemeOptions, ApiResponseHandler>(nameof(ApiResponseHandler), o => { });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // ���Swagger�й��м��
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "System Api");
            });

            app.UseCors("cors");
            app.UseHttpsRedirection();
            app.UseRequestResponseLogging();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
