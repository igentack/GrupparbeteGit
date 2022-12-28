using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Gitgruppen.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<GitgruppenContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("GitgruppenContext") ?? throw new InvalidOperationException("Connection string 'GitgruppenContext' not found.")));

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//this is a comment

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=ParkedVehicles}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
