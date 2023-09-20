using Microsoft.EntityFrameworkCore;
using TechnicalTest.Models.DBContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//builder.Services.AddDbContext<AppDBContext>(obj =>
//{
//    obj.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection"));
//});
var connectionString = "Server=localhost;Database=TechtestDB;Uid=root;Pwd=;";
var serverVersion = new MySqlServerVersion(new Version(10, 4, 6));

// Replace 'YourDbContext' with the name of your own DbContext derived class.
builder.Services.AddDbContext<AppDBContext>(
    dbContextOptions => dbContextOptions
        .UseMySql(connectionString, serverVersion)
        .LogTo(Console.WriteLine, LogLevel.Information)
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors()
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
