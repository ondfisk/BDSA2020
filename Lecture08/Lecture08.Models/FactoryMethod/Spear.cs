using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture08.Models.FactoryMethod
{
    public class Spear : IWeapon
    {
        public string Name => nameof(Spear);

        public int Damage => 12;

        public int Range => 5;
    }
}
