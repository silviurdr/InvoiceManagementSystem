﻿using InvoiceManagementSystem.DTOs;
using InvoicesManagementSystem.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InvoicesManagementSystem.Interfaces
{
    public interface IFacturaRepository
    {
        Task<Factura> GetFacturaAsync(int id);
        Task<IEnumerable<Factura>> GetFacturiAsync();
        Task<FacturaDto> CreateFactura(FacturaDto factura);
        void UpdateFactura(Factura factura);
        void DeleteFactura(int id);
        Task<bool> SaveAllAsync();
    }
}
