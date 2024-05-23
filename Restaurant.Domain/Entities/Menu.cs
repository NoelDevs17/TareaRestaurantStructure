

using Restaurant.Domain.Core;

namespace Restaurant.Domain.Entities
{
    public class Menu
    {
        public int IdPlato { get; set; }
        public  string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public decimal? Precio { get; set; }
        public string? Categoria { get; set; }
    }
}
