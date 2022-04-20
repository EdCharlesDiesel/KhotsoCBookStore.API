﻿
using KhotsoCBookStore.API.Contexts;
using KhotsoCBookStore.API.Repositories;
using KhotsoCBookStore.API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace KhotsoCBookStore.API
{
    public class Startup
    {       
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
           // baseAccountsUrl = "https://localhost:8000";
        }

      //  private string baseAccountsUrl;

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(setupAction =>
            {
                setupAction.ReturnHttpNotAcceptable = true;

                setupAction.Filters.Add(
                    new ProducesResponseTypeAttribute(StatusCodes.Status500InternalServerError));

                setupAction.OutputFormatters.Add(new XmlSerializerOutputFormatter());

                var jsonOutputFormatter = setupAction.OutputFormatters
                 .OfType<SystemTextJsonOutputFormatter>().FirstOrDefault();

                if (jsonOutputFormatter != null)
                {
                    // remove text/json as it isn't the approved media type
                    // for working with JSON at API level
                    if (jsonOutputFormatter.SupportedMediaTypes.Contains("text/json"))
                    {
                        jsonOutputFormatter.SupportedMediaTypes.Remove("text/json");
                    }
                }
            });

            services.AddHttpContextAccessor();


            var connectionString = Configuration["ConnectionStrings:KhotsoCbookStoreDBConnectionString"];
            services.AddDbContext<KhotsoCBookStoreDbContext>(o => o.UseSqlServer(connectionString));

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = actionContext =>
                {
                    var actionExecutingContext =
                        actionContext as Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext;

                    // if there are modelstate errors & all keys were correctly
                    // found/parsed we're dealing with validation errors
                    if (actionContext.ModelState.ErrorCount > 0
                        && actionExecutingContext?.ActionArguments.Count == actionContext.ActionDescriptor.Parameters.Count)
                    {
                        //return a 422 incase of a validation error because by default  api controllers return a 400 bad request
                        return new UnprocessableEntityObjectResult(actionContext.ModelState);
                    }

                    // if one of the keys wasn't correctly found / couldn't be parsed
                    // we're dealing with null/unparseable input
                    return new BadRequestObjectResult(actionContext.ModelState);
                };
            });            

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            // services.AddSingleton<IIdentityServer4Service, IdentityServer4Repository>();
            services.AddTransient<ICustomerService, CustomerRepository>();
            services.AddTransient<IEmployeeService, EmployeeRepository>();
            services.AddTransient<IBookService, BookRepository>();
            services.AddTransient<IProductSubscriptionService, ProductSubscriptionRepository>();
            services.AddTransient<ICartService, CartRepository>();
            services.AddTransient<IOrderService, OrderRepository>();
            services.AddTransient<IWishListService, WishListRepository>();
            services.AddTransient<IMailService, LocalMailRepository>();
            services.AddTransient<IAuthorService, AuthorRepository>();
            services.AddTransient<IPublisherService, PublisherRepository>();
            services.AddTransient<IPromotionService, PromotionRepository>();
            services.AddTransient<ICategoryService, CategoryRepository>();
            
            
            services.AddAuthentication(option =>  
            {  
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;  
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;  
  
            }).AddJwtBearer(options =>
           {
            //    options.RequireHttpsMetadata = false;
            //    options.SaveToken = true;
            //    options.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        ValidateIssuer = true,
            //        ValidateAudience = true,
            //        ValidateLifetime = true,
            //        ValidateIssuerSigningKey = true,
            //        ValidIssuer = Configuration["Jwt:Issuer"],
            //        ValidAudience = Configuration["Jwt:Audience"],
            //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:SecretKey"])),
            //        ClockSkew = TimeSpan.Zero // Override the default clock skew of 5 mins
            //     };

                // options.Authority = "http://localhost:8000";
                // options.Audience = "khotsoCBookStoreApi";
                // options.RequireHttpsMetadata = false;

               services.AddCors();
           });

          

            // services.AddAuthorization(options =>
            //  {
            //  options.AddPolicy("khotsoCBookStoreApi", policy => policy.RequireClaim("scope", "khotsoCBookStoreApi.read"));
            // // options.AddPolicy("Consumer", policy => policy.RequireClaim(ClaimTypes.Role, "consumer"));
            //  });

            // services.AddAuthorization(config =>
            // {
            //     config.AddPolicy(UserRoles.Admin, Policies.AdminPolicy());
            //     config.AddPolicy(UserRoles.User, Policies.UserPolicy());
            // });


            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOriginsHeadersAndMethods",
                    builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });

            services.AddSwaggerGen(setupAction =>
            {
                setupAction.SwaggerDoc("KhotsoCBookStoreAPISpecification", new OpenApiInfo()
                {
                    Title = "KhotsoCBookStore API V2.1.1",
                    Version = "2.1.1",
                    Description = "API for an online book store where a user can purchase a subscription to any book available in the product catalogue created with ASP.NET Core 5.0",
                    Contact = new OpenApiContact()
                    {
                        Email = "Mokhetkc@hotmail.com",
                        Name = "Khotso Mokhethi",
                        Url = new Uri("https://wwww.github.com/EdCharlesDiesel")
                    }
                });

                // setupAction.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                // {
                //     Description = "Standard JWT Authorization header. Example: \"bearer {token}\"",
                //     Name = "Authorization",
                //     In = ParameterLocation.Header,
                //     Type = SecuritySchemeType.ApiKey
                // });

                // setupAction.AddSecurityDefinition("AccountsOpenID", new OpenApiSecurityScheme
                // {
                //     Type = SecuritySchemeType.OpenIdConnect,
                //     OpenIdConnectUrl = new Uri($"{baseAccountsUrl}/.well-known/openid-configuration")
                
                // });

                //   setupAction.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                // {
                //     Type = SecuritySchemeType.OAuth2,
                //     Flows = new OpenApiOAuthFlows
                //     {
                //         AuthorizationCode = new OpenApiOAuthFlow
                //         {
                //             AuthorizationUrl = new Uri("https://localhost:8000/connect/authorize"),
                //             TokenUrl = new Uri("https://localhost:8000/connect/token"),
                //             Scopes = new Dictionary<string, string>
                //             {
                //                 {"khotsoCBookStoreApi",  "KhotsoCBookStore Api - full access"}
                //             }
                //         }
                //     },
                //     OpenIdConnectUrl =  new Uri($"{baseAccountsUrl}/.well-known/openid-configuration")
                // });

                setupAction.OperationFilter<SecurityRequirementsOperationFilter>();

                var xmlCommentsFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";

                var xmlCommentsFullPath = Path.Combine(AppContext.BaseDirectory, xmlCommentsFile);

                setupAction.IncludeXmlComments(xmlCommentsFullPath);
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseSwagger();

            app.UseSwaggerUI(setupAction =>
            {
                setupAction.SwaggerEndpoint("/swagger/KhotsoCBookStoreAPISpecification/swagger.json",
                 "KhotsoCBookStore API V2.1.1");

                setupAction.RoutePrefix = "";

                setupAction.DefaultModelExpandDepth(2);
                setupAction.DefaultModelRendering(Swashbuckle.AspNetCore.SwaggerUI.ModelRendering.Model);
                setupAction.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);

                setupAction.EnableDeepLinking();
                setupAction.DisplayOperationId();
            });

            // Enable CORS
            app.UseCors("AllowAllOriginsHeadersAndMethods");

            // app.UseAuthorization();

            // app.UseAuthentication();
            //app.UseIdentityServer();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
