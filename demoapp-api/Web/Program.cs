using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Data.Extensions;
using Data.Context;
using Microsoft.AspNetCore.Identity;
using Entity.Entities;
using Microsoft.AspNetCore.Authorization;
using Service.Extensions;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDistributedMemoryCache(); // veya uygun bir dağıtılmış önbellek sağlayıcısı ekleyin
builder.Services.AddSession(options =>
{
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddMemoryCache();
builder.Services.LoadServiceLayerExtension();
builder.Services.LoadDataLayerExtension(builder.Configuration);
builder.Services.AddCors(options =>
    {
        options.AddPolicy("CorsPolicy",
            builder => builder
                .WithOrigins("http://localhost:3000")
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());
    });

builder.Services.AddIdentity<User, Role>(opt =>
    {
        opt.Password.RequireNonAlphanumeric = false;
        opt.Password.RequireLowercase = false;
        opt.Password.RequireUppercase = false;
    })
    .AddRoleManager<RoleManager<Role>>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseCors("CorsPolicy");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
