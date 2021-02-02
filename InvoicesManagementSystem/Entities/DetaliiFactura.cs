using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InvoicesManagementSystem.Entities
{
    public class DetaliiFactura
    {
        [Key]
        public int IdDetaliiFactura { get; set; }
        public int IdLocatie { get; set; }
        public string NumeProdus { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Cantitate { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal PretUnitar { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Valoare { get; set; }

        public int IdFactura { get; set; }
        public Factura Factura { get; set; }
    }
}
