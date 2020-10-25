namespace Lecture08.Models.FactoryMethod
{
    public class Crossbow : IWeapon
    {
        public string Name => nameof(Crossbow);

        public int Damage => 12;

        public int Range => 12;
    }
}
