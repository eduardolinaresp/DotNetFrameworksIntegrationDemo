using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webApiPaises.Models;

namespace webApiPaises.Controllers
{
    [Produces("application/json")]
    [Route("api/Pais")]
    public class PaisController : Controller
    {
        private readonly ApplicationDbContext _context;
        public PaisController(ApplicationDbContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public IEnumerable <Pais> Get()
        {

            return _context.Paises.ToList();
        }

        [HttpGet("{id}", Name = "paisCreado")]
        public IActionResult GetById(int id)
        {
            var pais = _context.Paises.FirstOrDefault(x => x.Id == id);

            if (pais == null)
            {
                return NotFound();
            }

            return Ok(pais);
        }


        [HttpPost]
        public IActionResult Post([FromBody] Pais pais)
        {
            if (ModelState.IsValid)
            {
                _context.Paises.Add(pais);
                _context.SaveChanges();
                return new CreatedAtRouteResult("paisCreado", new { id = pais.Id }, pais);
            }

            return BadRequest(ModelState);
        }

    }
}