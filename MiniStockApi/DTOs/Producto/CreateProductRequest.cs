using MiniStockApi.Rutas.Products;

namespace MiniStockApi.DTOs.Producto
{
    public class CreateProductRequest
    {
        public string Nombre { get; set; }
        public string Categoria { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }

        public Products ConvertIntoProducts(int id)
        {
            return new Products(id, Nombre, Categoria, Precio, Stock);
        }
    }
}
