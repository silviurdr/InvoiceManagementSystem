using InvoicesManagementSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.Interfaces
{
    interface IDetaliiFacturaRepository
    {
        Task<DetaliiFactura> GetDetaliiFacturaAsync(int id);

        Task<DetaliiFactura> CreateDetaliiFacturaAsync(int idFactura, int idLocatie, DetaliiFactura detaliiFactura);

        void UpdateDetaliiFactura(int idFactura, DetaliiFactura detaliiFactura);
    }
}
