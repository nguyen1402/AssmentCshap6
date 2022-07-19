using AssmentCshap6.Data.EF;
using AssmentCshap6.Data.Entities;
using AssmentsCshap6.Application.nganh;
using AssmentsCshap6.Application.Nganh;
using AssmentsCshap6.Application.Schools;
using AssmentsCshap6.Application.Users;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddCors(option =>
{
    option.AddPolicy("CorsPolicy", buidel => buidel.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
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

//builder.Services.AddRouting(options => options.LowercaseUrls = true);
//builder.Services.AddScoped<UserManager<Student>, UserManager<Student>>();
//builder.Services.AddScoped<SignInManager<Student>, SignInManager<Student>>();
//builder.Services.AddScoped<RoleManager<AppRole>, RoleManager<AppRole>>();
builder.Services.AddScoped<IUsers, Users>();
builder.Services.AddScoped<Ischool, school>();
builder.Services.AddScoped<INganh, nganh>();
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
app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();
app.UseEndpoints(endpoints =>
{
    app.MapControllers();
});

app.Run();
