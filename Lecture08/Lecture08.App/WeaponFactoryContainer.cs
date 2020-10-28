using System;
using System.Collections.Generic;
using System.Linq;
using Lecture08.Models.FactoryMethod;
using Microsoft.Extensions.DependencyInjection;

namespace Lecture08.App
{

    public class WeaponFactoryContainer : IWeaponFactory
    {
        public IEnumerable<string> Available() =>
            IoCContainer.Container.GetServices<IWeapon>().Select(t => t.Name);

        public IWeapon Make(string name) =>
            IoCContainer.Container.GetServices<IWeapon>().SingleOrDefault(t => t.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }
}