using System;
using System.Collections.Generic;

namespace Lecture04
{
    public partial class Characters
    {
        public int Id { get; set; }
        public int? ActorId { get; set; }
        public string Name { get; set; }
        public string Species { get; set; }
        public string Planet { get; set; }

        public virtual Actors Actor { get; set; }
    }
}
