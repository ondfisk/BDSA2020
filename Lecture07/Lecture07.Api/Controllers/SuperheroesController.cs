using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Lecture07.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lecture07.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SuperheroesController : ControllerBase
    {
        private readonly ISuperheroRepository _repository;

        public SuperheroesController(ISuperheroRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SuperheroCreateDTO superhero)
        {
            var id = await _repository.Create(superhero);

            return CreatedAtAction(nameof(Get), new { id }, default);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SuperheroListDTO>>> Get()
        {
            return await _repository.Read().ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperheroDetailsDTO>> Get(int id)
        {
            var superhero = await _repository.Read(id);

            if (superhero == null)
            {
                return NotFound();
            }

            return superhero;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] SuperheroUpdateDTO superhero)
        {
            var response = await _repository.Update(superhero);

            return new StatusCodeResult((int)response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _repository.Delete(id);

            return new StatusCodeResult((int)response);
        }
    }
}
