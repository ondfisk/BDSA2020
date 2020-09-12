using System;
using System.Collections.Generic;

namespace Lecture04
{
    public partial class Actors
    {
        public Actors()
        {
            Characters = new HashSet<Characters>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Characters> Characters { get; set; }
    }
}
