using Application;
using Infrastructure;
using Infrastructure.Persistence;

namespace WebUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddApplicationServices();
            builder.Services.AddInfrastructureServices(builder.Configuration); 

            // Add services to the container.
            builder.Services.AddRazorPages();

            var app = builder.Build();

            Console.WriteLine("Environment: " + app.Environment.EnvironmentName);

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");

                using (var scope = app.Services.CreateScope())
                {
                    var initialiser = scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitialiser>();
                    initialiser.InitialiseAsync().Wait();
                    initialiser.SeedAsync().Wait();
                }
            }
            else
            { 
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}