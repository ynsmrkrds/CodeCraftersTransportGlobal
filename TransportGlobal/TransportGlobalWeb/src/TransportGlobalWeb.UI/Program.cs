using Microsoft.Extensions.Options;
using TransportGlobalWeb.UI.ApiClients;
using TransportGlobalWeb.UI.Helpers;
using TransportGlobalWeb.UI.Models.ConfigurationModels;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.Configure<ApiEnpointsConfigurationModel>(builder.Configuration.GetSection("ApiEndpoints"));
builder.Services.AddSingleton(serviceProvider => serviceProvider.GetRequiredService<IOptions<ApiEnpointsConfigurationModel>>().Value);
builder.Services.AddSingleton<UserContextClient>();

builder.Services.AddHttpContextAccessor();

var app = builder.Build();

CookieHelper.Initialize(app.Services.GetService<IHttpContextAccessor>()!);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}");

app.Run();
