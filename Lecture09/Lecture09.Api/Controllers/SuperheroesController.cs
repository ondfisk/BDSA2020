using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Lecture09.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace Lecture09.Api.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("[controller]")]
    public class SuperheroesController : ControllerBase
    {
        private readonly ISuperheroRepository _repository;

        public SuperheroesController(ISuperheroRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        [ProducesResponseType(Status201Created)]
        [ProducesResponseType(Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] SuperheroCreateDTO superhero)
        {
            var id = await _repository.Create(superhero);

            return CreatedAtAction(nameof(Get), new { id }, default);
        }

        [HttpGet]
        [ProducesResponseType(Status200OK)]
        public async Task<ActionResult<IEnumerable<SuperheroListDTO>>> Get()
        {
            return await _repository.Read().ToListAsync();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(Status200OK)]
        [ProducesResponseType(Status404NotFound)]
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
        [ProducesResponseType(Status204NoContent)]
        [ProducesResponseType(Status404NotFound)]
        public async Task<IActionResult> Put(int id, [FromBody] SuperheroUpdateDTO superhero)
        {
            if (id != superhero.Id)
            {
                ModelState.AddModelError("id", "id in URL must match id in body");

                return BadRequest(ModelState);
            }

            var response = await _repository.Update(superhero);

            return new StatusCodeResult((int)response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(Status204NoContent)]
        [ProducesResponseType(Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _repository.Delete(id);

            return new StatusCodeResult((int)response);
        }
    }
}
