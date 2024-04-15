using System.Text.Json;
using MinimalAPI;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<Product> products = new List<Product>(){

    new Product(){Id=1,Name="Phone"},
    new Product(){Id=1,Name="TV"},
};

var mapGroup = app.MapGroup("/products").ProductsAPI();


app.Run();
