﻿
namespace Restaurant.Infraestructure.Models
{
    public class MenuModel
    {
            public int IdPlato { get; set; }
            public string Nombre { get; set; }
            public string Descripcion { get; set; }
            public decimal Precio { get; set; }
            public string Categoria { get; set; }
        
    }
}
