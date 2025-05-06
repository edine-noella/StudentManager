using Microsoft.EntityFrameworkCore;
using StudentManager.Data;
using StudentManager.Middlewares;
using StudentManager.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddTransient<ITimeService, TimeService>();//a new instance is going to be created everythime it's requested


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

//my custom middleware
app.UseMiddleware<RequestTimeLoggerMiddleware>();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
    .WithStaticAssets();

app.Run();