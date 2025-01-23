using System.Net.Http.Headers;
using test.Test.Services.Interfaces;
using test.Test.Services.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient("ProductBoard" ,pbClient =>
{
    //NEED TO PLACE BASE URL TO A CONFIG OR SMWHT SIMILAR ANA
    pbClient.BaseAddress = new Uri("https://api.productboard.com/");
    pbClient.DefaultRequestHeaders.Add("Accept", "application/json");
    pbClient.DefaultRequestHeaders.Authorization =
        new AuthenticationHeaderValue("Bearer", "SHEKRET");
});

builder.Services.AddScoped<IProductBoardService, ProductBoardService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(options => options.AllowAnyOrigin());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
