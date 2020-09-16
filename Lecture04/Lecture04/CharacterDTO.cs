namespace Lecture04
{
    public class CharacterDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Species { get; set; }
        public string Planet { get; set; }
        public int ActorId { get; set; }
        public string ActorName { get; set; }

        public override string ToString() => $"{Id}: {Name} ({Species}) from {Planet} voiced by {ActorName}";
    }
}