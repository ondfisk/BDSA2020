using System.Collections.Generic;

namespace Lecture04
{
    public partial class Actor
    {
        public Actor()
        {
            Characters = new HashSet<Character>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Character> Characters { get; set; }
    }
}
