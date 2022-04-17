using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace StarPeace.Extensions.Service
{
    public class Startup
    {  
        public IConfiguration Configuration { get; }     
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration ?? throw new ArgumentNullException(nameof(Configuration));
        }        

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


            var connectionString = Configuration["ConnectionStrings:StarPeaceExtentionsDbConnectionString"];
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
                        // return a 422 incase of a validation error because by default  api controllers return a 400 bad request
                        return new UnprocessableEntityObjectResult(actionContext.ModelState);
                    }

                    // if one of the keys wasn't correctly found / couldn't be parsed
                    // we're dealing with null/unparseable input
                    return new BadRequestObjectResult(actionContext.ModelState);
                };
            });            

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            
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

                setupAction.OperationFilter<SecurityRequirementsOperationFilter>();

                var xmlCommentsFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";

                var xmlCommentsFullPath = Path.Combine(AppContext.BaseDirectory, xmlCommentsFile);

                setupAction.IncludeXmlComments(xmlCommentsFullPath);
            });

        }

        //This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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

            //Enable CORS
            app.UseCors("AllowAllOriginsHeadersAndMethods");

            app.UseAuthorization();

            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
