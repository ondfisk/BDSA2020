using System;

namespace Lecture08.Models.FactoryMethod
{
    public class Spoon : IWeapon
    {
        public string Name { get => "The silver spoon of Antioq"; }

        public int Damage => 0;

        public int Range { get { return 0; } }
    }

    public class NuclearSpoon : IWeapon
    {
        private static Random _random = new Random();

        public string Name => "The silver spoon of Antioq dipped in liquid plutonium";

        public int Damage => _random.Next(200) * 3;

        public int Range => 0;
    }
}
