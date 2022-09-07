using FA22.P03.Web;
using FA22.P03.Web.Features.Products;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DataContext")));

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddControllers();

var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<DataContext>();
    var context = scope.ServiceProvider.GetRequiredService<IServiceProvider>();

    db.Database.Migrate();
    SeedData.Initialize(context);

}


app.MapControllers();
// Configure the HTTP request pipeline.
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
/*
app.MapGet("/api/products", () =>
    {
        return products;
    })
    .Produces(200, typeof(ProductDto[]));

app.MapGet("/api/products/{id}", (int id) =>
    {
        var result = products.FirstOrDefault(x => x.Id == id);
        if (result == null)
        {
            return Results.NotFound();
        }

        return Results.Ok(result);
    })
    .WithName("GetProductById")
    .Produces(404)
    .Produces(200, typeof(ProductDto));

app.MapPost("/api/products", (ProductDto product) =>
    {
        if (string.IsNullOrWhiteSpace(product.Name) ||
            product.Name.Length > 120 ||
            product.Price <= 0 ||
            string.IsNullOrWhiteSpace(product.Description))
        {
            return Results.BadRequest();
        }

        product.Id = currentId++;
        products.Add(product);
        return Results.CreatedAtRoute("GetProductById", new { id = product.Id }, product);
    })
    .Produces(400)
    .Produces(201, typeof(ProductDto));

app.MapPut("/api/products/{id}", (int id, ProductDto product) =>
    {
        if (string.IsNullOrWhiteSpace(product.Name) ||
            product.Name.Length > 120 ||
            product.Price <= 0 ||
            string.IsNullOrWhiteSpace(product.Description))
        {
            return Results.BadRequest();
        }

        var current = products.FirstOrDefault(x => x.Id == id);
        if (current == null)
        {
            return Results.NotFound();
        }

        current.Name = product.Name;
        current.Name = product.Name;
        current.Price = product.Price;
        current.Description = product.Description;

        return Results.Ok(current);
    })
    .Produces(400)
    .Produces(404)
    .Produces(200, typeof(ProductDto));

app.MapDelete("/api/products/{id}", (int id) =>
    {
        var current = products.FirstOrDefault(x => x.Id == id);
        if (current == null)
        {
            return Results.NotFound();
        }

        products.Remove(current);

        return Results.Ok();
    })
    .Produces(400)
    .Produces(404)
    .Produces(200, typeof(ProductDto));
*/

app.Run();

//see: https://docs.microsoft.com/en-us/aspnet/core/test/integration-tests?view=aspnetcore-6.0
// Hi 383 - this is added so we can test our web project automatically. More on that later
public partial class Program { }
