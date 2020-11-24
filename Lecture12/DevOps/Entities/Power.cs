using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lecture12.Entities
{
    public class Power
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public virtual ICollection<Power> Superheroes { get; set; }
    }
}
