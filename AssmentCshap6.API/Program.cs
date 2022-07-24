using AssmentCshap6.Data.EF;
using AssmentCshap6.Data.Entities;
using AssmentsCshap6.Application.Monhocs;
using AssmentsCshap6.Application.Nganhs;
using AssmentsCshap6.Application.SinhVienInMonHocs;
using AssmentsCshap6.Application.Users;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddCors(policy =>
{
    policy.AddPolicy("CorsPolicy", opt => opt
    .AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod()
    .WithExposedHeaders("X-Pagination"));
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
builder.Services.AddIdentity<Student, AppRole>().AddEntityFrameworkStores<AsmentCshap6Context>()
                                                .AddDefaultTokenProviders();
var jwtSettings = builder.Configuration.GetSection("JWTSettings");
builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings["validIssuer"],
        ValidAudience = jwtSettings["validAudience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["securityKey"]))
    };
});

builder.Services.AddScoped<IUsers, Users>();
builder.Services.AddScoped<IMonHocService, MonHocService>();
builder.Services.AddScoped<INganhService, NganhService>();
builder.Services.AddScoped<ISinhvienInMonHocService, SinhvienInMonHocService>();

builder.Services.AddDbContext<AsmentCshap6Context>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("AssConnect")));
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseRouting();
app.UseCors("CorsPolicy");
app.UseStaticFiles();
app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"StaticFiles")),
    RequestPath = new PathString("/StaticFiles")
});
app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();
app.UseEndpoints(endpoints =>
{
    app.MapControllers();
});

app.Run();
