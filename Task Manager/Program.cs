using Microsoft.EntityFrameworkCore;
using Task_Manager.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IJobInteraction, JobInteraction>(JobInteraction.GetSession);
builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<TaskManagerDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

app.UseStaticFiles();
app.UseSession();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.MapDefaultControllerRoute();

app.Run();
