namespace MiniStockApi.Rutas.Inicio
{
    public class HomeRoutes
    {
        private static string _messageHome = "Hola desde inicio";
        private static string _messageSaludo = "Bienvenido a MiniStockApi";

        public static string GetHome()
        {
            return _messageHome;
        }

        public static IResult? GetSaludo()
        {
            var results = new { 
                Message = _messageSaludo, 
                Cosa = 1,
            };
            return Results.Ok(results);
        }
    }
}
