﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Infraestructure.Models__Tarjeta_de_jugadores__muestra_informacion_importante_de_cada_jugador_
{
    public class PedidoModel
    {
        public int IdPedido { get; set; }
        public int IdCliente { get; set; }
        public string ClienteNombre { get; set; }
        public int IdMesa { get; set; }
        public int? MesaCapacidad { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public List<DetallePedidoModel> DetallesPedido { get; set; }
    }

}
