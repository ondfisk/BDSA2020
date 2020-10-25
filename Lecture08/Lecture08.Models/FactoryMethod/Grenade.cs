namespace Lecture08.Models.FactoryMethod
{
    public class Grenade : IWeapon
    {
        public string Name => nameof(Grenade);

        public int Damage => 128;

        public int Range => 4;
    }
}
