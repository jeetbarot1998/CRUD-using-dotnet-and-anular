using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Crud
{
    public class Startup
    {
        public Startup(IConfiguration configuration) 
        {
            //Iconfiguration Represents a set of key/value application configuration properties.
            //ASP.NET Core supports many methods of configuration. In ASP.NET Core application, the configuration is stored in name-value pairs and it can be read at runtime from various parts of the application. The name-value pairs may be grouped into a multi-level hierarchy. The application configuration data may come from
            //File, such as JSON, XML, Environment, Command Line,  An in-memory collection
            //Custom providers
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {   // All Dependency injections to be mentioned here.

            //services.AddCors(options => {
            //        options.AddPolicy("Policy2", builder => {
            //        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
            //    });
            //});
            
            services.AddCors();

            var key = Encoding.UTF8.GetBytes(Configuration["ApplicationSettings:JWT_Secret"].ToString());

            services.AddAuthentication(x =>
            {
            // DefaultScheme: if specified, all the other defaults will fallback to this value
            //DefaultAuthenticateScheme: if specified, AuthenticateAsync() will use this scheme, and also the AuthenticationMiddleware added by UseAuthentication() will use this scheme to set context.User automatically. (Corresponds to AutomaticAuthentication)
            //DefaultChallengeScheme if specified, ChallengeAsync() will use this scheme, [Authorize] with policies that don't specify schemes will also use this
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x => { // to configure the JWT itself
                x.RequireHttpsMetadata = false;
                x.SaveToken = false;
                x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero // zero time lag btw the server and client
                };
            });

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Crud", Version = "v1" });
            });
            

            services.AddDefaultIdentity<Models.ApplicationUser>().AddRoles<IdentityRole>().AddEntityFrameworkStores<Models.AuthenticationContext>();

            services.AddMvc().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
            });

            services.AddDbContext<Models.AuthenticationContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("IdentityConnections"))); // For IDBContext

            services.AddDbContext<Models.DetailContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DevConnections")));

            // IdentityDbContext Base class for the Entity Framework database context used for identity.
            //These services include services like the UserStore service and the SignInManager.
            //We need to inject both of these services into our controller.
            //With this, we can call the appropriate APIs when we need to create a user or sign in a user.
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 4;
            }
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Crud v1"));
            }


            // These middlewares run sequencially.
            app.UseAuthentication();

            //app.UseCors();



            app.UseHttpsRedirection();

            app.UseRouting();
            
            app.UseCors(options =>
           options.AllowAnyOrigin()
           .AllowAnyHeader()
           .AllowAnyMethod()
           );

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
