using System.Text.Json;
using MinimalAPI;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<Product> products = new List<Product>(){

    new Product(){Id=1,Name="Phone"},
    new Product(){Id=1,Name="TV"},
};

app.MapGet("/products",async (HttpContext context) => {

string content = string.Join("\n",products.Select(s=>s.ToString()));
await context.Response.WriteAsync(content);

});

app.MapGet("/products/{id:int}",async (HttpContext context,int id) => {

Product? product = products.Where(w=>w.Id == id).FirstOrDefault();
if(product==null)
{
    context.Response.StatusCode = 400;
    await context.Response.WriteAsync("Incorrect Product Id");
    return;
}

await context.Response.WriteAsync(JsonSerializer.Serialize(product));

});


app.MapPost("/products",async (HttpContext context,Product product) => {

products.Add(product);

await context.Response.WriteAsync("Product Added");

});

app.Run();
