using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvoicesManagementSystem.Entities
{
    public class Factura
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdFactura { get; set; }
        public int IdLocatie { get; set; }
        public Locatie Locatie { get; set; }
        [Required]
        public string NumarFactura { get; set; }
        public DateTime DataFactura { get; set; }
        [Required]
        public string NumeClient { get; set; }
        public IEnumerable<DetaliiFactura> DetaliiFactura { get; set; }
    }
}
