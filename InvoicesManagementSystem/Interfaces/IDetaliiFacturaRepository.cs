using InvoiceManagementSystem.DTOs;
using InvoicesManagementSystem.Entities;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.Interfaces
{
    public interface IDetaliiFacturaRepository
    {
        Task<DetaliiFactura> GetDetaliiFacturaAsync(int id);
        Task<DetaliiFacturaDto> CreateDetaliiFacturaAsync(DetaliiFactura detaliiFactura);
        void UpdateDetaliiFactura(int idFactura, DetaliiFactura detaliiFactura);
        void DeleteDetaliiFactura(int detaliiFacturaId);
        Task<bool> SaveAllAsync();
    }
}
