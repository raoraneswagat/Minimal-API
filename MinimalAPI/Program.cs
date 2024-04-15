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

app.Run();
