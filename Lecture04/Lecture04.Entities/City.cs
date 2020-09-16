using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lecture04.Entities
{
    public class City
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public virtual ICollection<Superhero> Superheroes { get; set; }
    }
}
