using AutoMapper;
using InvoiceManagementSystem.Data;
using InvoiceManagementSystem.DTOs;
using InvoiceManagementSystem.Interfaces;
using InvoicesManagementSystem.Entities;
using InvoicesManagementSystem.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace InvoiceManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {
        private readonly IFacturaRepository _facturaRepository;
        private readonly IDetaliiFacturaRepository _detaliiFacturaRepository;
        private readonly IMapper _mapper;

        public FacturaController(IFacturaRepository facturaRepository, IDetaliiFacturaRepository detaliiFacturaRepository,
            IMapper mapper)
        {
            _facturaRepository = facturaRepository;
            _detaliiFacturaRepository = detaliiFacturaRepository;
            _mapper = mapper;
        }
        // GET: api/<FacturaController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FacturaDto>>> GetAll()
        {
            return Ok(await _facturaRepository.GetFacturiAsync());
        }

        // GET api/<FacturaController>/5
        [HttpGet("{idFactura}")]
        public async Task<ActionResult<Factura>> Get(int idFactura)
        {
            return Ok(await _facturaRepository.GetFacturaAsync(idFactura));
        }

        // POST api/<FacturaController>
        [HttpPost]
        public async Task<ActionResult<Factura>> CreateEdit([FromBody] Factura factura)
        {
            if (factura.IdFactura == 0)
            {
                await _facturaRepository.CreateFactura(factura);

                if (await _facturaRepository.SaveAllAsync()) return factura;
                else return BadRequest("Unable to add factura");
            }
            
            else
            {
                var facturaFromDB = await _facturaRepository.GetFacturaAsync(factura.IdFactura);

                _mapper.Map(factura, facturaFromDB);

                _facturaRepository.UpdateFactura(facturaFromDB);

                if (await _facturaRepository.SaveAllAsync()) return NoContent();

                else
                {
                    return BadRequest("Unable to update factura");
                }
            }
        }

        // DELETE api/<FacturaController>/5
        [HttpDelete("{idFactura}")]
        public async Task<ActionResult> Delete(int idFactura)
        {
            _facturaRepository.DeleteFactura(idFactura);

            if (await _facturaRepository.SaveAllAsync())
            {
                return Ok();
            }
            else return BadRequest("Failed to update factura");
        }
    }
}
