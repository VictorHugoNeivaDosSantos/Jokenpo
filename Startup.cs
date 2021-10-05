using AutoMapper;
using Jokenpo.Context;
using Jokenpo.Mapper;
using Jokenpo.Repositories;
using Jokenpo.Repositories.Interface;
using Jokenpo.Repositories.Interfaces;
using Jokenpo.Services;
using Jokenpo.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Jokenpo
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
            var mapConfig = new MapperConfiguration(mc => mc.AddProfile(new MapperDto()));
            services.AddSingleton(mapConfig.CreateMapper());
            services.AddTransient<IRepositoryPlayer, RepositoryPlayer>();
            services.AddTransient<IPlayerService, PlayerService>();
            services.AddTransient<IJokenpoContext, JokenpoContext>();
            services.AddTransient<IRepositoryMove, RepositoryMove>();
            services.AddTransient<IMoveService, MoveService>();
            services.AddTransient<IRepositoryMatch, RepositoryMatch>();
            services.AddTransient<IMatchService, MatchService>();
            services.AddSwaggerGen();

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
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"));

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
