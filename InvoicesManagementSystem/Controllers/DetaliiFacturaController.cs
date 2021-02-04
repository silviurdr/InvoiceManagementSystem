using InvoiceManagementSystem.Interfaces;
using InvoicesManagementSystem.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
        // GET: api/<DetaliiFactura>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<DetaliiFactura>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<DetaliiFactura>
        [HttpPost]
        public async Task<ActionResult<DetaliiFactura>> Post([FromBody] DetaliiFactura detaliiFactura)
        {
            await _detaliiFacturaRepository.CreateDetaliiFacturaAsync(detaliiFactura);

            if (await _detaliiFacturaRepository.SaveAllAsync()) return detaliiFactura;
            else return BadRequest("Unable to add factura");
        }

        // PUT api/<DetaliiFactura>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DetaliiFactura>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
