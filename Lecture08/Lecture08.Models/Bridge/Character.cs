using System.ComponentModel.DataAnnotations;

namespace Lecture08.Models.Bridge
{
    public class Character
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Planet { get; set; }

        [Required]
        [StringLength(50)]
        public string Species { get; set; }

        public override string ToString() => $"{Name} is a {Species} from {Planet}";
    }
}
