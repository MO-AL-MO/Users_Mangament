using Microsoft.EntityFrameworkCore;
using Users_Mangament.Application.Interfaces.IService;
using Users_Mangament.Application.Interfaces.Repository.SupRepository;
using Users_Mangament.Application.ServiceImp;
using Users_Mangament.Infrastructure.Implematation.SupRepository;
using Users_Mangament.Infrastructure.Implematation;
using Users_Mangament.Application.Interfaces.Repository;
using Users_Mangament.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);
//  ﬂÊÌ‰ Ê≈÷«›… Œœ„… DbContext ·«” Œœ«„Â« ›Ì  ÿ»Ìﬁﬂ
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("No connection string was found"),
        b => b.MigrationsAssembly("Users_Mangament.Infrastructure")));
// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddTransient(typeof(IRepository<>), typeof(Repository<>));

builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IPermissionRepository, PermissionRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IRolePermissionRepository, RolePermissionRepository>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IPermissionService, PermissionService>();

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
