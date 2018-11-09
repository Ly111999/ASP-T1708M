using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_netCore.Controllers.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api_netCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SClassController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public SClassController(ApiDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<SClass> GetAllSClasses()
        {
            return _context.SClasses;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClassById([FromRoute]int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sClass = await _context.Students.FindAsync(id);
            if (sClass == null)
            {
                return NotFound();
            }

            return Ok(sClass);
        }

        [HttpPost]
        public async Task<IActionResult> CreateClass([FromBody] SClass sClass)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.SClasses.Add(sClass);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetClassById", new {id = sClass.Id}, sClass);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSClass([FromRoute] int id, [FromBody] SClass sClass)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sClass.Id)
            {
                return NotFound();
            }

            _context.Entry(sClass).State = EntityState.Modified;
            try
            {
               await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                if (!SClassExist(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetClassById", new {id = sClass.Id}, sClass);
        }

        public bool SClassExist(int id)
        {
            return _context.SClasses.Any(sc => sc.Id == id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSClass([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sClass = await _context.SClasses.FindAsync(id);
            if (sClass == null)
            {
                return NotFound();
            }

            _context.SClasses.Remove(sClass);
            await _context.SaveChangesAsync();
            return Ok(sClass);
        }
    }
}