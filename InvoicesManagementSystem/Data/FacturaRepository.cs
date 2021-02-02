using InvoicesManagementSystem.Data;
using InvoicesManagementSystem.Entities;
using InvoicesManagementSystem.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.Data
{
    public class FacturaRepository : IFacturaRepository
    {
        private readonly InvoiceManagementContext _context;

        public FacturaRepository(InvoiceManagementContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Factura>> GetFacturiAsync()
        {
            try
            {
                return await _context.Facturi
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Could not receive entity: {ex.Message}");
            }
        }

        public async Task<Factura> GetFacturaAsync(int id)
        {
            Factura factura;
            try
            {
                factura =  await _context.Facturi
                    .SingleOrDefaultAsync(f => f.IdFactura == id);

                return factura;
            }
            catch(Exception ex)
            {
                throw new Exception($"Couldn't receive entitie : {ex.Message}");
            }
        }

        public async Task<Factura> CreateFactura(Factura factura)
        {

            try { await _context.Facturi.AddAsync(factura); }
            catch(Exception ex)
            {
                throw new Exception($"{nameof(factura)} could not be saved: {ex.Message}");
            }

            return factura;
        }

        public void UpdateFactura(Factura factura)
        {
            throw new NotImplementedException();
        }

        public void DeleteFactura(int id)
        {
            var factura =  _context.Facturi
                .FirstOrDefault(f => f.IdFactura == id);

            if (factura == null)
            {
                throw new ArgumentNullException($"{nameof(factura)} entity must not be null");
            }

            try
            {
                 _context.Facturi.Remove(factura);
            }
            catch(Exception ex)
            {
                throw new Exception($"{nameof(factura)} entity could not be deleted: {ex.Message}");
            }
            
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }


    }
}
