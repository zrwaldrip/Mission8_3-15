using Microsoft.EntityFrameworkCore;
using Mission8_3_15.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// 1. Register the SQLite Database Context
// This tells EF Core to look for your Tasks.sqlite file
builder.Services.AddDbContext<TaskContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection") ?? "Data Source=Tasks.sqlite");
});

// 2. Register the Repository Pattern
// This fixes your exact InvalidOperationException!
builder.Services.AddScoped<ITaskRepository, EFTaskRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();