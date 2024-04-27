using Microsoft.EntityFrameworkCore;
using Task_Manager.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IJobInteraction, JobInteraction>();

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<TaskManagerDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
var app = builder.Build();
app.UseStaticFiles();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.MapDefaultControllerRoute();

app.Run();
