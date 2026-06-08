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

        public static object getProducts()
        {
            var inforMationProducts = new { NameObject = "Productos encontrados", CountList = productos.Count, items = productos };

            return inforMationProducts;
        }

        public static object getProductById(int id)
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
    }
}
