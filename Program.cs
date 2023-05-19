namespace OpenAIAssessment
{
    using System.Net.Http.Headers;

    using OpenAIAssessment.Services;

    public static class Program
    {
        private static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services
                .AddControllersWithViews()
                .AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);

            builder.Services.AddHttpClient<IChatService, ChatService>(client =>
            {
                client.BaseAddress = new Uri(builder.Configuration["OpenAI:ChatBaseUrl"]);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", builder.Configuration["OpenAI:ServiceApiKey"]);
            });
            builder.Services.AddHttpClient<ITextEditService, TextEditService>(client =>
            {
                client.BaseAddress = new Uri(builder.Configuration["OpenAI:TextEditBaseUrl"]);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", builder.Configuration["OpenAI:ServiceApiKey"]);
            });
            builder.Services.AddHttpClient<IImageGenerationService, ImageGenerationService>(client =>
            {
                client.BaseAddress = new Uri(builder.Configuration["OpenAI:ImageGenerationBaseUrl"]);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", builder.Configuration["OpenAI:ServiceApiKey"]);
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");

                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
