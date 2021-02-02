using InvoiceManagementSystem.Data;
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

        public FacturaController(IFacturaRepository facturaRepository)
        {
            _facturaRepository = facturaRepository;
        }
        // GET: api/<FacturaController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Factura>>> GetAll()
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
        public async Task<ActionResult<Factura>> Create([FromBody] Factura factura)
        {
             _facturaRepository.CreateFactura(factura);
            await _facturaRepository.SaveAllAsync();

            return factura;
        }

        // PUT api/<FacturaController>/5
    /*    [HttpPut("{idFactura}")]
        public async Task<ActionResult<Factura>> Update(int idFactura, [FromBody] Factura newFactura)
        {
            var factura = _facturaRepository.GetFacturaAsync(idFactura);
            await _facturaRepository.UpdateFactura(newFactura);

            if (await _facturaRepository.SaveAllAsync()) return NoContent();

            return BadRequest("Failed to update user");
        }*/

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
