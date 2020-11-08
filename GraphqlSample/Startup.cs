using System;
using Graphql.Data;
using Graphql.Data.Repositories;
using Graphql.Data.Repositories.Interfaces;
using GraphqlSample.Identity;
using GraphqlSample.Models;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GraphqlSample
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<NHRContext>(options => options.UseSqlServer(_configuration["ConnectionStrings:NHRStatsDb"]));
            
            services.AddSingleton<CustomerType>();
            services.AddSingleton<ProductType>();
            services.AddSingleton<CategoryType>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
            services.AddSingleton<NHRQuery>();
            var sp = services.BuildServiceProvider();
            services.AddSingleton<ISchema>(new NRHSchema(new FuncDependencyResolver(type => sp.GetService(type))));
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();
            app.UseMvc();
            
        }
    }
}
