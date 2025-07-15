
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Options;
using CM.Core;
using CM.Core.Service;
using CM.Data;
using CM.Services;
using RVC.Web.Infrastructure.Extensions;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);
 

builder.Services.AddRazorPages();

builder.Services.ConfigureDbContext(builder.Configuration);
builder.Services.ConfigureIdentity();
builder.Services.ConfigureSession();
builder.Services.ConfigureRouting();
builder.Services.ConfigureApplicationCookie();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IFirmaServices, FirmaServices>();
builder.Services.AddTransient<IBelgelerServices, BelgelerService>();
builder.Services.AddTransient<IGaleriServices, GaleriServices>();
builder.Services.AddTransient<IIletiþimServices, IletiþimServices>();
builder.Services.AddTransient<IRakamServices, RakamServices>();
builder.Services.AddTransient<ISliderServices, SliderServices>();
builder.Services.AddTransient<IVisionService, VisionService>();
builder.Services.AddTransient<IMissionService, MissionService>();
builder.Services.AddTransient<IUrünServices, UrünKategoriServices>();
builder.Services.AddTransient<IPriceService, PriceService>();


builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

builder.Services.AddMvc()

   .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)

   .AddDataAnnotationsLocalization();


builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new[]
    {
                    new CultureInfo("en-US"),
                    new CultureInfo("tr-TR"),
                };

    options.DefaultRequestCulture = new RequestCulture(culture: "en-US", uiCulture: "en-US");

    options.SupportedCultures = supportedCultures;

    options.SupportedUICultures = supportedCultures;


    //options.RequestCultureProviders = new[]{ new QueryStringRequestCultureProvider
    //{
    //    QueryStringKey = "culture",
    //    UIQueryStringKey = "culture"
    //} };
});


builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy =>
        policy.RequireRole("Admin"));
});



var app = builder.Build();

app.UseStaticFiles();
app.UseSession();

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

var locOptions = app.Services.GetService<IOptions<RequestLocalizationOptions>>();
app.UseRequestLocalization(locOptions.Value);

app.UseRequestLocalization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapAreaControllerRoute(
        name: "Admin",
        areaName: "Admin",
        pattern: "Admin/{controller=Login}/{action=Index}/{id?}"
    );

    endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");

    endpoints.MapRazorPages();

    endpoints.MapControllers();
});

 

app.ConfigureAndCheckMigration();
app.ConfigureLocalization();
app.ConfigureDefaultAdminUser();
app.Run();