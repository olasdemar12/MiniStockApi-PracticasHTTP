using MiniStockApi.DTOs.Producto;

namespace MiniStockApi.Rutas.Products
{
    public class Products
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Categoria { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }

        public static List<Products> productos = new List<Products>
        {
            new Products(1, "Coca Cola 600ml", "Bebidas", 18.50m, 25),
            new Products(2, "Sabritas Original", "Botanas", 17.00m, 40),
            new Products(3, "Pan Bimbo Blanco", "Panaderia", 45.00m, 12),
            new Products(4, "Leche Lala 1L", "Lacteos", 29.90m, 18)
        };

        public Products(int id, string nombre, string categoria, decimal precio, int stock)
        {
            Id = id;
            Nombre = nombre;
            Categoria = categoria;
            Precio = precio;
            Stock = stock;
        }

        public static IResult getProducts(string? categoria, int? stockMinimo)
        {
            var query = productos.AsEnumerable();

            if (!string.IsNullOrWhiteSpace(categoria))
            {
                query = query.Where(p =>
                    p.Categoria.Equals(categoria, StringComparison.OrdinalIgnoreCase));
            }

            if (stockMinimo.HasValue)
            {
                query = query.Where(p => p.Stock >= stockMinimo.Value);
            }

            var productosFiltrados = query.ToList();

            var inforMationProducts = new
            {
                NameObject = "Productos encontrados",
                CountList = productosFiltrados.Count,
                Filters = new
                {
                    Categoria = categoria,
                    StockMinimo = stockMinimo
                },
                items = productosFiltrados
            };

            return Results.Ok(inforMationProducts);
        }

        public static IResult getProductById(int id)
        {
            var product = productos.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                var inforMationProduct = new { NameObject = "Producto encontrado", item = product };
                return Results.Ok(inforMationProduct);
            }
            else
            {
                return Results.NotFound(new { Message = "Producto no encontrado" });
            }
        }

        public static IResult createProduct(CreateProductRequest request)
        {
            int newId = productos.Max(p => p.Id) + 1;

            var newProduct = request.ConvertIntoProducts(newId);

            productos.Add(newProduct);

            var inforMationProduct = new { NameObject = "Producto creado", item = newProduct };

            return Results.Created($"/products/{newId}", inforMationProduct);
        }

        public static IResult getProductStock(int id)
        {
            var product = productos.FirstOrDefault(p => p.Id == id);

            if (product is null)
            {
                return Results.NotFound(new
                {
                    Message = $"Producto con Id {id} no encontrado"
                });
            }

            var response = new
            {
                ProductId = product.Id,
                ProductName = product.Nombre,
                Stock = product.Stock
            };

            return Results.Ok(response);
        }

        public static IResult updateProduct(int id, UpdateProductRequest request)
        {
            var product = productos.FirstOrDefault(p => p.Id == id);

            if (product is null)
            {
                return Results.NotFound(new
                {
                    Message = $"Producto con Id {id} no encontrado"
                });
            }

            product.Nombre = request.Nombre;
            product.Categoria = request.Categoria;
            product.Precio = request.Precio;
            product.Stock = request.Stock;

            var response = new
            {
                Message = "Producto actualizado correctamente",
                item = product
            };

            return Results.Ok(response);
        }
    }
}
