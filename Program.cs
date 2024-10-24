using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using EmployeeM.Data;

var builder = WebApplication.CreateBuilder(args);

// Configure DbContext for Identity
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("EmployeeM")));

// Identity configuration with roles and IdentityUser
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>() // UseEmployeeMIdentityDbContext for Identity
    .AddDefaultTokenProviders();

builder.Services.AddScoped<DepartmentRepository>();
builder.Services.AddScoped<DepartmentUserRepository>();


builder.Services.Configure<IdentityOptions>(options =>
{
    // Disable email confirmation requirement
    options.SignIn.RequireConfirmedAccount = false; 
});

// Add Razor Pages services (required for ASP.NET Identity)
builder.Services.AddRazorPages();  // <-- This adds Razor Pages services


// Add controllers with views
builder.Services.AddControllersWithViews();

// Add Razor Pages (required for Identity)
builder.Services.AddRazorPages(); 

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

// Ensure Authentication comes before Authorization
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
