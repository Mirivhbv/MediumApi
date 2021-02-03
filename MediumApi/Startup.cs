using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using MediumApi.Data.Database;
using MediumApi.Data.Repository;
using MediumApi.Domain.Entities;
using MediumApi.Infrastructure.Validators;
using MediumApi.Models;
using MediumApi.Service.Command;
using Microsoft.EntityFrameworkCore;

namespace MediumApi
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
            services.AddDbContext<MediumContext>(opt => opt.UseInMemoryDatabase("mediumdb"));

            services.AddAutoMapper(typeof(Startup));

            services.AddControllers().AddFluentValidation();

            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddTransient<IRequestHandler<CreatePostCommand, Post>, CreatePostCommandHandler>();

            services.AddTransient<IValidator<CreatePostModel>, CreatePostModelValidator>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}