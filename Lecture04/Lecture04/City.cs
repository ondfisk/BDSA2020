using System.Collections.Generic;

namespace Lecture04
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Superhero> Superheroes { get; set; }
    }
}
