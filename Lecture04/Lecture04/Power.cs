using System.Collections.Generic;

namespace Lecture04
{
    public class Power
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Superhero> Superheroes { get; set; }
    }
}
