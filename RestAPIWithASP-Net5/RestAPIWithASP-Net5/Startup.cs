using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RestAPIWithASP_Net5.Model.DataContext;
using Microsoft.EntityFrameworkCore;
using RestAPIWithASP_Net5.Repository;
using RestAPIWithASP_Net5.Repository.Implementations;
using RestAPIWithASP_Net5.Business.Implementations;
using Serilog;
using RestAPIWithASP_Net5.person.Business;
using RestAPIWithASP_Net5.book.Business;

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
            //INJEÇAO DE DEPENDENCIA
            //CLASS BOOK
            services.AddScoped<IBookRepository, BookRepositoryImplementation>();
            services.AddScoped<IBookBusiness, BookBusinessImplementation>();

            //CLASS PERSON
            services.AddScoped<IPersonBusiness, IPersonBusinessImplementation>();
            services.AddScoped<IPersonRepository, PersonRepositoryImplementation>();
            //PARA VERSIONAMENTO DA API
            services.AddApiVersioning();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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
