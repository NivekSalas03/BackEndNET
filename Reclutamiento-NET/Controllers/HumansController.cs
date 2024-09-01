using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Reclutamiento_NET.Context;
using Reclutamiento_NET.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Reclutamiento_NET.Controllers
{
    [Route("api/[controller]")]
    public class HumansController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public HumansController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Human>>> GetHuman()
        {
            return await _context.Human.ToListAsync();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Human>> GetHuman(int id)
        {
            var human = await _context.Human.FindAsync(id);

            if (human == null)
            {
                return NotFound();
            }

            return human;
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult<Human>> PostHuman(Human human)
        {
            _context.Human.Add(human);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHuman", new { id = human.Id, human });
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHuman(int id, Human human)
        {
            if(id != human.Id)
            {
                return BadRequest();
            }

            _context.Entry(human).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch  (DbUpdateConcurrencyException)
            {
                if (GetHuman(id) == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHuman(int id)
        {
            var human = await _context.Human.FindAsync(id);

            if(human == null)
            {
                return NotFound();
            }

            _context.Human.Remove(human);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // GET Mock
        [HttpGet("getmock")]
        public ActionResult<IEnumerable<Human>> GetHumanMock()
        {

            var humanos = new List<Human>
            {
                new Human { Id = 1, Nombre = "Juan Garcia", Sexo= "M", Edad = 30, Altura = 134, Peso= 67},
                new Human { Id = 2, Nombre = "Obed Aguero", Sexo= "M", Edad = 25, Altura = 167, Peso= 87},
                new Human { Id = 3, Nombre = "Darian Garcia", Sexo= "M", Edad = 40, Altura = 187, Peso= 65}
            };

            return Ok(humanos);
        }
    }
}

