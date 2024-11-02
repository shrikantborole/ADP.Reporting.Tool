using ADP.Reporting.Tool.DataServices;
using ADP.Reporting.Tool.DataServices.Interface;
using ADP.Reporting.Tool.Services;
using ADP.Reporting.Tool.Services.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configure application services and repositories
builder.Services.AddScoped<IAlphabetService, AlphabetService>();
builder.Services.AddScoped<IAlphabetRepository, AlphabetRepository>();
builder.Services.AddScoped<IClientInformationService, ClientInformationService>();
builder.Services.AddScoped<IClientInformationRepository, ClientInformationRepository>();
builder.Services.AddScoped<IReportTypeService, ReportTypeService>();
builder.Services.AddScoped<IReportTypeRepository, ReportTypeRepository>();
builder.Services.AddScoped<IRequestInformationService, RequestInformationService>();
builder.Services.AddScoped<IRequestInformationRepository, RequestInformationRepository>();
builder.Services.AddScoped<ISqlFileDataService, SqlFileDataService>();
builder.Services.AddScoped<ISqlFileDataRepository, SqlFileDataRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Privacy}/{id?}");

app.Run();
