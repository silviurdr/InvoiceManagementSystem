using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvoiceManagementSystem.DTOs
{
    public class DetaliiFacturaDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdDetaliiFactura { get; set; }

        public int IdLocatie { get; set; }

        [Required]
        public string NumeProdus { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Cantitate { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal PretUnitar { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Valoare { get; set; }
        public int IdFactura { get; set; }
    }
}
