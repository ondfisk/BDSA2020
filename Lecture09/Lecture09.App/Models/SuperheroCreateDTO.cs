using System.Collections.Generic;

namespace Lecture09.App.Models
{
    public class SuperheroCreateDTO
    {
        public string Name { get; set; }

        public string AlterEgo { get; set; }

        public string Occupation { get; set; }

        public string CityName { get; set; }

        public Gender Gender { get; set; }
        
        public int? FirstAppearance { get; set; }

        public string PortraitUrl { get; set; }

        public string BackgroundUrl { get; set; }

        public ICollection<string> Powers { get; set; }
    }
}
