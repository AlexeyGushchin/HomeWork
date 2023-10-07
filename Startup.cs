using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;

namespace HomeWork
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseStatusCodePages();

            app.MapWhen(context => 
            {
                return context.Request.Path.ToString().Trim('/').StartsWith("test");
            }
            ,HandlePath);
        }

        private static void HandlePath(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync(RegexpHelper.GetFirstMatch(context.Request.Path.ToString()));
            });
        }
    }
}
