using InvoicesManagementSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoicesManagementSystem.Interfaces
{
    public interface IFacturaRepository
    {
        Task<Factura> GetFactura(int id);
        Task<IEnumerable<Factura>> GetFacturi();
        Task<Factura> CreateFactura();
        void UpdateFactura(Factura factura);
        void DeleteFactura(int id);
        Task<bool> SaveAllAsync();
    }
}
