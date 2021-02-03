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

        public async Task<IEnumerable<FacturaDto>> GetFacturiAsync()
        {
            var facturi = await _context.Facturi.ToListAsync();

            var facturiToReturn = _mapper.Map<IEnumerable<FacturaDto>>(facturi);

            return facturiToReturn;
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

        public async Task<FacturaDto> CreateFactura(Factura factura)
        {

            Factura newFactura = new Factura
            {
                IdLocatie = factura.IdLocatie,
                NumarFactura = factura.NumarFactura,
                DataFactura = factura.DataFactura,
                NumeClient = factura.NumeClient,
            };

            try { await _context.Facturi.AddAsync(factura); }
            catch(Exception ex)
            {
                throw new Exception($"{nameof(factura)} could not be saved: {ex.Message}");
            }

            FacturaDto facturaToReturn = _mapper.Map<Factura, FacturaDto>(newFactura);

            return facturaToReturn;
        }

        public void UpdateFactura(FacturaDto factura)
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

        /*public async Task<int> GetLastFacturaId()
        {
            return  _context.Facturi.OrderBy(f => f.IdFactura).LastOrDefault().IdFactura;
        }
*/

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }


    }
}
