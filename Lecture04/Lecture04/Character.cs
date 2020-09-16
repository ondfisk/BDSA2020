namespace Lecture04
{
    public partial class Character
    {
        public int Id { get; set; }
        public int? ActorId { get; set; }
        public string Name { get; set; }
        public string Species { get; set; }
        public string Planet { get; set; }

        public virtual Actor Actor { get; set; }
    }
}
