/* ProblemAssignment1Rafia.cs
 * BP Measurement Webpage
 * Revision History: 01.10.23-10.10.23
 * Rafia Naumi
 * 10.09.23
 */
using Microsoft.EntityFrameworkCore;
using ProblemAssignment1Rafia.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// add our context as a service:
string? connStr = builder.Configuration.GetConnectionString("BPMeasurementsRNaumi6618Db");
builder.Services.AddDbContext<BPMeasurementsDbContext>(options => options.UseSqlServer(connStr));
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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
