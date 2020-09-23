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

        public int Create(SuperheroCreateDTO superhero)
        {
            throw new NotImplementedException();
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

            _context.Superheroes.Remove(entity);

            _context.SaveChanges();

            return Response.Deleted;
        }
    }
}