using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssignmentDeltaXAPI.Models;
using AssignmentDeltaXAPI.UtilityMethods.AddMovieControllerMethods;
using AssignmentDeltaXAPI.UtilityMethods.GetActorMethods;
using AssignmentDeltaXAPI.Middlewares;
using Microsoft.AspNetCore.ResponseCompression;
using AssignmentDeltaXAPI.UtilityMethods.GetMovieDetails;

namespace AssignmentDeltaXAPI
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
            services.AddControllers().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AssignmentDeltaXAPI", Version = "v1" });
            });
            services.AddResponseCompression(options => options.Providers.Add<GzipCompressionProvider>());
            services.AddDbContext<AssignmentDeltaXContext>();
            services.AddSingleton<IAddMovieControllerUtilsMethod, AddMovieControllerUtilsMethod>();
            services.AddSingleton<IGetActors, GetActors>();
            services.AddTransient<CustomMiddleware>();
            //services.AddTransient<IGetMovies, NewGetMovies>();
            services.AddTransient<IGetMovies, GetMovies>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AssignmentDeltaXAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseMiddleware<CustomMiddleware>();

            app.UseResponseCompression();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
