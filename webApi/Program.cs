using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using user.Infrastructure.Persistence;
using webApi.Domain.Entities;
using webApi.Domain.Repositories;
using webApi.Domain.Interfaces;
using webApi.Domain.Validators;
using webApi.Presentation.Services;
using webApi.Presentation.Services.Interfaces;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using webApi.Application.Interfaces;
using webApi.Application.UseCases;

// Criamos a instância inicial da aplicação.
var builder = WebApplication.CreateBuilder(args);

var allowedOrigins = builder.Configuration.GetSection("AllowedOrigins").Get<string[]>();

builder.Services.AddCors(options => 
{
    options.AddPolicy("myCors", policy => 
    {
        policy.WithOrigins(allowedOrigins).AllowAnyHeader().AllowAnyMethod();
    });
});

// Configura a aplicação para oferecer informações sobre a API.
builder.Services.AddEndpointsApiExplorer();

// Configura o Swagger e sua documentação.
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo()
    {
        Version = "v1.0",
        Title = "test_webApi",
        Description = "Web API"
    });

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Cabeçalho de Autorização JWT utiliza o esquema de Bearer \r\n\r\n Digite 'Bearer' antes de colocar o token"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

// Adiciona suporte a controladores para lidar com HTTP.
builder.Services.AddControllers();

// Adiciona suporte a FluentValidation para lidar com validações de entidades.
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();

// Configura os validadores
builder.Services.AddTransient<IValidator<User>, UserValidator>();
builder.Services.AddTransient<IValidator<Movie>, MovieValidator>();

// Adiciona a configuração e o suporte ao banco de dados pelo EntityFramework, nesse caso o postgres.
builder.Services.AddDbContext<DBContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("Default"));
});

// Configura a aplicação para utilizar interfaces injetando em outros componentes.
builder.Services.AddScoped<IUserQueryRepository, UserRepository>();
builder.Services.AddScoped<IUserPersistenceRepository, UserRepository>();

builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IUserUseCases, UserUseCases>();
builder.Services.AddScoped<ILoginUseCase, LoginUseCase>();
builder.Services.AddScoped<IMovieUseCase, MovieUseCase>();

builder.Services.AddScoped<IMovieQueryRepository, MovieRepository>();
builder.Services.AddScoped<IMoviePersistenceRepository, MovieRepository>();

builder.Services.AddScoped<IUserMovieQueryRepository, UserMovieRepository>();
builder.Services.AddScoped<IUserMoviePersistenceRepository, UserMovieRepository>();
builder.Services.AddScoped<IUserMovieUseCases, UserMovieUseCases>();

// Configura a aplicação para suporte a autenticação no caso JWT.
builder.Services.AddAuthentication(x =>
    {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"] ?? string.Empty)),
        };
    });

// Chamada para contruir a aplicação com base nas configurações.
var app = builder.Build();

// Verifica se a aplicação está rodando no ambiente de desenvolvimento e se estiver configura o Swagger.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// Adiciona o middleware de redirecionamento HTTPS para mais segurança.
app.UseHttpsRedirection();

app.UseCors("myCors");

// Adiciona o middleware de autenticação à pipeline de solicitação da aplicação.
app.UseAuthentication();

// Garante que a autorização seja aplicada a todas as solicitações autenticadas recebidas pela aplicação.
app.UseAuthorization();

// Adiciona roteamento para os controladores.
app.MapControllers();

// Finalizar a definição da pipeline de solicitação e iniciar o processamento de solicitações HTTP.
app.Run();
