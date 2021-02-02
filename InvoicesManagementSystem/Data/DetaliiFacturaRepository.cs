using InvoiceManagementSystem.Interfaces;
using InvoicesManagementSystem.Data;
using InvoicesManagementSystem.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.Data
{
    public class DetaliiFacturaRepository : IDetaliiFacturaRepository
    {
        private readonly InvoiceManagementContext _context;

        public DetaliiFacturaRepository(InvoiceManagementContext context)
        {
            _context = context;
        }
        public async Task<DetaliiFactura> CreateDetaliiFacturaAsync(int idFactura, int idLocatie, DetaliiFactura newDetaliiFactura)
        {

            DetaliiFactura detaliiFactura;

            detaliiFactura = new DetaliiFactura
            {
                IdDetaliiFactura = idFactura,
                IdLocatie = idLocatie,
                NumeProdus = newDetaliiFactura.NumeProdus,
                Cantitate = newDetaliiFactura.Cantitate,
                PretUnitar = newDetaliiFactura.PretUnitar,
                Valoare = newDetaliiFactura.Valoare

            };

            try { await _context.AddAsync(detaliiFactura); }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(detaliiFactura)} could not be saved: {ex.Message}");
            }

            return detaliiFactura;
        }

        public async Task<DetaliiFactura> GetDetaliiFacturaAsync(int id)
        {
            DetaliiFactura detaliiFactura;
            try
            {
                detaliiFactura = await _context.DetaliiFacturi
                    .SingleOrDefaultAsync(f => f.IdFactura == id);

                return detaliiFactura;
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't receive entitie : {ex.Message}");
            }
        }

        public void UpdateDetaliiFactura(int idFactura, DetaliiFactura detaliiFactura)
        {
            throw new NotImplementedException();
        }
    }
}
