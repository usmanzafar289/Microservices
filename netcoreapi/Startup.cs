using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;

namespace Todo.Mvc.Ui
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

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAngularDevClient",
                  builder =>
                  {
                      builder
                      .WithOrigins("http://localhost:4200")
                      .AllowAnyHeader()
                      .AllowAnyMethod();
                  });
                options.AddPolicy("AllowAngularClient",
                  builder =>
                  {
                      builder
                      .WithOrigins("http://localhost")
                      .AllowAnyHeader()
                      .AllowAnyMethod();
                  });
            });
            // services.AddMvc();
            services.AddMvc(option => option.EnableEndpointRouting = false);
            services.AddDbContext<AppDBContext>(options => options.UseSqlite(Configuration.GetConnectionString("cs")));
            // Register the Swagger generator, defining one or more Swagger documents
            services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "Cloud Native App", Version = "v1" });
      });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
            app.UseCors("AllowAngularDevClient");
            app.UseCors("AllowAngularClient");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
          else
          {
            app.UseExceptionHandler("/Home/Error");
          }

      app.UseStaticFiles();

      // Enable middleware to serve generated Swagger as a JSON endpoint.
      app.UseSwagger();

      // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
      app.UseSwaggerUI(c =>
      {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Service and calculations");
      });


      app.UseMvc(routes =>
      {
        routes.MapRoute(
                  name: "default",
                  template: "{controller=Todo}/{action=Index}/{id?}");
      });
    }
  }
}
