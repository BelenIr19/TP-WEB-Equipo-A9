using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dominio
{
    public class Voucher
    {
        public int Codigo { get; set; }
        public int IdCliente { get; set; }
        public DateTime FechaCanje { get; set; }
        public int IdArticulo { get; set; }
    }
}