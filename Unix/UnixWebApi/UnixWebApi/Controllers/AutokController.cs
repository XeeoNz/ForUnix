using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnixWebApi.Models;

namespace UnixWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutokController : ControllerBase
    {
        private readonly UnixDbContext _context;

        public AutokController(UnixDbContext context)
        {
            _context = context;
        }

        // GET: api/Autok
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Auto>>> GetAutok()
        {

            var mList =  await _context.Modellek.Include(m => m.Gyarto).Include(m => m.Reszletek).ToListAsync();

            List<Auto> autok = new List<Auto>();

            foreach (var model in mList)
            {
                var auto = new Auto
                {
                    GyartoId = model.GyartoId,
                    GyartoNev = model.Gyarto.GyartoNev,
                    ModellId = model.Id,
                    ModellNev = model.ModellNev,
                    ReszletekId = model.ReszletekId,
                    Ajtok = model.Reszletek.Ajtok,
                    Teljesitmeny = model.Reszletek.Teljesitmeny,
                    Ulesek = model.Reszletek.Ulesek,
                    Evjarat = model.Reszletek.Evjarat
                };
                autok.Add(auto);
            }

            return autok;

        }

        // GET: api/Autok/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Auto>> GetAuto(int id)
        {
            var result = await _context.Modellek.Where(m => m.Id == id).Join(_context.Gyartok, m => m.GyartoId, gy => gy.Id, (m, gy) => new { m, gy })
                .Join(_context.Reszletek, a => a.m.ReszletekId, r => r.Id, (a, r) => new { a, r }).FirstOrDefaultAsync();

            if (result == null)
            {
                return NotFound();
            }

            Auto auto = new Auto
            {
                GyartoId = result.a.gy.Id,
                GyartoNev = result.a.gy.GyartoNev,
                ModellId = result.a.m.Id,
                ModellNev = result.a.m.ModellNev,
                ReszletekId = result.a.m.ReszletekId,
                Ajtok = result.r.Ajtok,
                Teljesitmeny = result.r.Teljesitmeny,
                Ulesek = result.r.Ulesek,
                Evjarat = result.r.Evjarat
            };

            return auto;
        }

        // DELETE: api/Autok/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuto(int id)
        {
            var modell = await _context.Modellek.FindAsync(id);
            if (modell == null)
            {
                return NotFound();
            }

            var reszletek = await _context.Reszletek.FindAsync(modell.ReszletekId);
            if(reszletek == null)
            {
                return NotFound();
            }

            _context.Modellek.Remove(modell);
            _context.Reszletek.Remove(reszletek);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Autok
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Auto>> PostAuto(Auto auto)
        {
            var gyartoId = await _context.Gyartok.Where(gy => gy.GyartoNev.ToUpper() == auto.GyartoNev.ToUpper()).Select(gy => gy.Id).FirstOrDefaultAsync();

            if(gyartoId == 0)
            {
                var newGyarto = new Gyarto
                {
                    GyartoNev = auto.GyartoNev
                };
                _context.Gyartok.Add(newGyarto);
                await _context.SaveChangesAsync();
                gyartoId = newGyarto.Id;
            }
            
            var reszletek = new Reszletek
            {
                Ajtok = auto.Ajtok,
                Teljesitmeny = auto.Teljesitmeny,
                Ulesek = auto.Ulesek,
                Evjarat = auto.Evjarat
            };

            _context.Reszletek.Add(reszletek);
            await _context.SaveChangesAsync();

            var modell = new Modell
            {
                ModellNev = auto.ModellNev,
                GyartoId = gyartoId,
                ReszletekId = reszletek.Id
            };

            _context.Modellek.Add(modell);
            await _context.SaveChangesAsync();
                
            return Ok();
        }

        // PUT: api/Autok/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuto(int id, Auto auto)
        {
            if (id != auto.ModellId)
            {
                return BadRequest();
            }

            var gyartoId = await _context.Gyartok.Where(gy => gy.GyartoNev.ToUpper() == auto.GyartoNev.ToUpper()).Select(gy => gy.Id).FirstOrDefaultAsync();

            if (gyartoId == 0)
            {
                var newGyarto = new Gyarto
                {
                    GyartoNev = auto.GyartoNev
                };
                _context.Gyartok.Add(newGyarto);
                await _context.SaveChangesAsync();
                gyartoId = newGyarto.Id;
            }

            var reszletek = new Reszletek
            {
                Id = auto.ReszletekId,
                Ajtok = auto.Ajtok,
                Teljesitmeny = auto.Teljesitmeny,
                Ulesek = auto.Ulesek,
                Evjarat = auto.Evjarat
            };

            _context.Entry(reszletek).State = EntityState.Modified;

            var modell = new Modell
            {
                Id = auto.ModellId,
                ModellNev = auto.ModellNev,
                GyartoId = gyartoId,
                ReszletekId = reszletek.Id
            };

            _context.Entry(modell).State = EntityState.Modified;


            await _context.SaveChangesAsync();


            return NoContent();
        }
    }
}
