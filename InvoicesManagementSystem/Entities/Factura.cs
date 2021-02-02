using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoicesManagementSystem.Entities
{
    public class Factura
    {
        public int IdFactura { get; set; }
        public int IdLocatie { get; set; }
        public string NumarFactura { get; set; }
        public DateTime DataFactura { get; set; }
        public string NumeClient { get; set; }
    }
}
