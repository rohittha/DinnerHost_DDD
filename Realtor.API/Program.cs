using Microsoft.EntityFrameworkCore;
using Realtor.API;
using Realtor.API.Data;
using Realtor.Application;
using Realtor.Infrastructure;
//using Realtor.API.Middleware;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddApplication()
        .AddInfrastructure(builder.Configuration);
    builder.Services.AddPresentationServices();
}

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseMiddleware<ErrorHandlingMiddleware>(); // To use Error Handling custo middleware
app.UseExceptionHandler("/error");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
