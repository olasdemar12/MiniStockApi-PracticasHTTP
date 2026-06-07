using MiniStockApi.Rutas.Inicio;
using MiniStockApi.Rutas.Products;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();



app.MapGet("/", HomeRoutes.GetHome);

app.MapGet("/saludo", HomeRoutes.GetSaludo);

app.MapGet("/productos", Products.getProducts);

app.Run();
