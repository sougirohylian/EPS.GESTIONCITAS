using EPS.GESTIONCITAS.CITASDataAccess.Model;
using EPS.GESTIONCITAS.CITASDataAccess.Repositories;
using EPS.GESTIONCITAS.CITASLogic.Services;
using EPS.GESTIONCITAS.CITASLogic.Settings;
using EPS.GESTIONCITAS.CITASWebApi.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.Data.Entity;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
// Aquí se agrega el acceso al archivo appsettings.json (se hace por defecto)
builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddHttpClient<IConsumerService>();
builder.Services.AddScoped<IGlobalSettings, GlobalSettings>();
builder.Services.AddScoped<IConsumerService, ConsumerService>();
builder.Services.AddScoped<ICitasServices, CitasServices>();
builder.Services.AddScoped<ICitasRepository, CitasRepository>();
builder.Services.AddScoped<EntitiesCitas>();
builder.Services.AddScoped<IAuthService, AuthService>();
// Configura el inicializador de la base de datos
Database.SetInitializer(new DropCreateDatabaseIfModelChanges<EntitiesCitas>());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//***** Configuracion de servicios para JWT *****
//autorizacion
builder.Services.AddAuthorization(options =>
    options.DefaultPolicy =
    new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme).RequireAuthenticatedUser().Build()
);
//estos valores los obtenemos de nuestro appsettings
var issuer = builder.Configuration["AuthenticationSettings:Issuer"];
var audience = builder.Configuration["AuthenticationSettings:Audience"];
var signinKey = builder.Configuration["AuthenticationSettings:SigningKey"];
//autenticacion
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.Audience = audience;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidIssuer = issuer,
        ValidateIssuerSigningKey = true,
        ValidateLifetime = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(signinKey))
    };
}
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthentication();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
