using AutoMapper;
using BarberBoss____Barber_Shop.Services.Mapping;
using BarberBoss____Barber_Shop.Services.Messaging;
using BarberBoss___Barber_Shop.Data;
using BarberBoss___Barber_Shop.Data.Common;
using BarberBoss___Barber_Shop.Data.Common.Repositories;
using BarberBoss___Barber_Shop.Data.Models;
using BarberBoss___Barber_Shop.Data.Repositories;
using BarberBoss___Barber_Shop.Services.Data.Appointments;
using BarberBoss___Barber_Shop.Services.Data.BarberShops;
using BarberBoss___Barber_Shop.Services.Data.BarberShopsServices;
using BarberBoss___Barber_Shop.Services.DateTimeParser;
using BarberBoss___Barber_Shop.Web.ViewModels;
using BeautyBooking.Services.Messaging;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<MyApplicationUser>(IdentityOptionsProvider.GetIdentityOptions)
                .AddRoles<ApplicationRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddControllersWithViews();
//AutoMapper Configuration
AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).GetTypeInfo().Assembly);

// Data repositories
builder.Services.AddScoped(typeof(IDeletableEntityRepository<>), typeof(EfDeletableEntityRepository<>));
builder.Services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
builder.Services.AddScoped<IDbQueryRunner, DbQueryRunner>();

// Application services
builder.Services.AddTransient<IEmailSender, NullMessageSender>();
builder.Services.AddTransient<IBarberShopsService, BarberBoss___Barber_Shop.Services.Data.BarberShops.BarberShopsService>();
builder.Services.AddTransient<IBarberShopsServicesService, BarberShopsServicesService>();
builder.Services.AddTransient<IAppointmentsService, AppointmentsService>();
builder.Services.AddTransient<IDateTimeParserService, DateTimeParserService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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
app.MapRazorPages();

app.Run();
