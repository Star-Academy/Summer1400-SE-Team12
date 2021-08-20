using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Phase11_ASP.Implementations;
using Phase11_ASP.Interfaces;
using Phase11_ASP.SQLHandler;


namespace Phase11_ASP
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "Phase11_ASP", Version = "v1"});
            });
            
            services.AddDbContext<InvertedIndexContext>(options => 
                options.UseSqlServer("Server=.;Database=InvertedIndexPhase11;Trusted_Connection=True; MultipleActiveResultSets=true;"));
            
            services.AddSingleton<ISearchEngine, SearchEngine>();
            services.AddSingleton<IDataHandler, DataHandler>();
            services.AddSingleton<IFileReader, FileReader>();
            services.AddSingleton<IFilterHandler, FilterHandler>();
            services.AddSingleton<IInvertedIndex, InvertedIndex>();
            services.AddSingleton<IQueryCategorizer, QueryCategorizer>();
            services.AddSingleton<IInvertedIndexContext, InvertedIndexContext>();
            services.AddSingleton<IInvertedIndexContextWrapper, InvertedIndexContextWrapper>();
            services.AddTransient<IFilter, ConjunctionFilter>();
            // services.AddTransient<IFilter, DisjunctionFilter>();
            // services.AddTransient<IFilter.ServiceResolver>(serviceProvider => key =>
            // {
            //     switch (key)
            //     {
            //         case "conjunction":
            //             return serviceProvider.GetService<ConjunctionFilter>();
            //         case "disjunction":
            //             return serviceProvider.GetService<DisjunctionFilter>();
            //         default:
            //             throw new KeyNotFoundException(); // or maybe return null, up to you
            //     }
            // });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Phase11_ASP v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}