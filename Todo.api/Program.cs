

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;
using Scalar.AspNetCore;
using System.Text;
using Todo.api;
using Todo.api.Scalar;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// next code is  to enable Swager Authorize lock button

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Todo API",
        Version = "v1"
    });

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Enter JWT token. Example: Bearer eyJhbGciOiJIUzI1NiIs...",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    //options.AddSecurityRequirement(new OpenApiSecurityRequirement
    //{
    //    {
    //        new OpenApiSecurityScheme
    //        {
    //            Reference = new OpenApiReference
    //            {
    //                Type = ReferenceType.SecurityScheme,
    //                Id = "Bearer"
    //            }
    //        },
    //        Array.Empty<string>()
    //    }
    //});
});

// end of Swagger lock authorize button

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(builder.Configuration.GetSection("Jwt:Secret").Value)),
                        ValidIssuer = builder.Configuration.GetSection("Jwt:Issuer").Value,
                        ValidAudience = builder.Configuration.GetSection("Jwt:Audience").Value,
                        ValidateAudience = true,
                        ValidateIssuer = true,
                        ValidateIssuerSigningKey = true,
                        ClockSkew = TimeSpan.Zero

                    };

                    options.IncludeErrorDetails = true;

                });

//    options.Events = new JwtBearerEvents
//    {
//        OnTokenValidated = async context =>
//        {
//            var sidClaim = context.Principal?.FindFirst("sid");
//            if (sidClaim == null || !Guid.TryParse(sidClaim.Value, out var sessionId))
//            {
//                context.Fail("Invalid token: missing session reference");
//                return;
//            }

//            //var revocationService = context.HttpContext.RequestServices
//            //    .GetRequiredService<ITokenRevocationService>();

//            //bool isRevoked = await revocationService.IsSessionRevokedAsync(sessionId);

//            //if (isRevoked)
//            //{
//            //    context.Fail("Session has been revoked");
//            //}
//        }

//    };

//  });




builder.Services.AddInfrastructureLayerDependency(builder.Configuration);
builder.Services.AddApplicationLayerDependency();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();

// 1. Register OpenAPI with the Bearer transformer.  This a utulity to help testing secured api. Should be removed from production code
builder.Services.AddOpenApi(options =>
{
    options.AddDocumentTransformer<BearerSecuritySchemeTransformer>();
});

//builder.Services.AddSwaggerGen();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
   

    // 2. Expose the JSON spec and Scalar UI
    app.MapOpenApi();
    app.MapScalarApiReference(options =>
    {
        options.WithTitle("Todo API")
               .WithTheme(ScalarTheme.Purple)
               .EnablePersistentAuthentication(); // Keeps your JWT token saved on page refresh
    });

//    app.UseSwagger();
//    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
