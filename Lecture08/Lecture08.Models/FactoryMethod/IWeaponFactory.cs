using System.Collections.Generic;

namespace Lecture08.Models.FactoryMethod
{
    public interface IWeaponFactory
    {
        IEnumerable<string> Available();
        IWeapon Make(string name);
    }
}
