using EntityFrameworkCoreMock;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using TheProduct.Data;

namespace TheProduct.Tests
{
    public class TestStartup
    {
        private DbContextMock<ProductContext> DbContextMock;

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));
            services.AddMediatR(typeof(Startup));

            services.AddHttpContextAccessor().AddHttpClient();
            services.AddMvc().AddApplicationPart(typeof(Startup).Assembly);

            this.DbContextMock = new DbContextMock<ProductContext>();
            services.AddSingleton(DbContextMock);
            services.AddSingleton(DbContextMock.Object);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
