using System.Text.Json;

namespace MinimalAPI;

public static class ProductMapGroup
{
    public static List<Product> products = new List<Product>(){

    new Product(){Id=1,Name="Phone"},
    new Product(){Id=1,Name="TV"},
};
    public static RouteGroupBuilder ProductsAPI(this RouteGroupBuilder group)
    {

        group.MapGet("/", async (HttpContext context) =>
        {

            string content = string.Join("\n", products.Select(s => s.ToString()));
            await context.Response.WriteAsync(content);

        });

        group.MapGet("/{id:int}", async (HttpContext context, int id) =>
        {

            Product? product = products.Where(w => w.Id == id).FirstOrDefault();
            if (product == null)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync("Incorrect Product Id");
                return;
            }

            await context.Response.WriteAsync(JsonSerializer.Serialize(product));

        });


        group.MapPost("/", async (HttpContext context, Product product) =>
        {

            products.Add(product);

            await context.Response.WriteAsync("Product Added");

        });

        return group;
    }
}
