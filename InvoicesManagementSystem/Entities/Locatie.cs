using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InvoicesManagementSystem.Entities
{
    public class Locatie
    {
        [Key]
        public int IdLocatie { get; set; }

        [Required]
        public string Nume { get; set; }

        [Required]
        public string Adresa { get; set; }
        public ICollection<Factura> Facturi { get; set; }
        public ICollection<DetaliiFactura> DetaliiFacturi { get; set; }
    }
}
