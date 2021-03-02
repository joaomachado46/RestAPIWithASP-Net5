using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RestAPIWithASP_Net5.Model.DataContext;
using Microsoft.EntityFrameworkCore;
using RestAPIWithASP_Net5.Repository;
using RestAPIWithASP_Net5.Business.Implementations;
using Serilog;
using RestAPIWithASP_Net5.person.Business;
using RestAPIWithASP_Net5.book.Business;
using RestAPIWithASP_Net5.Repository.Repository;
using Microsoft.OpenApi.Models;
using Microsoft.Net.Http.Headers;
using RestAPIWithASP_Net5.Business;
using RestAPIWithASP_Net5.Services;
using RestAPIWithASP_Net5.Services.Implementations;
using RestAPIWithASP_Net5.Configurations;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.AspNetCore.Http;

namespace RestAPIWithASP_Net5
{
    //NUGET NECESSARIO DE INSTALAR PARA USAR MIGRACIONS/LOGGER
    /*  PackageReference = Evolve
     *  PackageReference = Serilog
        PackageReference = "Serilog.AspNetCore"
        PackageReference = "Serilog.Sinks.Console"*/
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment _environment)
        {
            Configuration = configuration;
            Environment = _environment;

            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();
        }



        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //PARA DEFINIR A AUTENTICAÇÃO
            var tokenConfigurations = new TokenConfiguration();
            new ConfigureFromConfigurationOptions<TokenConfiguration>(
                Configuration.GetSection("TokenConfiguration")
                )
                .Configure(tokenConfigurations);

            services.AddSingleton(tokenConfigurations);

            services.AddAuthentication(Options =>
            {
                Options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                Options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(Options =>
                {
                    Options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = tokenConfigurations.Issuer,
                        ValidAudience = tokenConfigurations.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenConfigurations.Secret))
                    };
                });

            services.AddAuthorization(Auth =>
            {
                Auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser().Build());
            });
            //-------------------------------------------
            services.AddDbContext<MySqlContext>(options => options.UseMySql(Configuration.GetConnectionString("MySqlConnectionString")));

            //PARA RECEBER FORMATO EM XML
            services.AddMvc(option =>
            {
                option.RespectBrowserAcceptHeader = true;
                option.FormatterMappings.SetMediaTypeMappingForFormat("xml", MediaTypeHeaderValue.Parse("application/xml"));
                option.FormatterMappings.SetMediaTypeMappingForFormat("json", MediaTypeHeaderValue.Parse("application/json"));
            })
                .AddXmlSerializerFormatters();

            //-------------------------

            //CONFIGURAR O CORS
            services.AddCors(options => options.AddDefaultPolicy(buider =>
            {
                buider.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            }));


            services.AddControllers();
            //INJEÇAO DE DEPENDENCIA
            //CLASS BOOK
            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IBookBusiness, BookBusinessImplementation>();

            //INJETAR TOKEN PARAAUTENTICAÇÃO
            services.AddScoped<ILoginBusiness, LoginBusinessImplementation>();
            services.AddTransient<ITokenService, TokenService>();
            services.AddScoped<IUserRepository, UserRepository>();

            //INJETAR FILE UPLOAD
            services.TryAddTransient<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IFileBusiness, FileBusinessImplementation>();

            //CLASS PERSON
            services.AddScoped<IPersonBusiness, IPersonBusinessImplementation>();
            services.AddScoped<IPersonRepository, PersonRepository>();

            //PARA VERSIONAMENTO DA API
            services.AddApiVersioning();

            //DEFINIR O ARRANQUE COM O SWAGGER
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Rest Api",
                    Version = "v1",
                    Description = "Api developed in course",
                    Contact = new OpenApiContact
                    {
                        Name = "João Machado",
                        Url = new System.Uri("https://github.com/joaomachado46"),
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //DEFINIR O ARRANQUE COM O SWAGGER
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Rest Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            //PARA DEFINIR/CONFUGURAR CORS TEM QUE SE COLOCAR ESSA DEFINIÇÃO ANTES DE (app.UseEndpoints)
            //E DEPOIS DE (app.UseHttpsRedirection()) E (app.UseRouting())
            app.UseCors(); //<--ISTO

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
