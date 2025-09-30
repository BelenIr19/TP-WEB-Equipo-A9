using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dominio
{
    public class Imagen
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public int ArticuloId { get; set; }
    }
}