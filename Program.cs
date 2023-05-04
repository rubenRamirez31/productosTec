using EjercicioEFC.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<BdpersonasContext>(
    opciones =>
    opciones.UseMySQL("Server=database-2.cieq3dfbzdfd.us-east-2.rds.amazonaws.com; Port=3306; Database=BDPersonas; Uid=admin; Pwd=BT8OuIqJh6BF4Z8AsquH")
);

builder.Services.AddDbContext<ConstruccionesContext>(
    opciones =>
    opciones.UseMySQL("Server=database-2.cieq3dfbzdfd.us-east-2.rds.amazonaws.com; Port=3306; Database=BDPersonas; Uid=admin; Pwd=BT8OuIqJh6BF4Z8AsquH")
);
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
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
