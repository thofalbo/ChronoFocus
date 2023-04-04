var cultureInfo = new CultureInfo("pt-BR");
    cultureInfo.NumberFormat.NumberDecimalSeparator = ".";
    CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
    CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

var builder = WebApplication.CreateBuilder(args);

IConfiguration configurations = builder.Configuration;

// builder.Services.AddDbContext<BaseDbContext>(options =>
//     options.UseNpgsql(builder.Configuration.GetConnectionString("ConnectionString")));

var appSettings = configurations.Get<AppSettings>();

builder.Services.AddDependencies(appSettings);

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);
app.Run();
