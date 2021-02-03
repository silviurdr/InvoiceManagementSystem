using InvoicesManagementSystem.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.DTOs
{
    public class FacturaDto
    {

        [Key]
        public int IdFactura { get; set; }
        public int IdLocatie { get; set; }

        [Required]
        public string NumarFactura { get; set; }
        public DateTime DataFactura { get; set; }

        [Required]
        public string NumeClient { get; set; }
        public ICollection<DetaliiFacturaDto> DetaliiFactura { get; set; }
    }
}
