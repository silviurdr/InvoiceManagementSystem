using AutoMapper;
using InvoiceManagementSystem.DTOs;
using InvoiceManagementSystem.Interfaces;
using InvoicesManagementSystem.Data;
using InvoicesManagementSystem.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.Data
{
    public class DetaliiFacturaRepository : IDetaliiFacturaRepository
    {
        private readonly InvoiceManagementContext _context;
        private readonly IMapper _mapper;

        public DetaliiFacturaRepository(InvoiceManagementContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<DetaliiFacturaDto> CreateDetaliiFacturaAsync(DetaliiFactura newDetaliiFactura)
        {

            DetaliiFacturaDto detaliiFactura;

            detaliiFactura = new DetaliiFacturaDto
            {
                IdFactura = newDetaliiFactura.IdFactura,
                IdLocatie = newDetaliiFactura.IdLocatie,
                NumeProdus = newDetaliiFactura.NumeProdus,
                Cantitate = newDetaliiFactura.Cantitate,
                PretUnitar = newDetaliiFactura.PretUnitar,
                Valoare = newDetaliiFactura.Valoare

            };

            try { await _context.AddAsync(_mapper.Map<DetaliiFacturaDto, DetaliiFactura>(detaliiFactura)); }
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
        public void DeleteDetaliiFactura(int detaliiFacturaId)
        {
            var detaliiFacturaToRemove = _context.DetaliiFacturi
                .FirstOrDefault(df => df.IdDetaliiFactura == detaliiFacturaId);

            if (detaliiFacturaToRemove == null)
            {
                throw new ArgumentNullException($"{nameof(detaliiFacturaToRemove)} entity must not be null");
            }

            try { _context.DetaliiFacturi.Remove(detaliiFacturaToRemove); }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(detaliiFacturaToRemove)} entity could not be deleted: {ex.Message}");
            }
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
