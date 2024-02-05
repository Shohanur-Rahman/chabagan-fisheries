using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Chabagan.Chabagan.Fisheries.DB;
using Chabagan.Fisheries.Data.Utilities;
using Chabagan.Fisheries.SPMecanism;
using Chabagan.Fisheries.WebApi.Utilities;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Cors;
using System.Net;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(options => { options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles; });
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddRouting(options => options.LowercaseUrls = true);

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Fisheries.WebApi", Version = "v1" });

    // Define security scheme (e.g., JWT Bearer)
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer"
    });
    // Define security requirement (e.g., require "Bearer" scope)
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
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
            new List<string>()
        }
    });
});


//JWT Setup
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT"]))
    };
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddDbContext<FisheriesDbContext>(options => options.UseSqlServer(
                     builder.Configuration.GetConnectionString("FisherConnection")
                  ));

builder.Services.AddStoredProcedure().AddRepositories().AddWebServices();

// CORS Setup
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder => builder.SetIsOriginAllowed(_ => true)
          .AllowAnyMethod()
          .AllowAnyHeader()
          .AllowCredentials()
    .Build());
});
EnableCorsAttribute cors = new EnableCorsAttribute();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.Use(async (context, next) =>
{
    await next();

    if (context.Response.StatusCode == (int)HttpStatusCode.Unauthorized)
    {
        context.Response.ContentType = "application/json";
        await context.Response.WriteAsync("Unauthorized! Please signin and then try again.");
    }
    else if (context.Response.StatusCode == (int)HttpStatusCode.Forbidden)
    {
        context.Response.ContentType = "application/json";
        await context.Response.WriteAsync("Access Denied! Request Access Denied.");
    }
});
app.UseCors("CorsPolicy");
app.UseStaticFiles();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
