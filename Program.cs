using Microsoft.EntityFrameworkCore;
using animomentapi.Data;
using animomentapi.Repository;
using animomentapi.Interface;
using Microsoft.AspNetCore.Identity;
//using Microsoft.EntityFrameworkCore;
using animomentapi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});

builder.Services.AddDbContext<ApplicationDBContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// builder.Services.AddIdentity<AppUser, IdentityRole>(options => {
//     options.Password.RequireDigit = true;
//     options.Password.RequireLowercase = true;
//     options.Password.RequireUppercase = true;
//     options.Password.RequireNonAlphanumeric = true; 
//     options.Password.RequiredLength = 12;
// })
// .AddEntityFrameworkStores<ApplicationDBContext>();

// builder.Services.AddAuthentication(options => {
//     options.DefaultAuthenticateScheme = 
//     options.DefaultChallengeScheme = 
//     options.DefaultForbidScheme = 
//     options.DefaultScheme = 
//     options.DefaultSignInScheme =
//     options.DefaultSignOutScheme = JwtBearerDefaults.AuthenticationScheme;
// }).AddJwtBearer(options => {
//     options.TokenValidationParameters = new TokenValidationParameters{
//         ValidateIssuer = true,
//         ValidIssuer = builder.Configuration["JWT:Issuer"],
//         ValidateAudience = true,
//         ValidAudience = builder.Configuration["JWT:Audience"],
//         ValidateIssuerSigningKey = true,
//         IssuerSigningKey = new SymmetricSecurityKey(
//             System.Text.Encoding.UTF8.GetBytes(builder.Configuration["JWT:SigningKey"])
//         )
//     };
// });

// ✅ Add CORS Policy to allow multiple origins (local + live)
// builder.Services.AddCors(options =>
// {
//     options.AddPolicy("AllowFrontend", policy =>
//         policy.WithOrigins(
//             "http://localhost:4200",
//             "https://wetechguys.com"
//         )
//         .AllowAnyHeader()
//         .AllowAnyMethod());
// });

//builder.Services.AddScoped<IProductRepository, ProductRepository>();
//builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IProductCategoriesRepository, ProductCategoriesRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICartItemRepository, CartItemRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// for local
app.UseCors(Options =>
Options.WithOrigins("http://localhost:4200")
.AllowAnyMethod()
.AllowAnyHeader()
);

// for live
// app.UseCors(Options =>
// Options.WithOrigins("https://wetechguys.com")
// .AllowAnyMethod()
// .AllowAnyHeader()
// );


// builder.Services.AddCors(options =>
// {
//     options.AddPolicy("AllowMyFrontend",
//         policy => policy.WithOrigins("https://wetechguys.com")
//                         .AllowAnyHeader()
//                         .AllowAnyMethod());
// });

//app.UseCors("AllowFrontend");

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
