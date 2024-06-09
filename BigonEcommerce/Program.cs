using BigonEcommerce.Data.DataAcces;
using Business;
using Data;
using Infrastructure.Services.Classes;
using Infrastructure.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblies(typeof(IBusinessService).Assembly);
}
);
//builder.Services.InstallDataServices(builder.Configuration);
DataServiceInjection.InstallDataServices(builder.Services, builder.Configuration);

builder.Services.Configure<EmailOptions>(cfg =>
{
    builder.Configuration.GetSection("emailAccount").Bind(cfg);
});
builder.Services.AddSingleton<IEmailService, EmailService>();
builder.Services.AddSingleton<IDateTimeService, DateTimeService>();
builder.Services.AddSingleton<IUserServices, UserServices>();
//builder.Services.AddSingleton<IFileService, FileService>();
builder.Services.AddRouting(x=>x.LowercaseUrls=true);
var app = builder.Build();

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
            name: "areas",
            pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
          );
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();
