using MiniStockApi.Rutas.Inicio;
using MiniStockApi.Rutas.Products;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGet("/", HomeRoutes.GetHome);

app.MapGet("/saludo", HomeRoutes.GetSaludo);

app.MapGet("/productos", Products.getProducts);

app.MapGet("/productos/{id}", Products.getProductById);

app.MapPost("/productos", Products.createProduct);

app.MapGet("/productos/{id}/stock", Products.getProductStock);

app.Run();
