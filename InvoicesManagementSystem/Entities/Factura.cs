using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InvoicesManagementSystem.Entities
{
    public class Factura
    {
        [Key]
        public int IdFactura { get; set; }

        public int IdLocatie { get; set; }

        public Locatie Locatie { get; set; }
        
        public string NumarFactura { get; set; }
        public DateTime DataFactura { get; set; }
        public string NumeClient { get; set; }
        public DetaliiFactura DetaliiFactura { get; set; }

    }
}
