using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "Phase11_ASP", Version = "v1"});
            });
            
            services.AddDbContext<InvertedIndexContext>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("database")));
            HandleDependencies(services);
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

        private void HandleDependencies(IServiceCollection services)
        {
            services.AddTransient<ISearchEngine, SearchEngine>();
            services.AddTransient<IDataHandler, DataHandler>();
            services.AddTransient<IFileReader, FileReader>();
            services.AddTransient<IFilterHandler, FilterHandler>();
            services.AddTransient<IInvertedIndex, InvertedIndex>();
            services.AddTransient<IQueryCategorizer, QueryCategorizer>();
            services.AddTransient<IInvertedIndexContextWrapper, InvertedIndexContextWrapper>();
            services.AddTransient<ConjunctionFilter>();
            services.AddTransient<DisjunctionFilter>();
            services.AddTransient<Func<string, IFilter>>(serviceProvider => key =>  
            {  
                switch (key)  
                {  
                    case "disjunction":
                        return serviceProvider.GetService<DisjunctionFilter>();  
                    case "conjunction":  
                        return serviceProvider.GetService<ConjunctionFilter>();
                    default: 
                        throw new KeyNotFoundException();
                }  
            });
        }
    }
}