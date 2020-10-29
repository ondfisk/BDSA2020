using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Lecture09.Entities;
using Microsoft.EntityFrameworkCore;
using static System.Net.HttpStatusCode;

namespace Lecture09.Models
{
    public class SuperheroRepository : ISuperheroRepository
    {
        private readonly ISuperheroContext _context;

        public SuperheroRepository(ISuperheroContext context)
        {
            _context = context;
        }

        public async Task<int> Create(SuperheroCreateDTO superhero)
        {
            var entity = new Superhero
            {
                Name = superhero.Name,
                AlterEgo = superhero.AlterEgo,
                City = await GetCity(superhero.CityName),
                Occupation = superhero.Occupation,
                Gender = superhero.Gender,
                FirstAppearance = superhero.FirstAppearance,
                PortraitUrl = superhero.PortraitUrl,
                BackgroundUrl = superhero.BackgroundUrl,
                Powers = await GetPowers(superhero.Powers).ToListAsync()
            };

            _context.Superheroes.Add(entity);
            await _context.SaveChangesAsync();

            return entity.Id;
        }

        public async Task<SuperheroDetailsDTO> Read(int superheroId)
        {
            var heroes = from h in _context.Superheroes
                         where h.Id == superheroId
                         select new SuperheroDetailsDTO
                         {
                             Id = h.Id,
                             Name = h.Name,
                             AlterEgo = h.AlterEgo,
                             Occupation = h.Occupation,
                             CityId = h.CityId,
                             CityName = h.City.Name,
                             Gender = h.Gender,
                             FirstAppearance = h.FirstAppearance,
                             PortraitUrl = h.PortraitUrl,
                             BackgroundUrl = h.BackgroundUrl,
                             Powers = h.Powers.Select(p => p.Power.Name).ToList()
                         };

            return await heroes.FirstOrDefaultAsync();
        }

        public IQueryable<SuperheroListDTO> Read()
        {
            return from h in _context.Superheroes
                   select new SuperheroListDTO
                   {
                       Id = h.Id,
                       Name = h.Name,
                       AlterEgo = h.AlterEgo,
                       PortraitUrl = h.PortraitUrl
                   };
        }

        public async Task<HttpStatusCode> Update(SuperheroUpdateDTO superhero)
        {
            var entity = await _context.Superheroes.FindAsync(superhero.Id);

            if (entity == null)
            {
                return NotFound;
            }

            entity.Name = superhero.Name;
            entity.AlterEgo = superhero.AlterEgo;
            entity.City = await GetCity(superhero.CityName);
            entity.Occupation = superhero.Occupation;
            entity.Gender = superhero.Gender;
            entity.FirstAppearance = superhero.FirstAppearance;
            entity.PortraitUrl = superhero.PortraitUrl;
            entity.BackgroundUrl = superhero.BackgroundUrl;
            entity.Powers = await GetPowers(superhero.Powers).ToListAsync();

            await _context.SaveChangesAsync();

            return NoContent;
        }

        public async Task<HttpStatusCode> Delete(int superheroId)
        {
            var entity = await _context.Superheroes.FindAsync(superheroId);

            if (entity == null)
            {
                return NotFound;
            }

            _context.Superheroes.Remove(entity);

            await _context.SaveChangesAsync();

            return NoContent;
        }

        private async Task<City> GetCity(string name) => await _context.Cities.FirstOrDefaultAsync(c => c.Name == name) ?? new City { Name = name };

        private async IAsyncEnumerable<SuperheroPower> GetPowers(IEnumerable<string> names)
        {
            var powers = await (from p in _context.Powers
                                where names.Contains(p.Name)
                                select p).ToDictionaryAsync(p => p.Name);

            foreach (var name in names)
            {
                if (powers.TryGetValue(name, out var power))
                {
                    yield return new SuperheroPower { Power = power };
                }
                else
                {
                    yield return new SuperheroPower { Power = new Power { Name = name } };
                }
            }
        }
    }
}
