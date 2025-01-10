using eCommerce.ProductsMicroService.API.Middleware;
using eCommerce.ProductsService.BusinessLogicLayer;
using eCommerce.ProductsService.DataAccessLayer;
using FluentValidation.AspNetCore;
using eCommerce.ProductsMicroService.API.APIEndpoints;
using System.Text.Json.Serialization;
using MySql.Data.MySqlClient;


var builder = WebApplication.CreateBuilder(args);

//Add DAL and BLL services
builder.Services.AddDataAccessLayer(builder.Configuration);
builder.Services.AddBusinessLogicLayer();

builder.Services.AddControllers();

//FluentValidations
builder.Services.AddFluentValidationAutoValidation();

//Add model binder to read values from JSON to enum
builder.Services.ConfigureHttpJsonOptions(options => {
    options.SerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

//Add Swagger Session
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Cors
builder.Services.AddCors(option =>{
   
});


var app = builder.Build();

app.UseExceptionHandlingMiddleware();
app.UseRouting();

//Cors
app.UseCors();

//Swaggar
app.UseSwagger();
app.UseSwaggerUI();

//Auth
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapProductAPIEndpoints();

app.Run();
