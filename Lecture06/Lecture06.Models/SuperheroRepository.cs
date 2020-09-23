using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lecture06.Entities;
using Microsoft.EntityFrameworkCore;
using static Lecture06.Models.Response;

namespace Lecture06.Models
{
    public class SuperheroRepository : ISuperheroRepository
    {
        private readonly ISuperheroContext _context;

        public SuperheroRepository(ISuperheroContext context)
        {
            _context = context;
        }

        public int Create(SuperheroCreateDTO superhero)
        {
            var entity = new Superhero
            {
                Name = superhero.Name,
                AlterEgo = superhero.AlterEgo,
                City = GetCity(superhero.CityName),
                Occupation = superhero.Occupation,
                Gender = superhero.Gender,
                FirstAppearance = superhero.FirstAppearance,
                Powers = GetPowers(superhero.Powers).ToList()
            };

            _context.Superheroes.Add(entity);
            _context.SaveChanges();

            return entity.Id;
        }

        public SuperheroDetailsDTO Read(int superheroId)
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
                             Powers = h.Powers.Select(p => p.Power.Name).ToList()
                         };

            return heroes.FirstOrDefault();
        }

        public ICollection<SuperheroListDTO> Read()
        {
            var heroes = from h in _context.Superheroes
                         select new SuperheroListDTO
                         {
                             Id = h.Id,
                             Name = h.Name,
                             AlterEgo = h.AlterEgo,
                         };

            return heroes.ToList();
        }

        public Response Update(SuperheroUpdateDTO superhero)
        {
            var entity = _context.Superheroes.Find(superhero.Id);

            if (entity == null)
            {
                return NotFound;
            }

            entity.Name = superhero.Name;
            entity.AlterEgo = superhero.AlterEgo;
            entity.City = GetCity(superhero.CityName);
            entity.Occupation = superhero.Occupation;
            entity.Gender = superhero.Gender;
            entity.FirstAppearance = superhero.FirstAppearance;
            entity.Powers = GetPowers(superhero.Powers).ToList();

            _context.SaveChanges();

            return Updated;
        }

        public Response Delete(int superheroId)
        {
            var entity = _context.Superheroes.Find(superheroId);

            if (entity == null)
            {
                return NotFound;
            }

            _context.Superheroes.Remove(entity);

            _context.SaveChanges();

            return Deleted;
        }

        private City GetCity(string name) => _context.Cities.FirstOrDefault(c => c.Name == name) ?? new City { Name = name };

        private IEnumerable<SuperheroPower> GetPowers(IEnumerable<string> names)
        {
            var powers = (from p in _context.Powers
                          where names.Contains(p.Name)
                          select p).ToDictionary(p => p.Name);

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