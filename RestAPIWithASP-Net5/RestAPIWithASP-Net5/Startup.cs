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
        public IWebHostEnvironment Environment { get;  }

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

            services.AddDbContext<MySqlContext>(options => options.UseMySql(Configuration.GetConnectionString("MySqlConnectionString")));

            services.AddControllers();
            //INJE�AO DE DEPENDENCIA
            //CLASS BOOK
            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IBookBusiness, BookBusinessImplementation>();

            //CLASS PERSON
            services.AddScoped<IPersonBusiness, IPersonBusinessImplementation>();
            //PARA VERSIONAMENTO DA API
            services.AddApiVersioning();
            //DEFINIR O ARRANQUE COM O SWAGGER
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Api", Version = "v1" });
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
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
