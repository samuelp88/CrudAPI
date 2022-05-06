using CrudAPI.Business;
using CrudAPI.Business.Abstract;
using CrudAPI.Data;
using CrudAPI.Data.VO;
using CrudAPI.Models;
using CrudAPI.Services;
using CrudAPI.Services.Abstract;
using CrudAPI.Settings;
using CrudAPI.Settings.Abstract;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});
    
builder.Services.AddControllers();

ISettings settings = new Settings();
builder.Services.AddSingleton(settings);
builder.Services.AddScoped<IUserBusiness, UserBusiness>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IParser<User, UserVO>, UserParser>();
builder.Services.AddScoped<IInputValidator, InputValidator>();

//Auth
var key = Encoding.ASCII.GetBytes(settings.GetSecret());
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(x =>
    {
        x.RequireHttpsMetadata = false;
        x.SaveToken = true;
        x.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false,
        };
    });


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(option =>
{
    option.AllowAnyOrigin();
    option.AllowAnyHeader();
});
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
