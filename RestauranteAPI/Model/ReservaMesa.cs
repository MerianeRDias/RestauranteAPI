using System;

namespace RestauranteAPI.Model
{
    public class ReservaMesa
    {
        public int Identificador { get; set; }
        public DateTime InicioReserva { get; set; }
        public DateTime FimReserva { get; set; }
        public string Cliente { get; set; }
        public Mesa Mesa { get; set;}
    }
}
