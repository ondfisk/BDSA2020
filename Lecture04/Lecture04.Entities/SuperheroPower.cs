namespace Lecture04.Entities
{
    public class SuperheroPower
    {
        public int SuperheroId { get; set; }
        public virtual Superhero Superhero { get; set; }
        public int PowerId { get; set; }
        public virtual Power Power { get; set; }
    }
}
