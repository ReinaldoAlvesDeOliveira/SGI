using Infra.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
var urlApi = builder.Configuration["SGI_Web"];
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "CORS",
                      builder =>
                      {
                          builder.WithOrigins(urlApi)
                          .AllowAnyOrigin()
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                      });
});

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

var secret = builder.Configuration.GetValue<string>("Service:Secret");
var key = Encoding.ASCII.GetBytes(secret);
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddSwaggerGen(c =>
//{
//    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
//    {
//        Description = "Insira o token JWT desta maneira: Bearer {seu token}",
//        Name = "Authorization",
//        Scheme = "Bearer",
//        BearerFormat = "JWT",
//        In = ParameterLocation.Header,
//        Type = SecuritySchemeType.ApiKey
//    });

//    c.AddSecurityRequirement(new OpenApiSecurityRequirement
//                {
//                    {
//                        new OpenApiSecurityScheme
//                        {
//                            Reference = new OpenApiReference
//                            {
//                                Type = ReferenceType.SecurityScheme,
//                                Id = "Bearer"
//                            }
//                        },
//                        new string[] {}
//                    }
//                });

//    c.SwaggerDoc("v1", new OpenApiInfo { Title = "API SGI", Version = "v1", Description = $"Url de autenticação: {builder.Configuration["Services:Authority"]}" });

//    // Set the comments path for the Swagger JSON and UI.
//    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
//    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
//    c.IncludeXmlComments(xmlPath);
//});

var connectionString = builder.Configuration["ConnectionStrings:SGIBase"];
builder.Services.AddDbContext<SGIContext>(options =>
{
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

builder.Services.AddAuthorization(x =>
{
    x.AddPolicy("Administrador", policy => policy.RequireAuthenticatedUser()
    .RequireAssertion(ctx =>
        ctx.User.HasClaim(x => x.Type == "Administrador")
    ));

    x.AddPolicy("Supervisor", policy => policy.RequireAuthenticatedUser()
    .RequireAssertion(ctx =>
        ctx.User.HasClaim(x => x.Type == "Supervisor")
    ));

    x.AddPolicy("Dirigente", policy => policy.RequireAuthenticatedUser()
    .RequireAssertion(ctx =>
    ctx.User.HasClaim(x => x.Type == "Dirigente")
    ));

    x.AddPolicy("Membro", policy => policy.RequireAuthenticatedUser()
    .RequireAssertion(ctx =>
        ctx.User.HasClaim(x => x.Type == "Membro")
    ));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI(x =>
{
    x.SwaggerEndpoint("/swagger/v1/swagger.json", "API SGI");
    x.RoutePrefix = string.Empty;
    x.DocumentTitle = $"API - SGI";
    x.DefaultModelsExpandDepth(-1);
    x.DocExpansion(DocExpansion.None);
    x.ConfigObject.AdditionalItems.Add("syntaxHighlight", false);
});

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseCors("CORS");
app.UseHttpsRedirection();

app.UseRouting();

app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseAuthentication();
app.UseAuthorization();


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
