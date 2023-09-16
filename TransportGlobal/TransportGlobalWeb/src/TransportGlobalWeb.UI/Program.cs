using Microsoft.Extensions.Options;
using TransportGlobalWeb.UI.ApiClients.TransportContextApiClients;
using TransportGlobalWeb.UI.ApiClients.TransporterContextApiClients;
using TransportGlobalWeb.UI.ApiClients.UserContextApiClients;
using TransportGlobalWeb.UI.Helpers;
using TransportGlobalWeb.UI.Models.ConfigurationModels;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.Configure<ApiEndpointsConfigurationModel>(builder.Configuration.GetSection("ApiEndpoints"));
builder.Services.AddSingleton(serviceProvider => serviceProvider.GetRequiredService<IOptions<ApiEndpointsConfigurationModel>>().Value);
builder.Services.AddSingleton<UserClient>();
builder.Services.AddSingleton<CompanyClient>();
builder.Services.AddSingleton<VehicleClient>();
builder.Services.AddSingleton<EmployeeClient>();
builder.Services.AddSingleton<TransportRequestClient>();
builder.Services.AddSingleton<TransportContractClient>();

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
    pattern: "{controller=TransportRequest}/{action=Index}");

app.Run();
