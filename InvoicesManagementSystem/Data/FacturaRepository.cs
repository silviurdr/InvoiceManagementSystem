using AutoMapper;
using InvoiceManagementSystem.DTOs;
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
        private readonly IMapper _mapper;

        public FacturaRepository(InvoiceManagementContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Factura>> GetFacturiAsync()
        {
            return await _context.Facturi
                .Include(f => f.DetaliiFactura)
                .ToListAsync();
        }

        public async Task<Factura> GetFacturaAsync(int id)
        {
            Factura factura;
            try
            {
                factura = await _context.Facturi
                    .Where(f => f.IdFactura == id)
                    .Include(f => f.DetaliiFactura)
                    .SingleOrDefaultAsync(f => f.IdFactura == id);

                return factura;
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't receive entitie : {ex.Message}");
            }
        }

        public async Task<FacturaDto> CreateFactura(FacturaDto factura)
        {

            Factura newFactura = new Factura
            {
                IdLocatie = factura.IdLocatie,
                NumarFactura = factura.NumarFactura,
                DataFactura = factura.DataFactura,
                NumeClient = factura.NumeClient,
                DetaliiFactura = factura.DetaliiFactura
            };

            try { await _context.Facturi.AddAsync(_mapper.Map<FacturaDto, Factura>(factura)); }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(factura)} could not be saved: {ex.Message}");
            }

            FacturaDto facturaToReturn = _mapper.Map<Factura, FacturaDto>(newFactura);

            return facturaToReturn;
        }

        public void UpdateFactura(Factura factura)
        {

            _context.Entry(factura).State = EntityState.Modified;

        }

        public void DeleteFactura(int id)
        {
            var factura = _context.Facturi
                .FirstOrDefault(f => f.IdFactura == id);

            if (factura == null)
            {
                throw new ArgumentNullException($"{nameof(factura)} entity must not be null");
            }

            try
            {
                _context.Facturi.Remove(factura);
            }
            catch (Exception ex)
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
