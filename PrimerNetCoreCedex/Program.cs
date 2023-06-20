using Microsoft.EntityFrameworkCore;
using PrimerNetCoreCedex.Data;
using PrimerNetCoreCedex.Helpers;
using PrimerNetCoreCedex.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
});

builder.Services.AddTransient<HelperMails>();
builder.Services.AddTransient<HelperPathProvider>();
//RECUPERAMOS LA CADENA DE CONEXION DE APPSETTINGS
string connectionString =
    builder.Configuration.GetConnectionString("SqlServer");
//RESOLVEMOS LAS DEPENDENCIAS
builder.Services.AddTransient<RepositoryEmpleados>();
builder.Services.AddDbContext<EmpleadosContext>
    (options => options.UseSqlServer(connectionString));
builder.Services.AddControllersWithViews();

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
//EL ORDEN DE MIDDLEWARE ES IMPORTANTE!!!
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
