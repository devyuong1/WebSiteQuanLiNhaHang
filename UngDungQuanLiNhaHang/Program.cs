using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using UngDungQuanLiNhaHang.Data;
using UngDungQuanLiNhaHang.Repository;
using UngDungQuanLiNhaHang.Security;
using UngDungQuanLiNhaHang.Services.Implementations;
using UngDungQuanLiNhaHang.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<DataDbConText>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddAuthentication(
    options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(
        options =>
        {
            options.RequireHttpsMetadata = false;
            options.SaveToken = true; // luu tru token trong httpcontext de su dung sau nay
            options.TokenValidationParameters = new TokenValidationParameters {
                ValidateIssuer = true, // Xác thực nhà phát hành token.
                ValidateAudience = true, // Xác thực người nhận token
                ValidateLifetime = true, // Xác thực thời hạn hiệu lực của token 60 phuts
                ValidateIssuerSigningKey = true, //Xác thực khóa ký của nhà phát hành token.
                ValidIssuer = builder.Configuration["Jwt:Issuer"],
                ValidAudience = builder.Configuration["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"] ?? "ashsjabhdsjksdfjkdsfjsdjkfbsdjk123")), // Thiết lập khóa bí mật để xác thực token.
                RoleClaimType = ClaimTypes.Role
            };
        }
);



builder.Services.AddScoped<IAuthServices, AuthServices>();
builder.Services.AddScoped<IEmployeeServices, EmployeeService>();
builder.Services.AddScoped<IIngredientServices, IngredientService>();
builder.Services.AddScoped<CustomerRepo>();
builder.Services.AddScoped<TransactionRepo>();
builder.Services.AddScoped<EmployeeRepo>();
builder.Services.AddScoped<IngredientRepo>();
builder.Services.AddScoped<JWT>();
builder.Services.AddScoped<AddressRepo>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        policy =>
        {
            policy.AllowAnyOrigin()  // Cho phép mọi domain
                  .AllowAnyHeader()  // Cho phép mọi header
                  .AllowAnyMethod(); // Cho phép mọi phương thức GET, POST, PUT...
        });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}






app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
