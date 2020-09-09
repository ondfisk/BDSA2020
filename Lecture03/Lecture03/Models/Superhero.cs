using System;
using System.Collections.Generic;

namespace Lecture03.Models
{
    public class Superhero
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AlterEgo { get; set; }
        public string Occupation { get; set; }
        public int? CityId { get; set; }
        public Gender Gender { get; set; }
        public int FirstAppearance { get; set; }
        public ICollection<string> Powers { get; set; }
        public ICollection<Group> GroupAffiliations { get; set; }

        public override string ToString() => $"{Name} aka {AlterEgo} ({FirstAppearance})";
    }

    public class Superhero2
    {
        public string GivenName { get; set; }
        public string Surname { get; set; }
        public string AlterEgo { get; set; }
        public DateTime FirstAppearance { get; set; }
        public string City { get; set; }

        public override string ToString()
        {
            return $"{GivenName} {Surname} aka {AlterEgo}";
        }
    }
}
