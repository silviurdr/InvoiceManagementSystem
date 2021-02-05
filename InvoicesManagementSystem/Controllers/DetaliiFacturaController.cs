using InvoiceManagementSystem.Interfaces;
using InvoicesManagementSystem.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InvoiceManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetaliiFacturaController : ControllerBase
    {
        private readonly IDetaliiFacturaRepository _detaliiFacturaRepository;

        public DetaliiFacturaController(IDetaliiFacturaRepository detaliiFacturaRepository)
        {
            _detaliiFacturaRepository = detaliiFacturaRepository;
        }

        // POST api/<DetaliiFactura>
        [HttpPost]
        public async Task<ActionResult<DetaliiFactura>> Post([FromBody] DetaliiFactura detaliiFactura)
        {
            await _detaliiFacturaRepository.CreateDetaliiFacturaAsync(detaliiFactura);

            if (await _detaliiFacturaRepository.SaveAllAsync()) return detaliiFactura;
            else return BadRequest("Unable to add factura");
        }

        // DELETE api/<DetaliiFactura>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            _detaliiFacturaRepository.DeleteDetaliiFactura(id);

            if (await _detaliiFacturaRepository.SaveAllAsync())
            {
                return Ok();
            } else return BadRequest("Failed to update detaliiFactura");
        }
    }
}
