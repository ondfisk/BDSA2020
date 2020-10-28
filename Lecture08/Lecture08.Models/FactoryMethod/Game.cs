using System;

namespace Lecture08.Models.FactoryMethod
{
    public class Game
    {
        private readonly IWeaponFactory _factory;

        public Game(IWeaponFactory factory)
        {
            _factory = factory;
        }

        public Game()
            : this(new WeaponFactory())
        {
        }

        public void Run()
        {
            Console.Clear();

            IWeapon weapon = null;

            do
            {
                Console.WriteLine("Please choose your weapon");

                foreach (var available in _factory.Available())
                {
                    Console.WriteLine($"- {available}");
                }

                var input = Console.ReadLine();

                weapon = _factory.Make(input);
            }
            while (weapon == null);

            Console.WriteLine("You have chosen wisely...");

            Console.WriteLine($"A {weapon.Name} with damage {weapon.Damage} and range {weapon.Range}");

            Console.WriteLine();

            Console.Write("Try again [y/n] ");

            var key = Console.ReadKey();
            Console.WriteLine();

            if (key.KeyChar == 'y')
            {
                Run();
            }
        }
    }
}
