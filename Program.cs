//References//
//https://learn.microsoft.com/en-us/ef/core/dbcontext-configuration/
//http://sololearn.com/en/Discuss/2552390/how-to-link-c-with-html
//https://learn.microsoft.com/en-us/ef/core/



using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Agri_Energy_Connect.Data;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddSession();


builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));


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
app.UseSession();


app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
