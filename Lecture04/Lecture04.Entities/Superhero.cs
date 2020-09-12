using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lecture04.Entities
{
    public class Superhero
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string AlterEgo { get; set; }

        [StringLength(50)]
        public string Occupation { get; set; }

        public int? CityId { get; set; }

        public City City { get; set; }

        public Gender Gender { get; set; }

        public int? FirstAppearance { get; set; }

        public ICollection<SuperheroPower> Powers { get; set; }

        public override string ToString()
        {
            return $"{Name} aka {AlterEgo} ({FirstAppearance})";
        }
    }
}
