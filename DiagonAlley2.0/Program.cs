using Data;
using DiagonAlley2._0.Components;
using DiagonAlley2._0.Data;
using DiagonAlley2._0.Services;
using Services;

namespace DiagonAlley2._0
{
    public class Program
    {
        public static async Task Main(string[] args)

        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddSingleton<MongoDbService>();
            builder.Services.AddScoped<LoginService>();
            builder.Services.AddScoped<CartService>();
            builder.Services.AddScoped<ProductService>();
            builder.Services.AddScoped<StorageService>();


            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                using var scope = app.Services.CreateScope();
                var mongo = scope.ServiceProvider.GetRequiredService<MongoDbService>();
                await ProductSeeder.SeedAsync(mongo);
                await WizardSeeder.SeedAsync(mongo);
            }

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }



            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}
