using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;
using PortalNews.Api.Exceptions;
using PortalNews.Api.Services;
using PortalNews.Api.Test.Implementation;
using PortalNews.Api.Test.Rules;
using PortalNews.Application.DTO.Mapping;
using PortalNews.Application.Services.Implementations;
using PortalNews.Application.Services.Interfaces;
using PortalNews.Infratructure.Persistences.Implementations;
using PortalNews.Infratructure.Persistences.Interfaces;
using System.Text;

DotNetEnv.Env.Load();

var builder = WebApplication.CreateBuilder(args);
var jwtKey = builder.Configuration["JWT_KEY"];


var client = new MongoClient(builder.Configuration["Mongo:Path"]);
builder.Services.AddSingleton<IMongoClient>(client);


builder.Services.AddControllers().AddFluentValidation(configuration => {
    configuration.RegisterValidatorsFromAssembly(typeof(Program).Assembly);
});

// Add services to the container.

var key = Encoding.ASCII.GetBytes(jwtKey);

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

builder.Services.AddTransient<GlobalExceptionHandlerMiddleware>();


builder.Services.AddScoped<IRuleException, ExceptionCheckerResourceNotFound>();
builder.Services.AddScoped<IRuleException, ExceptionCheckerFormatStringMongo>();
builder.Services.AddScoped<IRuleException, ExceptionCheckerSmptFailedSendEmail>();

builder.Services.AddScoped<CheckerException>();



builder.Services.AddSingleton(typeof(INewsRepository), typeof(NewsRepository));
builder.Services.AddSingleton(typeof(IUserRepository), typeof(UserRepository));
builder.Services.AddSingleton(typeof(IRoleRepository), typeof(RoleRepository));
builder.Services.AddScoped<INewsService , NewsService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IUserService, UserService>();


builder.Services.AddTransient<TokenService>();
builder.Services.AddTransient<EmailService>();



builder.Services.AddAutoMapper(typeof(EntityToDTOMapping), typeof(DtoToEntityMapping) , typeof(DtoToDtoMapping));



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

app.UseMiddleware<GlobalExceptionHandlerMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
