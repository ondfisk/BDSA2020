using System.Collections.Generic;
using Lecture09.Entities;

namespace Lecture09.Models
{
    public class SuperheroDetailsDTO : SuperheroListDTO
    {
        public string Occupation { get; set; }
        public int? CityId { get; set; }
        public string CityName { get; set; }
        public Gender Gender { get; set; }
        public int? FirstAppearance { get; set; }
        public string BackgroundUrl { get; set; }
        public ICollection<string> Powers { get; set; } = new HashSet<string>();
    }
}
