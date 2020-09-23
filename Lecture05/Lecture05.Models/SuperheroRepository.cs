using System;
using System.Collections.Generic;
using System.Linq;
using Lecture05.Entities;
using static Lecture05.Models.Response;

namespace Lecture05.Models
{
    public class SuperheroRepository : ISuperheroRepository
    {
        private readonly ISuperheroContext _context;

        public SuperheroRepository(ISuperheroContext context)
        {
            _context = context;
        }

        private int GetOrCreateCity(string name)
        {
            var entity = _context.Cities.FirstOrDefault(c => c.Name == name) ?? new City { Name = name };

            if (entity.Id == 0)
            {
                _context.Cities.Add(entity);
                _context.SaveChanges();
            }

            return entity.Id;
        }

        public int Create(SuperheroCreateDTO superhero)
        {
            var entity = new Superhero
            {
                Name = superhero.Name,
                AlterEgo = superhero.AlterEgo,
                CityId = GetOrCreateCity(superhero.CityName),
                Gender = superhero.Gender
            };

            _context.Superheroes.Add(entity);
            _context.SaveChanges();

            return entity.Id;
        }

        public SuperheroDetailsDTO Read(int superheroId)
        {
            throw new NotImplementedException();
        }

        public ICollection<SuperheroListDTO> Read()
        {
            throw new NotImplementedException();
        }

        public Response Update(SuperheroUpdateDTO superhero)
        {
            throw new NotImplementedException();
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
    }
}