using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TokenBaseAuth.Model;
using TokenBaseAuth.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ITokenService>(new TokenService());

//builder.Services.AddAuthentication("Bearer").AddJwtBearer(options =>
//{
//    options.TokenValidationParameters = new()
//    {
//        ValidateIssuer = true,
//        ValidateAudience = true,
//        ValidateIssuerSigningKey = true,
//        ValidAudience = builder.Configuration["Authentication:audience"],
//        ValidIssuer = builder.Configuration["Authentication:issuer"],
//        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["Authentication:securityKey"]))
//    };
//});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapPost("/validate", [AllowAnonymous] (UserValidationRequestModel request, HttpContext http, ITokenService tokenService) =>
{
    if (request is UserValidationRequestModel { UserName: "Krutibas", Password: "123456" })
    {
        var token = tokenService.BuidToken(builder.Configuration["Authentication:Key"],
                                           builder.Configuration["Authentication:issuer"],

                                           new[]
                                           {
                                               builder.Configuration["Authentication:Aud1"],
                                               builder.Configuration["Authentication:Aud2"]
                                           },
                                           request.UserName);
        return new
        {
            Token = token,
            IsAuthenticated = true,
        };


    }
    return new
    {
        Token = string.Empty,
        IsAuthenticated = false
    };


})
.WithName("validate");


app.UseHttpsRedirection();
app.UseAuthentication();    
app.UseAuthorization();

app.MapControllers();

app.Run();
